namespace ExpenseTracker.Manager;

public class BudgetManager
{
    private decimal _monthlyBudget;

    public void SetBudget(decimal budget)
    {
        _monthlyBudget = budget;
        Console.WriteLine($"Monthly budget set to: ${budget}");
    }

    public void CheckBudget(decimal totalExpenses)
    {
        if (totalExpenses > _monthlyBudget)
        {
            Console.WriteLine($"Warning: You have exceeded your budget by ${totalExpenses - _monthlyBudget}");
        }
    }
}
