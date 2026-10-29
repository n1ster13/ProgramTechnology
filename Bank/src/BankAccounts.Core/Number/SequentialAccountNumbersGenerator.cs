namespace BankAccounts.Core.IAccountNumber;
//последовательная нумирация модно заменит на gui или другую стратшию spr

public sealed class SequentialAccountNumbersGenerator:IAccountNumberGenerator
{
    private int _seed;
    public SequentialAccountNumbersGenerator(int seed = 1234567890) => _seed = seed;
    public string Next()
    { 
        return(_seed++).ToString();
    }

}
