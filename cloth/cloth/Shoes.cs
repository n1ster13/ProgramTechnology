
public class Shoes : Clothing
{

    private readonly string _material;
    public decimal SoleThickness { get; set; }

    /// <summary>
    /// Определяет, является ли обувь спортивной.
    /// Обувь считается спортивной, если толщина подошвы не превышает 2 см.
    /// </summary>
    public bool IsSporty => SoleThickness <= 2.0m;

    /// <summary>
    /// Создаёт обувь с указанным артикулом, названием,
    /// ценой и толщиной подошвы.
    /// Материал по умолчанию синтетический.
    /// </summary>
    /// <param name="sku">Артикул обуви.</param>
    /// <param name="name">Название обуви.</param>
    /// <param name="price">Цена обуви.</param>
    /// <param name="soleThickness">Толщина подошвы в сантиметрах.</param>
    public Shoes(
        string sku,
        string name,
        decimal price,
        decimal soleThickness)
        : this(sku, name, price, soleThickness, "Synthetic")
    {
    }

    /// <summary>
    /// Создаёт обувь с указанными характеристиками и материалом.
    /// </summary>
    /// <param name="sku">Артикул обуви.</param>
    /// <param name="name">Название обуви.</param>
    /// <param name="price">Цена обуви.</param>
    /// <param name="soleThickness">Толщина подошвы в сантиметрах.</param>
    /// <param name="material">Материал обуви.</param>
    public Shoes(
        string sku,
        string name,
        decimal price,
        decimal soleThickness,
        string material)
        : base(sku, name, price)
    {
        SoleThickness = soleThickness;
        _material = material;
    }

    /// <summary>
    /// Выводит сообщение о том, что обувь носят.
    /// </summary>
    public override void Wear()
    {
        Console.WriteLine($"{Name} worn.");
    }

    /// <summary>
    /// Возвращает строковое представление обуви
    /// с её основными характеристиками.
    /// </summary>
     public override string ToString()
    {
        return $"[Shoes] {Name}, {Price}, season: {Season}, " +
               $"sole: {SoleThickness} cm, material: {_material}";
    }
}
