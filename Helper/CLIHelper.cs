namespace ExpenseTracker.Helper;

public static class CLIHelper
{
    public static void ShowHelp()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine("expense-tracker add --description \"Description\" --amount 20 --category \"Food\"");
        Console.WriteLine("expense-tracker delete --id 1");
        Console.WriteLine("expense-tracker list --category \"Food\"");
        Console.WriteLine("expense-tracker summary --month 8");
        Console.WriteLine("expense-tracker set-budget --amount 500");
        Console.WriteLine("expense-tracker export --file expenses.csv");
    }
}
