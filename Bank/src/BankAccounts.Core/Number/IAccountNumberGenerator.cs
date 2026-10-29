namespace BankAccounts.Core.IAccountNumber;
//ГЕНЕРАТОР НОМЕРОВ отдельная ответсвеность не должна быть внутри счета(srp)
internal interface IAccountNumberGenerator
{
    string Next(); 
}
