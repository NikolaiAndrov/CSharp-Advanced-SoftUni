public class ReverseAString
{
    public static void Main()
    {
        var inputString = Console.ReadLine();
        var reversedString = new Stack<char>();

        foreach (var ch in inputString)
        {
            reversedString.Push(ch);
        }

        while (reversedString.Count > 0)
        {
            Console.Write(reversedString.Pop());
        }
    }
}