
public class Shoes : Clothing
{
    private readonly string _material;


    public decimal SoleThickness { get; set; }

    public bool IsSporty => SoleThickness <= 2.0m;

    public Shoes(
        string sku,
        string name,
        decimal price,
        decimal soleThickness)
        : this(sku, name, price, soleThickness, "Synthetic")
    {
    }


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

    public override void Wear()
    {
        Console.WriteLine($"{Name} worn.");
    }

    public override string ToString()
    {
        return $"[Shoes] {Name}, {Price}, season: {Season}, " +
               $"sole: {SoleThickness} cm, material: {_material}";
    }
}