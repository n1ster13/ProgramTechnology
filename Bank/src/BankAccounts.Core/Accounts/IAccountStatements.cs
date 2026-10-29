using BankAccounts.Core.Transactions;
namespace BankAccounts.Core.Accounts;
//isp: клиенты не спят
internal interface IAccountStatements
{
    IReadOnlyList<Transaction> Transactions { get; }
}
