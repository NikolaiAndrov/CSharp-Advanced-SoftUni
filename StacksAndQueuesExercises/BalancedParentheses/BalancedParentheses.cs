public class BalancedParentheses
{
    public static void Main()
    {
        string parentheses = Console.ReadLine();
        Stack<char> openParentheses = new Stack<char>();
        bool flag = true;

        foreach (char ch in parentheses)
        {
            if (ch == '(' ||
                ch == '{' ||
                ch == '[')
            {
                openParentheses.Push(ch);
                continue;
            }

            if (openParentheses.Any() && ch == ')' && openParentheses.Peek() == '(')
            {
                openParentheses.Pop();
            }
            else if (openParentheses.Any() && ch == '}' && openParentheses.Peek() == '{')
            {
                openParentheses.Pop();
            }
            else if (openParentheses.Any() && ch == ']' && openParentheses.Peek() == '[')
            {
                openParentheses.Pop();
            }
            else
            {
                flag = false;
                break;
            }
        }

        if (flag && openParentheses.Count == 0)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}