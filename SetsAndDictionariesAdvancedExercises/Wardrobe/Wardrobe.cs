public class Wardrobe
{
    public static void Main()
    {
        var clothes = new Dictionary<string, Dictionary<string, int>>();
        AddClothes(clothes);
        PrintClothes(clothes);
    }

    static void PrintClothes(Dictionary<string, Dictionary<string, int>> clothes)
    {
        var searchedType = Console.ReadLine().Split();
        var searchedColor = searchedType[0];
        var SearchedClothe = searchedType[1];

        foreach ( var color in clothes)
        {
            Console.WriteLine($"{color.Key} clothes:");

            foreach (var clothe in color.Value)
            {
                if (color.Key == searchedColor && clothe.Key == SearchedClothe)
                {
                    Console.WriteLine($"* {clothe.Key} - {clothe.Value} (found!)");
                    continue;
                }

                Console.WriteLine($"* {clothe.Key} - {clothe.Value}");
            }
        }
    }
    static void AddClothes(Dictionary<string, Dictionary<string, int>> clothes)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var args = Console.ReadLine().Split(" -> ");
            var color = args[0];
            var clotheType = args[1].Split(",");

            if (!clothes.ContainsKey(color))
            {
                clothes[color] = new Dictionary<string, int>();
            }

            foreach (var clothe in clotheType)
            {
                if (!clothes[color].ContainsKey(clothe))
                {
                    clothes[color][clothe] = 0;
                }
                clothes[color][clothe]++;
            }
        }
    }
}