public abstract class Clothing
{
    private readonly string _sku;

    public string Sku => _sku;

    public string Name { get; set;)
    public decimal Price { get; set; }

    public Season Season { get; set; } = Season.AllSeason;

    public decimal PriceWithDiscount => Price * 0.9m;

    public Clothing(string sku, string name, decimal price)
    {
        _sku = sku;
        Name = name;
        Price = price;
    }

    public Clothing(string name) : this("N/A", name, 0m)
    {
    }

    public abstract void Wear();
}