namespace BankAccounts.Core.Accounts;

internal interface IAccountOperations

{
    decimal Balnce {  get;}
    void Deposit(decimal amount, DateTime date, string note);
    void Withdraw(decimal amount, DateTime date, string note);

}
