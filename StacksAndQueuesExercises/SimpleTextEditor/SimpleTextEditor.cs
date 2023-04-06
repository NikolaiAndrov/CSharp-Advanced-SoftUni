public class SimpleTextEditor
{
    public static void Main()
    {
        int commandsCount = int.Parse(Console.ReadLine());
        string text = string.Empty;
        Stack<string> previousState = new Stack<string>();

        for (int i = 0; i < commandsCount; i++)
        {
            string[] commandInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = commandInfo[0];

            if (command == "1")
            {
                previousState.Push(text);
                text += commandInfo[1];
            }
            else if (command == "2")
            {
                previousState.Push(text);
                int count = int.Parse(commandInfo[1]);

                if (count > text.Length)
                {
                    count = text.Length;
                }

                text = text.Substring(0, text.Length - count);
            }
            else if (command == "3")
            {
                int index = int.Parse(commandInfo[1]) - 1;

                if (index >= 0 && index < text.Length)
                {
                    Console.WriteLine(text[index]);
                }
            }
            else if (command == "4")
            {
                if (previousState.Count > 0)
                {
                    text = previousState.Pop();
                }
            }
        }
    }
}