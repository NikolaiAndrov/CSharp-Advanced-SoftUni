namespace SkiRental
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SkiRental skiRental = new SkiRental("New Alpine ski rental", 5);

            Ski firstSkiSet = new Ski("Rossignol", "XC70", 2017);

            Console.WriteLine(firstSkiSet); 

            skiRental.Add(firstSkiSet);

            Console.WriteLine(skiRental.Remove("Rossignol", "XC90")); 
            Console.WriteLine(skiRental.Remove("Rossignol", "XC70")); 

            Ski secondSkiSet = new Ski("Fischer", "SpeedMax", 2018);
            Ski thirdSkiSet = new Ski("Salomon", "TopLine", 2020);

            skiRental.Add(secondSkiSet);
            skiRental.Add(thirdSkiSet);

            Ski newestSki = skiRental.GetNewestSki();
            Console.WriteLine(newestSki); 

            Ski salomonTopLine = skiRental.GetSki("Salomon", "TopLine");
            Console.WriteLine(salomonTopLine); 

            Console.WriteLine(skiRental.Count);

            Console.WriteLine(skiRental.GetStatistics());
        }
    }
}
