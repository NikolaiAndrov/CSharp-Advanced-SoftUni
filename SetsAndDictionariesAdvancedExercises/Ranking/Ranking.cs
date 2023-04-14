public class Ranking
{
    public static void Main()
    {
        var contestsAndPasswords = new Dictionary<string, string>();
        SaveContestsAndPasswords(contestsAndPasswords);

        var students = new SortedDictionary<string, Dictionary<string, int>>();
        GetSubmissions(contestsAndPasswords, students);

        GetBestStudent(students);
        PrintStudents(students);
    }

    static void PrintStudents(SortedDictionary<string, Dictionary<string, int>> students)
    {
        Console.WriteLine("Ranking:");
        foreach (var student in students)
        {
            Console.WriteLine(student.Key);

            foreach (var contest in student.Value.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
            }
        }
    }
    static void GetBestStudent(SortedDictionary<string, Dictionary<string, int>> students)
    {
        foreach (var student in students.OrderByDescending(x => x.Value.Values.Sum()))
        {
            Console.WriteLine($"Best candidate is {student.Key} with total {student.Value.Values.Sum()} points.");
            break;
        }
    }
    static void GetSubmissions(Dictionary<string, string> contestsAndPasswords, SortedDictionary<string, Dictionary<string, int>> students)
    {
        string input;

        while ((input = Console.ReadLine()) != "end of submissions")
        {
            var submissionInfo = input.Split("=>");
            var contest = submissionInfo[0];
            var password = submissionInfo[1];
            var student = submissionInfo[2];
            var points = int.Parse(submissionInfo[3]);

            if (contestsAndPasswords.ContainsKey(contest) && contestsAndPasswords[contest] == password)
            {
                if (!students.ContainsKey(student))
                {
                    students[student] = new Dictionary<string, int>();
                }

                if (!students[student].ContainsKey(contest))
                {
                    students[student][contest] = 0;
                }

                if (students[student][contest] < points)
                {
                    students[student][contest] = points;
                }
            }
        }
    }
    static void SaveContestsAndPasswords(Dictionary<string, string> contestsAndPasswords)
    {
        string input;

        while ((input = Console.ReadLine()) != "end of contests")
        {
            var contestInfo = input.Split(":");
            var contest = contestInfo[0];
            var password = contestInfo[1];

            if (!contestsAndPasswords.ContainsKey(contest))
            {
                contestsAndPasswords[contest] = password;
            }
        }
    }
}