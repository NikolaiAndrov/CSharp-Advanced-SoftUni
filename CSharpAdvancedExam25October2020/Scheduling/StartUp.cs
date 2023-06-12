namespace Scheduling
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int taskToKill = int.Parse(Console.ReadLine());

            while (tasks.Count > 0 && threads.Count > 0)
            {
                int currentThread = threads.Peek();
                int currentTask = tasks.Peek();

                if (currentTask == taskToKill)
                {
                    Console.WriteLine($"Thread with value {currentThread} killed task {currentTask}");
                    break;
                }
                else if (currentThread >= currentTask)
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else if (currentTask > currentThread)
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
