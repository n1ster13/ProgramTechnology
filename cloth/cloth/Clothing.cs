public abstract class Clothing
{
    /// <summary>
    /// Артикул одежды. Не изменяется после создания объекта.
    /// </summary>
    private readonly string _sku;

    /// <summary>
    /// Возвращает артикул одежды.
    /// </summary>
    public string Sku => _sku;
    public string Name { get; set; }
    public decimal Price { get; set; }

    /// <summary>
    /// Сезон, для которого предназначена одежда.
    /// По умолчанию — всесезонная одежда.
    /// </summary>
    public Season Season { get; set; } = Season.AllSeason;

    /// <summary>
    /// Возвращает цену одежды со скидкой 10%.
    /// </summary>
    public decimal PriceWithDiscount => Price * 0.9m;

    /// <summary>
    /// Создаёт объект одежды с указанным артикулом,
    /// названием и ценой.
    /// </summary>
    /// <param name="sku">Артикул одежды.</param>
    /// <param name="name">Название одежды.</param>
    /// <param name="price">Цена одежды.</param>
    public Clothing(string sku, string name, decimal price)
    {
        _sku = sku;
        Name = name;
        Price = price;
    }

    /// <summary>
    /// Создаёт объект одежды только по названию.
    /// </summary>
    /// <param name="name">Название одежды.</param>
    public Clothing(string name) : this("N/A", name, 0m)
    {
    }

    /// <summary>
    /// Абстрактный метод, описывающий ношение одежды.
    /// Реализация определяется в других классах.
    /// </summary>
    public abstract void Wear();
}
