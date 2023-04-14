public class SoftUniExamResults
{
    public static void Main()
    {
        var students = new Dictionary<string, int>();
        var languages = new Dictionary<string, int>();

        string input;

        while ((input = Console.ReadLine()) != "exam finished")
        {
            var examInfo = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
            var student = examInfo[0];
            var command = examInfo[1];

            if (command == "banned")
            {
                if (students.ContainsKey(student))
                {
                    students.Remove(student);
                }

                continue;
            }

            var language = command;
            var points = int.Parse(examInfo[2]);

            if (!students.ContainsKey(student))
            {
                students[student] = 0;
            }

            if (students[student] < points)
            {
                students[student] = points;
            }

            if (!languages.ContainsKey(language))
            {
                languages[language] = 0;
            }

            languages[language]++;
        }

        PrintStudentsAndPoints(students);
        PrintLanguages(languages);
    }

    static void PrintLanguages(Dictionary<string, int> languages)
    {
        languages = languages.OrderByDescending(p => p.Value)
            .ThenBy(l => l.Key)
            .ToDictionary(l => l.Key, p => p.Value);

        Console.WriteLine("Submissions:");

        foreach (var language in languages)
        {
            Console.WriteLine($"{language.Key} - {language.Value}");
        }
    }
    static void PrintStudentsAndPoints(Dictionary<string, int> students)
    {
        students = students.OrderByDescending(x => x.Value)
            .ThenBy(x => x.Key)
            .ToDictionary(s => s.Key, p => p.Value);

        Console.WriteLine("Results:");

        foreach ( var student in students)
        {
            Console.WriteLine($"{student.Key} | {student.Value}");
        } 
    }
}