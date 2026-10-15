

public class Program
{
   
    public static void Main()
    {
        List<Clothing> clothes = new List<Clothing>
        {
            new Jacket("J001", "North Face", 25000m, 3),
            new TShirt("T001", "Adidas", 3000m, "XL"),
            new Shoes("S001", "Nike", 8000m, 1.5m)
        };

        foreach (Clothing currentClothing in clothes)
        {
            Console.WriteLine(currentClothing);

            Console.WriteLine(
                $"  price with discount: {currentClothing.PriceWithDiscount:0.##}");

            currentClothing.Wear();

            if (currentClothing is IWashable washable)
            {
                washable.Wash();
            }
            else
            {
                Console.WriteLine(
                    $"{currentClothing.Name} cannot be washed.");
            }

            if (currentClothing is Jacket jacket)
            {
                Console.WriteLine($"  is warm: {jacket.IsWarm}");
            }
            else if (currentClothing is TShirt tShirt)
            {
                Console.WriteLine($"  is big size: {tShirt.IsBigSize}");
            }
            else if (currentClothing is Shoes shoes)
            {
                Console.WriteLine($"  is sporty: {shoes.IsSporty}");
            }

            Console.WriteLine("----------------------------------------");
        }
    }
}