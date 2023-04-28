namespace Tuple
{
    public class StartUp
    {
        public static void Main()
        {
            string[] fullNameAndCity = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string fullName = fullNameAndCity[0] + " " + fullNameAndCity[1];
            string city = fullNameAndCity[2];
            MyTuple<string, string> nameCity = new MyTuple<string, string>(fullName, city);

            string[] NameAndBeer = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = NameAndBeer[0];
            int beer = int.Parse(NameAndBeer[1]);
            MyTuple<string, int> nameBeer = new MyTuple<string, int>(name, beer);

            string[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int integerN = int.Parse(nums[0]);
            double doubleN = double.Parse(nums[1]);
            MyTuple<int, double> numsN = new MyTuple<int, double>(integerN, doubleN);

            Console.WriteLine(nameCity);
            Console.WriteLine(nameBeer);
            Console.WriteLine(numsN);
        }
    }
}