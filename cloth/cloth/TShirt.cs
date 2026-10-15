public class TShirt : Clothing
{
    private readonly string _fabric;

    public string Size { get; set; }


    public bool IsBigSize =>
        Size == "XL" || Size == "XXL" || Size == "XXXL";

    public TShirt(
        string sku,
        string name,
        decimal price,
        string size)
        : this(sku, name, price, size, "Cotton")
    {
    }


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

    public override void Wear()
    {
        Console.WriteLine($"{Name} worn.");
    }

    public override string ToString()
    {
        return $"[TShirt] {Name}, {Price}, season: {Season}, " +
               $"size: {Size}, fabric: {_fabric}";
    }
}