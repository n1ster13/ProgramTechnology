
public class Jacket : Clothing, IWashable
{
    private readonly string _zipperType;

  
    public int Insulation { get; set; }


    public bool IsWarm => Insulation >= 2;


    public Jacket(
        string sku,
        string name,
        decimal price,
        int insulation)
        : this(sku, name, price, insulation, "Standard")
    {
    }

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

    public override void Wear()
    {
        Console.WriteLine($"{Name} worn.");
    }


    public void Wash()
    {
        Console.WriteLine($"{Name} washed.");
    }

    public override string ToString()
    {
        return $"[Jacket] {Name}, {Price}, season: {Season}, " +
               $"insulation: {Insulation}, zipper: {_zipperType}";
    }
}