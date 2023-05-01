namespace Stack
{
    public class StartUp
    {
        public static void Main()
        {
            CustomStack<string> stack = new CustomStack<string>();

            string input;
            
            while ((input = Console.ReadLine()) != "END")
            {
                var args = input.Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
                var command = args[0];

                if (command == "Push")
                {
                    stack.Push(args.Skip(1).ToArray());
                }
                else if (command == "Pop")
                {
                    stack.Pop();
                }
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}