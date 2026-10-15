namespace Bank;
/// <summary>
/// 
/// </summary>

public class InterestEarningAccount : BankAccount
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="initialBalance"></param>
    public InterestEarningAccount(string name, decimal initialBalance)
        : base(name, initialBalance)
    {

    }

    // override позволяет в дочернем классе определить новую реализацию
    // метода PerformMonthAndTransactions
    /// <summary>
    /// 
    /// </summary>
    public override void PerformMonthAndTransactions()
    {
        if (Balance > 500m)
        {
            decimal interest = Balance * 0.02m;
            MakeDeposit(interest, DateTime.UtcNow, "Apply month interest");
        }
    }
}
