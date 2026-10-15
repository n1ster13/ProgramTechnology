public class TShirt : Clothing
{
    private readonly string _fabric;
    public string Size { get; set; }

    /// <summary>
    /// Определяет, является ли размер футболки большим.
    /// Большими считаются размеры XL, XXL и XXXL.
    /// </summary>
    public bool IsBigSize =>
        Size == "XL" || Size == "XXL" || Size == "XXXL";

    /// <summary>
    /// Создаёт футболку с указанным артикулом,
    /// названием, ценой и размером.
    /// Материал по умолчанию хлопок.
    /// </summary>
    /// <param name="sku">Артикул футболки.</param>
    /// <param name="name">Название футболки.</param>
    /// <param name="price">Цена футболки.</param>
    /// <param name="size">Размер футболки.</param>
    public TShirt(
        string sku,
        string name,
        decimal price,
        string size)
        : this(sku, name, price, size, "Cotton")
    {
    }

    /// <summary>
    /// Создаёт футболку с указанными характеристиками
    /// и материалом.
    /// </summary>
    /// <param name="sku">Артикул футболки.</param>
    /// <param name="name">Название футболки.</param>
    /// <param name="price">Цена футболки.</param>
    /// <param name="size">Размер футболки.</param>
    /// <param name="fabric">Материал футболки.</param>
    public TShirt(
        string sku,
        string name,
        decimal price,
        string size,
        string fabric)
        : base(sku, name, price)
    {
        Size = size;
        _fabric = fabric;
    }

    /// <summary>
    /// Выводит сообщение о том, что футболку носят.
    /// </summary>
    public override void Wear()
    {
        Console.WriteLine($"{Name} worn.");
    }

    /// <summary>
    /// Возвращает строковое представление футболки
    /// с её основными характеристиками.
    /// </summary>
    /// <returns>Строка с информацией о футболке.</returns>
    public override string ToString()
    {
        return $"[TShirt] {Name}, {Price}, season: {Season}, " +
               $"size: {Size}, fabric: {_fabric}";
    }
}