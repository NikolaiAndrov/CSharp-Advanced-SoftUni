namespace TempleOfDoom
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Queue<int> tools = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> substances = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            List<int> challenges = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (tools.Count > 0 && substances.Count > 0)
            {
                int currentTool = tools.Dequeue();
                int currentSubstance = substances.Pop();
                int result = currentTool * currentSubstance;

                if (challenges.Contains(result))
                {
                    challenges.Remove(result);

                    if (challenges.Count == 0)
                    {
                        break;
                    }

                    continue;
                }

                currentTool += 1;
                tools.Enqueue(currentTool);

                currentSubstance -= 1;

                if (currentSubstance > 0)
                {
                    substances.Push(currentSubstance);
                }
            }

            if (challenges.Count == 0)
            {
                Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
            }
            else
            {
                Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
            }

            if (tools.Count > 0)
            {
                Console.WriteLine($"Tools: {string.Join(", ", tools)}");
            }

            if (substances.Count > 0)
            {
                Console.WriteLine($"Substances: {string.Join(", ", substances)}");
            }

            if (challenges.Count > 0)
            {
                Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
            }
        }
    }
}