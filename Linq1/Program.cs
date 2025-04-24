using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //OddNumbers(numbers);

            UniversityManager universityManager = new UniversityManager();
            universityManager.MalesStudents();
            universityManager.FemaleStudents();

            Console.ReadKey();            
        }

        static void OddNumbers(int[] numbers)
        {
            Console.WriteLine("Odd Numbers: ");

            IEnumerable<int> oddNumbers = from number in numbers where number % 2 != 0 select number;

            Console.WriteLine(oddNumbers);
            foreach (int item in oddNumbers)
            {
                Console.WriteLine(item);
            }
        }
    }

    class UniversityManager
    {
        public List<University> listUniversities;
        public List<Student> listStudents;

        public UniversityManager()
        {
            listUniversities = new List<University>();
            listStudents = new List<Student>();

            // Let´s add University
            listUniversities.Add(new University { Id = 1, Name = "Yale" });
            listUniversities.Add(new University { Id = 2, Name = "Baijing Tach" });

            // Let´s add some Students
            listStudents.Add(new Student { Id = 1, Name = "Carla", Gender = "female", Age = 17, University = 1 });
            listStudents.Add(new Student { Id = 2, Name = "Toni", Gender = "male", Age = 21, University = 1 });
            listStudents.Add(new Student { Id = 2, Name = "Frank", Gender = "male", Age = 22, University = 2 });
            listStudents.Add(new Student { Id = 3, Name = "Leyla", Gender = "female", Age = 19, University = 2 });
            listStudents.Add(new Student { Id = 4, Name = "James", Gender = "trans-gender", Age = 25, University = 2 });
            listStudents.Add(new Student { Id = 5, Name = "linda", Gender = "female", Age = 22, University = 2 });
        }

        public void MalesStudents()
        {
            IEnumerable<Student> maleStudents = from student in listStudents where student.Gender == "male" select student;
            Console.WriteLine("Male - Student: ");
            foreach (Student item in maleStudents)
            {
                item.Print();               
            }
        }   

        public void FemaleStudents()
        {
            IEnumerable<Student> femaleStudents = from student in listStudents where student.Gender == "female" select student;
            Console.WriteLine("Female - Student");
            foreach (Student item in femaleStudents)
            {
                item.Print();
            }
        }
    }


    class University
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Print()
        {
            Console.WriteLine("University {0} with id {1}", Name, Id);
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        // Foreign Key
        public int University { get; set; }

        public void Print()
        {
            Console.WriteLine("Student {0} with Id {1}, Gender (2) and Age{3} from University with the Id {4} ", Name, Id, Gender, Age, University);
        }
    }

}
