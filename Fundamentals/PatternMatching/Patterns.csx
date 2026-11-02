#!/usr/bin/env dotnet

string bankRecords = """
    DEPOSIT,   10000, Initial balance
    DEPOSIT,     500, regular deposit
    WITHDRAWAL, 1000, rent
    """;

//-------------------
// Enum matches (if)

{
    double currentBalance = 0.0;

    foreach (var transaction in TransactionRecords(bankRecords))
    {
        if (transaction.type == TransactionType.Deposit) {
            currentBalance += transaction.amount;
        }
        else if (transaction.type == TransactionType.Withdrawal) {
            currentBalance -= transaction.amount;
        }
        Console.WriteLine($"{transaction.type} => Parsed Amount: {transaction.amount}, New Balance: {currentBalance}");
    }
}

//-----------------------
// Enum matches (switch)

{
    double currentBalance = 0.0;

    foreach (var transaction in TransactionRecords(bankRecords))
    {
        currentBalance += transaction switch
        {
            (TransactionType.Deposit, var amount) => amount,
            (TransactionType.Withdrawal, var amount) => -amount,
            _ => 0.0,
        };
        Console.WriteLine($"{transaction.type} => Parsed Amount: {transaction.amount}, New Balance: {currentBalance}");
    }
}

//---------------
// Type patterns

{
    double currentBalance = 0.0;

    foreach (var transaction in TransactionRecordType(bankRecords))
    {
        currentBalance += transaction switch
        {
            Deposit d => d.Amount,
            Withdrawal w => -w.Amount,
            _ => 0.0,
        };
        Console.WriteLine($" {transaction} => New Balance: {currentBalance}");
    }
}

static IEnumerable<(TransactionType type, double amount)> TransactionRecords(string inputText)
{
    var reader = new StringReader(inputText);

    string? line;
    while ((line = reader.ReadLine()) is not null)
    {
        string[] parts = line.Split(',');

        string? transactionType = parts[0]?.Trim();
        
        if (double.TryParse(parts[1].Trim(), out double amount))
        {
            // Update the balance based on transaction type
            if (transactionType?.ToUpper() is "DEPOSIT") {
                yield return (TransactionType.Deposit, amount);
            }
            else if (transactionType?.ToUpper() is "WITHDRAWAL") {
                yield return (TransactionType.Withdrawal, amount);
            }
        }
        else {
            yield return (TransactionType.Invalid, 0.0);
        }
    }
}

static IEnumerable<object?> TransactionRecordType(string inputText)
{
    var reader = new StringReader(inputText);

    string? line;
    while ((line = reader.ReadLine()) is not null)
    {
        string[] parts = line.Split(',');

        string? transactionType = parts[0]?.Trim();

        if (double.TryParse(parts[1].Trim(), out double amount))
        {
            // Update the balance based on transaction type
            if (transactionType?.ToUpper() is "DEPOSIT") {
                yield return new Deposit(amount, parts[2]);
            }
            else if (transactionType?.ToUpper() is "WITHDRAWAL") {
                yield return new Withdrawal(amount, parts[2]);
            }
        }
    }
}

public enum TransactionType
{
    Deposit,
    Withdrawal,
    Invalid
}

public record Deposit(double Amount, string description);
public record Withdrawal(double Amount, string description);
