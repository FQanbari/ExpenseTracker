# Expense Tracker CLI Application

This is a simple command-line application for tracking your personal expenses. It allows you to add, view, delete, and summarize your expenses. Additionally, it supports expense categories, monthly budgets, and exporting expenses to a CSV file.

## Features

- **Add Expense**: Add an expense with a description, amount, and optional category.
- **Delete Expense**: Delete an expense by its ID.
- **List Expenses**: View all expenses or filter by category.
- **Expense Summary**: Get a summary of total expenses, including monthly summaries.
- **Set Budget**: Set a budget for the current month and receive a warning if exceeded.
- **CSV Export**: Export your expenses to a CSV file.

## Setup

### Prerequisites

- .NET SDK 6.0 or later
- Any text editor or IDE (e.g., Visual Studio, VS Code)

### Clone the repository

```bash
git clone <https://github.com/FQanbari/ExpenseTracker.git>
cd ExpenseTracker

```

### Build the project

```bash
dotnet build

```

### Run the project

```bash
dotnet run -- [command] [arguments]

```

## Usage

### Add an Expense

```bash
dotnet run -- add --description "Lunch" --amount 15 --category "Food"

```

Example Output:

```
Expense added successfully (ID: 1)

```

### List All Expenses

```bash
dotnet run -- list

```

Example Output:

```
ID   Date       Description   Amount  Category
1    2024-09-01  Lunch         $15    Food

```

### List Expenses by Category

```bash
dotnet run -- list --category "Food"

```

Example Output:

```
ID   Date       Description   Amount  Category
1    2024-09-01  Lunch         $15    Food

```

### Delete an Expense

```bash
dotnet run -- delete --id 1

```

Example Output:

```
Expense deleted successfully

```

### Get a Summary of Total Expenses

```bash
dotnet run -- summary

```

Example Output:

```
Total expenses: $30

```

### Get a Summary of Expenses for a Specific Month

```bash
dotnet run -- summary --month 9

```

Example Output:

```
Total expenses for September: $30

```

### Set a Monthly Budget

```bash
dotnet run -- set-budget --amount 500

```

Example Output:

```
Budget set for the current month: $500

```

### Export Expenses to CSV

```bash
dotnet run -- export --file expenses.csv

```

### Commands Overview

| Command | Description |
| --- | --- |
| `add --description --amount [--category]` | Add a new expense with an optional category. |
| `delete --id [expense-id]` | Delete an expense by ID. |
| `list [--category]` | List all expenses, optionally filtered by category. |
| `summary` | Get a total summary of expenses. |
| `summary --month [month-number]` | Get a summary of expenses for a specific month. |
| `set-budget --amount [amount]` | Set a budget for the current month. |
| `export --file [file-path]` | Export expenses to a CSV file at the specified file path. |

## Error Handling

- Invalid inputs (e.g., negative amounts, non-existent IDs) will return appropriate error messages.
- If the budget is exceeded, a warning will be displayed when running the `summary` command.

## Data Storage

The expenses are stored in a local JSON file (`expenses.json`). You can modify this file to manage persistent data across sessions. The file is loaded when the program starts and saved each time you add, update, or delete expenses.

## Additional Features

- **Expense Categories**: You can add a category to each expense to better organize your data.
- **Budget Tracking**: Set a budget and receive warnings when expenses exceed that amount.
- **CSV Export**: Export your expenses to a CSV file for easy viewing and analysis.

## Future Improvements

- Ability to update an existing expense.
- Multiple user profiles to track expenses for different users.
- Enhanced filtering options (e.g., filter by date ranges).
- Interactive CLI for a more user-friendly experience.

## License

This project is licensed under the MIT License.

---