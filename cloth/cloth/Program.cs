public class Program
{
    /// <summary>
    /// Главный метод программы, с которого начинается выполнение.
    /// Создаёт список одежды и выводит информацию о каждом предмете.
    /// </summary>
    public static void Main()
    {
        List<Clothing> clothes = new List<Clothing>
        {
            new Jacket("J001", "North Face", 25000m, 3),
            new TShirt("T001", "Adidas", 3000m, "XL"),
            new Shoes("S001", "Nike", 8000m, 1.5m)
        };

        /// Перебираем все предметы одежды в списке.
        foreach (Clothing currentClothing in clothes)
        {
            // Выводим информацию о текущем предмете одежды.
            Console.WriteLine(currentClothing);

            // Выводим цену со скидкой.
            Console.WriteLine(
                $"  price with discount: {currentClothing.PriceWithDiscount:0.##}");

            // Вызываем метод ношения одежды.
            currentClothing.Wear();

            // Проверяем, можно ли стирать этот предмет одежды.
            if (currentClothing is IWashable washable)
            {
                washable.Wash();
            }
            else
            {
                Console.WriteLine(
                    $"{currentClothing.Name} cannot be washed.");
            }

            // Проверяем тип одежды и выводим дополнительные характеристики.
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

            // Выводим разделительную линию.
            Console.WriteLine("----------------------------------------");
        }
    }
}
