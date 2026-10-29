namespace BankAccounts.Core.Time;

public sealed class SystemClock:IClock
{
    public DateTime Now => DateTime.UtcNow;
}
