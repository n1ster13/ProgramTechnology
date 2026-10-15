namespace Bank;

/// <summary>
/// Кредитная линия — банковский счёт с возможностью уходить в минус
/// в пределах установленного кредитного лимита. При превышении лимита
/// начисляется штраф за овердрафт, а при отрицательном балансе
/// в конце месяца — проценты.
/// </summary>
public class LineOfCreditAccount : BankAccount
{
    /// <summary>
    /// Создаёт кредитную линию с заданным кредитным лимитом.
    /// </summary>
    /// <param name="name">Имя владельца счёта.</param>
    /// <param name="initialBalance">Начальный баланс счёта.</param>
    /// <param name="creditLimit">
    /// Кредитный лимит — максимальная сумма, на которую можно уйти в минус.
    /// Передаётся в базовый класс как отрицательный минимальный баланс.
    /// </param>
    public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit)
        : base(name, initialBalance, -creditLimit)
    {
    }

    /// <summary>
    /// Начисляет месячные проценты по кредиту, если баланс отрицательный.
    /// Вызывается в конце месяца.
    /// </summary>
    public override void PerformMonthAndTransactions()
    {
        if (Balance < 0)
        {
            decimal interest = -Balance * 0.07m;
            MakeWithdrawal(interest, DateTime.UtcNow, "Charge monthly interest");
        }
    }

    /// <summary>
    /// Проверяет, не превышен ли кредитный лимит. Если превышен —
    /// возвращает штрафную транзакцию за овердрафт.
    /// </summary>
    /// <param name="isOverdrawn">
    /// <c>true</c>, если баланс после снятия опустится ниже минимального.
    /// </param>
    /// <returns>
    /// Штрафную транзакцию за овердрафт или <c>null</c>, если превышения нет.
    /// </returns>
    protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        => isOverdrawn
            ? new Transaction(-20, DateTime.UtcNow, "apply overdraft")
            : default;

}