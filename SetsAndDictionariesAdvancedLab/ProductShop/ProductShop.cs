public class ProductShop
{
    public static void Main()
    {
        SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();
        AddShops(shops);
        PrintShops(shops);
    }

    static void PrintShops(SortedDictionary<string, Dictionary<string, double>> shops)
    {
        foreach (var shop in shops)
        {
            Console.WriteLine($"{shop.Key}->");

            foreach (var product in shop.Value)
            {
                Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
            }
        }
    }
    static void AddShops(SortedDictionary<string, Dictionary<string, double>> shops)
    {
        string input;

        while ((input = Console.ReadLine()) != "Revision")
        {
            string[] shopInfo = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string shop = shopInfo[0];
            string product = shopInfo[1];
            double price = double.Parse(shopInfo[2]);

            if (!shops.ContainsKey(shop))
            {
                shops[shop] = new Dictionary<string, double>();
            }

            if (!shops[shop].ContainsKey(product))
            {
                shops[shop][product] = 0;
            }

            shops[shop][product] = price;
        }
    }
}