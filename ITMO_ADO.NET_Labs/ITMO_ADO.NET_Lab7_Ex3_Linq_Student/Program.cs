using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMO_ADO.NET_Lab7_Ex3_Linq_Student
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Student> studentQuery = from student in students
                                                where student.Scores[0] > 90 && student.Scores[3] < 80
                                                //orderby student.Last ascending
                                                orderby student.Scores[0] descending
                                                select student;

            var studentQuery2 = from student in students group student by student.Last[0];

            var studentQuery3 = from student in students group student by student.Last[0];

            var studentQuery4 = from student in students group student by student.Last[0] into studentGroup
                                orderby studentGroup.Key
                                select studentGroup;

            var studentQuery5 = from student in students
                                let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                                where totalScore / 4 < student.Scores[0]
                                select student.Last + " " + student.First;

            var studentQuery6 = from student in students
                                let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                                select totalScore;
            double avScore = studentQuery6.Average();
            Console.WriteLine("class average score = {0}", avScore + Environment.NewLine);

            IEnumerable<string> studentQuery7 = from student in students
                                                where student.Last == "Garcia"
                                                select student.First;
            IEnumerable<string> studentQuery8 = from student in students
                                                where student.Last == "Peterson"
                                                select student.First;

            var studentQuery9 = from student in students
                                let x = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                                where x > avScore
                                select new { id = student.ID, score = x };


            foreach (var studentGroop in studentQuery2)
            {
                Console.WriteLine(studentGroop.Key);
                foreach (Student student in studentQuery)
                {
                    Console.WriteLine("{0},{1}", student.Last, student.First);
                }
            }

            foreach (var groupOfStudents in studentQuery3)
            {
                Console.WriteLine(groupOfStudents.Key);
                foreach (var student in groupOfStudents)
                {
                    Console.WriteLine("   {0}, {1}",
                        student.Last, student.First);
                }
            }
            foreach (var groupOfStudents in studentQuery4)
            {
                Console.WriteLine(groupOfStudents.Key);
                foreach (var student in groupOfStudents)
                {
                    Console.WriteLine("   {0}, {1}",
                        student.Last, student.First);
                }
            }
            foreach (string s in studentQuery5)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("The Garcias in the class are:");
            foreach (string student in studentQuery7)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("The Petersons in the class are:");
            foreach (string s in studentQuery8)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine(Environment.NewLine);

            foreach (var item in studentQuery9)
            {
                Console.WriteLine("Student ID: {0}, Score: {1}", item.id, item.score);
            }

        }

        static List<Student> students = new List<Student>
        {
           new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
           new Student {First="Claire", Last="O’Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
           new Student {First="John", Last="O’Reilly", ID=113, Scores= new List<int> {96, 82, 92, 52}},
           new Student {First="Enrique", Last="Garcia", ID=114, Scores= new List<int> {96, 82, 92, 52}},
           new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
           new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
           new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
        };

    }
}