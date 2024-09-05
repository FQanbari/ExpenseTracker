using ExpenseTracker.Model;
using Newtonsoft.Json;

namespace ExpenseTracker.Handler;

public static class ExpenseFileHandler
{
    private static string filePath = "expenses.json";

    public static List<Expense> LoadExpenses()
    {
        if (!File.Exists(filePath))
        {
            return new List<Expense>();
        }

        var jsonData = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<Expense>>(jsonData) ?? new List<Expense>();
    }

    public static void SaveExpenses(List<Expense> expenses)
    {
        var jsonData = JsonConvert.SerializeObject(expenses, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);
    }
}
