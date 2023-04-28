namespace GenericBoxOfString
{
    public class StartUp
    {
        public static void Main()
        {
            Box<string> box = new Box<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                box.Add(input);
            }

            int graterElements = box.Compare(Console.ReadLine());

            Console.WriteLine(graterElements);
        }
    }
}