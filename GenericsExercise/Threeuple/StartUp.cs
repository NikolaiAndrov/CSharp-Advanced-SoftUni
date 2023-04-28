namespace Threeuple
{
    public class StartUp
    {
        public static void Main()
        {
            string[] nameAndAdress = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string fullName = $"{nameAndAdress[0]} {nameAndAdress[1]}";
            string street = nameAndAdress[2];
            string city = string.Join(" ", nameAndAdress.Skip(3));
            var nameAdress = new MyThreeuple<string, string, string>(fullName, street, city);

            string[] nameBeer = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = nameBeer[0];
            int beer = int.Parse(nameBeer[1]);
            string condition = nameBeer[2];
            bool isDrunk = false;

            if (condition == "drunk")
            {
                isDrunk = true;
            }

            var nameCondition = new MyThreeuple<string, int, bool>(name, beer, isDrunk);

            string[] nameBankInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string finalName = nameBankInfo[0];
            double balance = double.Parse(nameBankInfo[1]);
            string bank = nameBankInfo[2];
            var nameBank = new MyThreeuple<string, double, string>(finalName, balance, bank);

            Console.WriteLine(nameAdress);
            Console.WriteLine(nameCondition);
            Console.WriteLine(nameBank);
        }
    }
}