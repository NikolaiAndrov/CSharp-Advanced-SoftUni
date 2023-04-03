public class MatchingBrackets
{
    public static void Main()
    {
        var expression = Console.ReadLine();
        var openBracketIndexes = new Stack<int>();

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                openBracketIndexes.Push(i);
            }
            else if (expression[i] == ')')
            {
                var startIndex = openBracketIndexes.Pop();
                var len = i - startIndex + 1;
                var currentExpression = expression.Substring(startIndex, len);
                Console.WriteLine(currentExpression);
            }
        }
    }
}