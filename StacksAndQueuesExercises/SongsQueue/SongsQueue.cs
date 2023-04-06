public class SongsQueue
{
    public static void Main()
    {
        string[] inputSongs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
        Queue<string> songs = new Queue<string>(inputSongs);

        while (songs.Count > 0)
        {
            string[] commandInfo = Console.ReadLine().Split(" ", 2);
            string command = commandInfo[0];

            if (command == "Play")
            {
                songs.Dequeue();
            }
            else if (command == "Add")
            {
                string song = commandInfo[1];

                if (songs.Contains(song))
                {
                    Console.WriteLine($"{song} is already contained!");
                    continue;
                }

                songs.Enqueue(song);
            }
            else if (command == "Show")
            {
                Console.WriteLine(string.Join(", ", songs));
            }
        }

        Console.WriteLine("No more songs!");
    }
}