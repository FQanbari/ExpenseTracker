using ExpenseTracker.Handler;
using ExpenseTracker.Model;

namespace ExpenseTracker.Manager;

public class ExpenseManager
{
    private List<Expense> _expenses;

    public ExpenseManager()
    {
        _expenses = ExpenseFileHandler.LoadExpenses();
    }

    public void AddExpense(string description, decimal amount, string category = "General")
    {
        int newId = _expenses.Any() ? _expenses.Max(e => e.Id) + 1 : 1;
        var expense = new Expense
        {
            Id = newId,
            Description = description,
            Amount = amount,
            Date = DateTime.Now,
            Category = category
        };
        _expenses.Add(expense);
        ExpenseFileHandler.SaveExpenses(_expenses);
        Console.WriteLine($"Expense added successfully (ID: {expense.Id})");
    }


    public void UpdateExpense(int id, string description, decimal amount, string category)
    {
        var expense = _expenses.FirstOrDefault(e => e.Id == id);
        if (expense != null)
        {
            expense.Description = description;
            expense.Amount = amount;
            expense.Category = category;
            ExpenseFileHandler.SaveExpenses(_expenses);
            Console.WriteLine($"Expense updated successfully (ID: {id})");
        }
        else
        {
            Console.WriteLine("Expense not found.");
        }
    }

    public void DeleteExpense(int id)
    {
        var expense = _expenses.FirstOrDefault(e => e.Id == id);
        if (expense != null)
        {
            _expenses.Remove(expense);
            ExpenseFileHandler.SaveExpenses(_expenses);
            Console.WriteLine($"Expense deleted successfully (ID: {id})");
        }
        else
        {
            Console.WriteLine("Expense not found.");
        }
    }

    public void ListExpenses(string category = null)
    {
        var filteredExpenses = string.IsNullOrEmpty(category)
            ? _expenses
            : _expenses.Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();

        Console.WriteLine("ID   Date       Description   Amount  Category");
        foreach (var expense in filteredExpenses)
        {
            Console.WriteLine($"{expense.Id}   {expense.Date.ToString("yyyy-MM-dd")}  {expense.Description}   ${expense.Amount}  {expense.Category}");
        }
    }


    public void ShowSummary(int? month = null, BudgetManager budgetManager = null)
    {
        var filteredExpenses = month.HasValue
            ? _expenses.Where(e => e.Date.Month == month.Value && e.Date.Year == DateTime.Now.Year).ToList()
            : _expenses;

        decimal total = filteredExpenses.Sum(e => e.Amount);
        Console.WriteLine(month.HasValue
            ? $"Total expenses for {DateTime.Now.ToString("MMMM")}: ${total}"
            : $"Total expenses: ${total}");

        budgetManager?.CheckBudget(total);
    }
    public List<Expense> GetExpensesByCategory(string category)
    {
        return string.IsNullOrEmpty(category)
            ? _expenses
            : _expenses.Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public decimal GetTotalExpenses()
    {
        return _expenses.Sum(e => e.Amount);
    }

    public decimal GetTotalExpensesForMonth(int month)
    {
        return _expenses.Where(e => e.Date.Month == month && e.Date.Year == DateTime.Now.Year).Sum(e => e.Amount);
    }

    public List<Expense> GetAllExpenses()
    {
        return _expenses;
    }
}
