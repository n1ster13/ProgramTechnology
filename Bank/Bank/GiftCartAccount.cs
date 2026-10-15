namespace Bank;
/// <summary>
/// asa
/// </summary>
public class GiftCartAccount: BankAccount
{
    private readonly decimal _monthlyDeposit = 0m;

    // monthlyDeposit - параметр по умолчанию (принимает 0),
    // при создании new GiftCartAccount("Yana",1000); => monthlyDeposit = 0
    // new GiftCartAccount("Yana",1000,5000); => monthlyDeposit = 5000
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="initialBalance"></param>
    /// <param name="monthlyDeposit"></param>
    public GiftCartAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0)
        :base(name, initialBalance) 
        => _monthlyDeposit = monthlyDeposit;
    /// <summary>
    /// 
    /// </summary>
    public override void PerformMonthAndTransactions()
    {
        if (_monthlyDeposit != 0)
        {
            MakeDeposit(_monthlyDeposit, DateTime.UtcNow, "Add monthly deposit");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString() 
        => base.ToString()+$"monthly deposit: {_monthlyDeposit}";
}
