namespace ListyIterator
{
    public class StartUp
    {
        public static void Main()
        {
            ListyIterator<string> listyIterator = null;

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = args[0];

                if (command == "Create")
                {
                    listyIterator = new ListyIterator<string>(args.Skip(1).ToArray());
                }
                else if (command == "Move")
                {
                    Console.WriteLine(listyIterator.Move());
                }
                else if (command == "Print")
                {
                    listyIterator.Print();
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(listyIterator.HasNext());
                }
                else if (command == "PrintAll")
                {
                    Console.WriteLine(string.Join(" ", listyIterator));
                }
            }
        }
    }
}