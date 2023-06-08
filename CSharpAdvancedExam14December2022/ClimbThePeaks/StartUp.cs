namespace ClimbThePeaks
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Stack<int> dailyFood = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> dailyStamina = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));

            Queue<int> peaksDifficulty = new Queue<int>(new int[] {80, 90, 100, 60, 70});
            List<string> peaksClimbed = new List<string>();
            bool isDone = false;

            while (dailyFood.Count > 0 && dailyStamina.Count > 0)
            {
                int currentFood = dailyFood.Pop();
                int currentStamina = dailyStamina.Dequeue();
                int power = currentFood + currentStamina;

                int currentPeakDifficulty = peaksDifficulty.Peek();

                if (power >= currentPeakDifficulty 
                    && currentPeakDifficulty == 80)
                {
                    peaksClimbed.Add("Vihren");
                    peaksDifficulty.Dequeue();
                }
                else if (power >= currentPeakDifficulty 
                    && currentPeakDifficulty == 90)
                {
                    peaksClimbed.Add("Kutelo");
                    peaksDifficulty.Dequeue();
                }
                else if(power >= currentPeakDifficulty
                    && currentPeakDifficulty == 100)
                {
                    peaksClimbed.Add("Banski Suhodol");
                    peaksDifficulty.Dequeue();
                }
                else if (power >= currentPeakDifficulty
                    && currentPeakDifficulty == 60)
                {
                    peaksClimbed.Add("Polezhan");
                    peaksDifficulty.Dequeue();
                }
                else if (power >= currentPeakDifficulty
                    && currentPeakDifficulty == 70)
                {
                    peaksClimbed.Add("Kamenitza");
                    peaksDifficulty.Dequeue();
                }

                if (peaksDifficulty.Count == 0)
                {
                    isDone = true;
                    break;
                }
            }

            if (isDone)
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            }
            else
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }

            if (peaksClimbed.Count > 0)
            {
                Console.WriteLine("Conquered peaks:");

                foreach (var peek in peaksClimbed)
                {
                    Console.WriteLine(peek);
                }
            }
            
        }
    }
}