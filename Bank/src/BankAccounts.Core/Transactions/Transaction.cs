namespace BankAccounts.Core.Transactions;

public sealed record Transaction(decimal Amount, DateTime Date, String Note);
