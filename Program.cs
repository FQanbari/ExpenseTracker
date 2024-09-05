using ExpenseTracker.Helper;
using ExpenseTracker.Manager;
using ExpenseTracker.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<ExpenseManager>();
        services.AddSingleton<BudgetManager>();
        services.AddSingleton<CsvExporter>();
    })
    .Build();

var expenseManager = host.Services.GetRequiredService<ExpenseManager>();
var budgetManager = host.Services.GetRequiredService<BudgetManager>();

if (args.Length == 0)
{
    CLIHelper.ShowHelp();
    return;
}

switch (args[0].ToLower())
{
    case "add":
        string description = args[2];
        decimal amount = Convert.ToDecimal(args[4]);
        string category = args.Length > 6 ? args[6] : "General";
        expenseManager.AddExpense(description, amount, category);
        break;

    case "delete":
        int idToDelete = Convert.ToInt32(args[2]);
        expenseManager.DeleteExpense(idToDelete);
        break;

    case "list":
        string filterCategory = args.Length > 2 ? args[2] : null;
        ListExpenses(expenseManager.GetExpensesByCategory(filterCategory));
        break;

    case "summary":
        if (args.Length > 2 && args[2] == "--month")
        {
            int month = Convert.ToInt32(args[3]);
            decimal total = expenseManager.GetTotalExpensesForMonth(month);
            Console.WriteLine($"Total expenses for {DateTime.Now.ToString("MMMM")}: ${total}");
            budgetManager.CheckBudget(total);
        }
        else
        {
            decimal total = expenseManager.GetTotalExpenses();
            Console.WriteLine($"Total expenses: ${total}");
            budgetManager.CheckBudget(total);
        }
        break;

    case "set-budget":
        decimal budget = Convert.ToDecimal(args[2]);
        budgetManager.SetBudget(budget);
        break;

    case "export":
        string csvFilePath = args[2];
        var csvExporter = host.Services.GetRequiredService<CsvExporter>();
        csvExporter.ExportToCsv(expenseManager.GetAllExpenses(), csvFilePath);
        break;

    default:
        CLIHelper.ShowHelp();
        break;
}

void ListExpenses(List<Expense> expenses)
{
    Console.WriteLine("ID   Date       Description   Amount  Category");
    foreach (var expense in expenses)
    {
        Console.WriteLine($"{expense.Id}   {expense.Date.ToString("yyyy-MM-dd")}  {expense.Description}   ${expense.Amount}  {expense.Category}");
    }
}