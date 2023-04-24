namespace DateModifier
{
    public class StartUp
    {
        static void Main()
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();
            DateModifier dateModifier = new DateModifier();
            int diff = dateModifier.GetDaysDifference(date1, date2);
            Console.WriteLine(diff);
        }
    }
}