using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        private int capacity;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int Count
        {
            get { return students.Count; }
        }

        public string RegisterStudent(Student student)
        {
            if (students.Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (student != null)
            {
                students.Remove(student);
                return $"Dismissed student {student.FirstName} {student.LastName}";
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> studentsToReturn = new List<Student>();
            
            foreach (Student student in students)
            {
                if (student.Subject == subject)
                {
                    studentsToReturn.Add(student);
                }
            }

            if (studentsToReturn.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");

                foreach (Student student in studentsToReturn)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return sb.ToString().TrimEnd();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            return student;
        }
    }
}
