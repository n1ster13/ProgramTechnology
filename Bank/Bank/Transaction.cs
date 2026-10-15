namespace Bank;

// record - Состояние объектов этого класса нельзя изменить
/// <summary>
/// Представляет одну транзакцию по счёту: сумму, дату и примечание.
/// Является неизменяемым (immutable) типом-записью.
/// </summary>
/// <param name="Amount">Сумма транзакции (положительная — пополнение, отрицательная — списание).</param>
/// <param name="Date">Дата и время совершения транзакции.</param>
/// <param name="Note">Текстовое примечание к транзакции.</param>
public record Transaction(decimal Amount, DateTime Date, string Note);

//internal record Transaction
//{
//    /// <summary>
//    /// Сумма транзакции.
//    /// </summary>
//    public decimal Amount { get; }

//    /// <summary>
//    /// Дата и время совершения транзакции.
//    /// </summary>
//    public DateTime Date { get; }

//    /// <summary>
//    /// Текстовое примечание к транзакции.
//    /// </summary>
//    public string Note { get; }

//    /// <summary>
//    /// Создаёт новую транзакцию.
//    /// </summary>
//    /// <param name="Amount">Сумма транзакции.</param>
//    /// <param name="Date">Дата и время совершения транзакции.</param>
//    /// <param name="Note">Текстовое примечание к транзакции.</param>
//    public Transaction(decimal Amount, DateTime Date, string Note)
//    {
//        this.Amount = Amount;
//        this.Note = Note;
//        this.Date = Date;
//    }
//}