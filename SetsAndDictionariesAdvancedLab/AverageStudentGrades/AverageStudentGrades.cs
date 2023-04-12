public class AverageStudentGrades
{
    public static void Main()
    {
        Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();
        AddStudents(students);
        PrintStudents(students);
    }

    static void PrintStudents(Dictionary<string, List<decimal>> students)
    {
        foreach (var student in students)
        {
            Console.Write($"{student.Key} -> ");

            foreach (var grade in student.Value)
            {
                Console.Write($"{grade:f2} ");
            }

            Console.WriteLine($"(avg: {student.Value.Average():f2})");
        }
    }
    static void AddStudents(Dictionary<string, List<decimal>> students)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] studentInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string studentName = studentInfo[0];
            decimal grade = decimal.Parse(studentInfo[1]);

            if (!students.ContainsKey(studentName))
            {
                students[studentName] = new List<decimal>();
            }
            students[studentName].Add(grade);
        }
    }
}