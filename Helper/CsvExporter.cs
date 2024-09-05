using ExpenseTracker.Model;

namespace ExpenseTracker.Helper;

public class CsvExporter
{
    public void ExportToCsv(List<Expense> expenses, string filePath)
    {
        var csvLines = new List<string> { "Id,Date,Description,Amount,Category" };
        foreach (var expense in expenses)
        {
            csvLines.Add($"{expense.Id},{expense.Date.ToString("yyyy-MM-dd")},{expense.Description},{expense.Amount},{expense.Category}");
        }
        File.WriteAllLines(filePath, csvLines);
        Console.WriteLine($"Expenses exported to {filePath}");
    }
}
