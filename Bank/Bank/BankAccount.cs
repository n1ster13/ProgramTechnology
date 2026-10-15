using System.Text;

namespace Bank;

/// <summary>
/// Представляет банковский счёт с возможностью пополнения, снятия средств
/// с минимальным допустимым балансом
/// </summary>
public class BankAccount
{
    /// <summary>
    /// Минимально допустимый баланс счёта. Если баланс опускается ниже создаётся овердрафтная транзакция.
    /// </summary>
    private readonly decimal _minimumBalance;

    /// <summary>
    /// Статический счётчик для генерации уникальных номеров счетов.
    /// Начальное значение — 1 000 000 000.
    /// </summary>
    private static int s_accountNumberSeed = 1000000000;

    /// <summary>
    /// Список всех транзакций по счёту (пополнения, снятия, овердрафты).
    /// </summary>
    private List<Transaction> _allTransactions = new List<Transaction>();

    /// <summary>
    /// Уникальный номер банковского счёта. Задаётся при создании и не меняется.
    /// </summary>
    public string Number { get; }

    /// <summary>
    /// Имя владельца счёта. Изменить можно только внутри класса.
    /// </summary>
    public string Owner { get; private set; }

    /// <summary>
    /// Текущий баланс счёта. Вычисляется динамически как сумма всех транзакций.
    /// </summary>
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var item in _allTransactions)
            {
                balance += item.Amount;
            }

            return balance;
        }
    }

    /// <summary>
    /// Создаёт банковский счёт с нулевым минимальным балансом.
    /// </summary>
    /// <param name="name">Имя владельца счёта.</param>
    /// <param name="initialBalance">Начальный баланс счёта.</param>
    public BankAccount(string name, decimal initialBalance)
        : this(name, initialBalance, 0)
    {
    }

    /// <summary>
    /// Создаёт банковский счёт с заданным минимальным балансом.
    /// </summary>
    /// <param name="name">Имя владельца счёта.</param>
    /// <param name="initialBalance">Начальный баланс счёта.</param>
    /// <param name="minimumBalance">Минимально допустимый баланс.</param>
    public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
    {
        Owner = name;

        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;

        _minimumBalance = minimumBalance;

        if (initialBalance > 0)
            MakeDeposit(initialBalance, DateTime.UtcNow, "Initial balance");
    }

    /// <summary>
    /// Выполняет пополнение счёта на указанную сумму.
    /// </summary>
    /// <param name="amount">Сумма пополнения. Должна быть положительной.</param>
    /// <param name="date">Дата и время транзакции.</param>
    /// <param name="note">Примечание к транзакции.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Выбрасывается, если <paramref name="amount"/> меньше или равен нулю.
    /// </exception>
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(amount), "Amount of deposit must be positive");
        }

        var deposit = new Transaction(amount, date, note);
        _allTransactions.Add(deposit);
    }

    /// <summary>
    /// Выполняет снятие средств со счёта. Если баланс опускается ниже
    /// минимально допустимого, может быть создана овердрафтная транзакция.
    /// </summary>
    /// <param name="amount">Сумма снятия. Должна быть положительной.</param>
    /// <param name="date">Дата и время транзакции.</param>
    /// <param name="note">Примечание к транзакции.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Выбрасывается, если <paramref name="amount"/> меньше или равен нулю.
    /// </exception>
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

        Transaction? overdraftTransaction
            = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
        Transaction? withdrawal = new(-amount, date, note);

        _allTransactions.Add(withdrawal);

        if (overdraftTransaction is not null)
            _allTransactions.Add(overdraftTransaction);
    }

    /// <summary>
    /// Проверяет, не превышен ли минимально допустимый баланс при снятии.
    /// Может быть переопределён в дочерних классах для другой логики овердрафта.
    /// </summary>
    /// <param name="isOverdrawn">
    /// <c>true</c>, если баланс после снятия опустится ниже минимального.
    /// </param>
    /// <returns>
    /// Овердрафтную транзакцию или <c>null</c>, если овердрафт не требуется.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Выбрасывается, если овердрафт запрещён для данного типа счёта.
    /// </exception>
    protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
    {
        if (isOverdrawn)
        {
            throw new InvalidOperationException(
                "Not sufficient rubls for this withdrawal");
        }
        else
        {
            return default; // == return null;
        }
    }

    /// <summary>
    /// Формирует текстовый отчёт по всем транзакциям счёта
    /// с указанием даты, суммы, остатка и примечания.
    /// </summary>
    /// <returns>Строка с историей операций по счёту.</returns>
    public string GetAccountHistory()
    {
        var report = new StringBuilder();

        decimal balance = 0;
        report.AppendLine("Data\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"" +
                $"{item.Date.ToShortDateString()}\t" +
                $"{item.Amount}\t{balance}\t{item.Note}");
        }
        return report.ToString();
    }

    /// <summary>
    /// Выполняет операции, которые должны происходить в конце месяца
    /// (например, начисление процентов). Может быть переопределён в дочерних классах.
    /// </summary>
    public virtual void PerformMonthAndTransactions()
    {
    }

    /// <summary>
    /// Возвращает строковое представление счёта: владельца, номер и тип счёта.
    /// </summary>
    /// <returns>Строка с информацией о счёте.</returns>
    public override string ToString()
    {
        return $"Owner: {Owner}\taccount number: {Number} (тип счета {GetType()})";
    }
}