/// <summary>
/// Класс куртки.
/// Наследуется от класса одежды и реализует интерфейс стирки.
/// </summary>
public class Jacket : Clothing, IWashable
{
    /// <summary>
    /// Тип застёжки куртки.
    /// </summary>
    private readonly string _zipperType;

    /// <summary>
    /// Уровень утепления куртки.
    /// </summary>
    public int Insulation { get; set; }

    /// <summary>
    /// Определяет, является ли куртка тёплой.
    /// Куртка считается тёплой при утеплении от 2 и выше.
    /// </summary>
    public bool IsWarm => Insulation >= 2;

    /// <summary>
    /// Создаёт куртку с указанным артикулом,
    /// названием, ценой и уровнем утепления.
    /// Тип застёжки устанавливается по умолчанию.
    /// </summary>
    /// <param name="sku">Артикул куртки.</param>
    /// <param name="name">Название куртки.</param>
    /// <param name="price">Цена куртки.</param>
    /// <param name="insulation">Уровень утепления.</param>
    public Jacket(
        string sku,
        string name,
        decimal price,
        int insulation)
        : this(sku, name, price, insulation, "Standard")
    {
    }

    /// <summary>
    /// Создаёт куртку с указанными характеристиками
    /// и типом застёжки.
    /// </summary>
    /// <param name="sku">Артикул куртки.</param>
    /// <param name="name">Название куртки.</param>
    /// <param name="price">Цена куртки.</param>
    /// <param name="insulation">Уровень утепления.</param>
    /// <param name="zipperType">Тип застёжки.</param>
    public Jacket(
        string sku,
        string name,
        decimal price,
        int insulation,
        string zipperType)
        : base(sku, name, price)
    {
        Insulation = insulation;
        _zipperType = zipperType;
    }

    /// <summary>
    /// Выводит сообщение о том, что куртку носят.
    /// </summary>
    public override void Wear()
    {
        Console.WriteLine($"{Name} worn.");
    }

    /// <summary>
    /// Выводит сообщение о стирке куртки.
    /// </summary>
    public void Wash()
    {
        Console.WriteLine($"{Name} washed.");
    }

    /// <summary>
    /// Возвращает строковое представление куртки
    /// с её основными характеристиками.
    /// </summary>
      public override string ToString()
    {
        return $"[Jacket] {Name}, {Price}, season: {Season}, " +
               $"insulation: {Insulation}, zipper: {_zipperType}";
    }
}