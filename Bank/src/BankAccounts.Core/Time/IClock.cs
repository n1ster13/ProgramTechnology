namespace BankAccounts.Core.Time;
/// <summary>
/// выносим зависимости в интерфейс чтоб было понятно
/// </summary>

public interface IClock
{
    DateTime Now { get; }
}

