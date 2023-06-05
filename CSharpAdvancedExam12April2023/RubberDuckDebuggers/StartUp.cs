namespace RubberDuckDebuggers
{
    public class StartUp
    {
        public static void Main()
        {
            Queue<int> programmersTime = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> programmersTasks = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            Dictionary<string, int> rubberDuckys = new Dictionary<string, int>
            {
                {"Darth Vader Ducky", 0 },
                {"Thor Ducky", 0 },
                {"Big Blue Rubber Ducky", 0 },
                {"Small Yellow Rubber Ducky", 0 }
            };

            while (programmersTime.Count > 0 && programmersTasks.Count > 0)
            {
                int currentTime = programmersTime.Dequeue();
                int currentTask = programmersTasks.Pop();
                int value = currentTime * currentTask;

                if (value >= 0 && value <= 60)
                {
                    rubberDuckys["Darth Vader Ducky"]++;
                }
                else if (value >= 61 && value <= 120)
                {
                    rubberDuckys["Thor Ducky"]++;
                }
                else if (value >= 121 && value <= 180)
                {
                    rubberDuckys["Big Blue Rubber Ducky"]++;
                }
                else if (value >= 181 && value <= 240)
                {
                    rubberDuckys["Small Yellow Rubber Ducky"]++;
                }
                else
                {
                    programmersTime.Enqueue(currentTime);
                    programmersTasks.Push(currentTask - 2);
                }
            }

            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            foreach (var ducky in rubberDuckys)
            {
                Console.WriteLine($"{ducky.Key}: {ducky.Value}");
            }
        }
    }
}