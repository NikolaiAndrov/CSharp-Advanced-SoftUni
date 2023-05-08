using System;

namespace FishingNet
{
    public class StartUp
    {
        public static void Main()
        {
            Net net = new Net("cast net", 10);

            Fish fishOne = new Fish("salmon", 44.25, 941.15);
            Fish fishTwo = new Fish("catfish", 105.25, 2100.15);
            Fish fishThree = new Fish("bass", 25.25, 321.15);

            Console.WriteLine(net.AddFish(fishOne));  
            Console.WriteLine(net.AddFish(fishTwo));  
            Console.WriteLine(net.AddFish(fishThree));
            Console.WriteLine(net.Count);

            foreach (var fish in net.Fish)
            {
                Console.WriteLine(fish.ToString());
            }

            Console.WriteLine(net.ReleaseFish(321.15));
            Console.WriteLine(net.Count);

            Fish fishFour = new Fish("mullet", 15.21, 150.33);
            Fish fishFive = new Fish("barbel", 21.33, 190.14);
            Fish fishSix = new Fish("trout", 38.35, 357.41);

            Console.WriteLine(net.AddFish(fishFour));
            Console.WriteLine(net.AddFish(fishFive));
            Console.WriteLine(net.AddFish(fishSix));

            Console.WriteLine(net.GetFish("trout"));

            Console.WriteLine(net.GetBiggestFish());

            Console.WriteLine("----------------------Report----------------------");
            Console.WriteLine(net.Report());

        }
    }
}
