namespace GenericCountMethodDoubles
{
    public class StartUp
    {
        public static void Main()
        {
            Box<double> box = new Box<double>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                box.Add(input);
            }

            int graterElements = box.Compare(double.Parse(Console.ReadLine()));

            Console.WriteLine(graterElements);
        }
    }
}