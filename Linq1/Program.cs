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
            universityManager.SortStudentByAge();
            universityManager.AllStudentsFromBeijingTech();

            universityManager.StudentAndUniversityNameColletction();

            //int[] someInts = { 30, 12, 4, 3, 12 };
            //IEnumerable<int> sortedInts2 = from i in someInts orderby i select i;
            //IEnumerable<int> reversedInts = sortedInts2.Reverse();

            //foreach (int i in reversedInts)
            //{
            //    Console.WriteLine(i);
            //}

            //IEnumerable<int> reversedSprtedInts = from i in someInts orderby i descending select i;
            //foreach (int i in reversedSprtedInts)
            //{
            //    Console.WriteLine(i);
            //}

            Console.WriteLine("Insira o ID of university ");
            int imputAsInt = Convert.ToInt32(Console.ReadLine());
            try
            {
                universityManager.AllStudentsFromThatUni(imputAsInt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wrong value!! Error {0}",ex.ToString());
            }            

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
            listUniversities.Add(new University { Id = 2, Name = "Beijing Tech" });

            // Let´s add some Students
            listStudents.Add(new Student { Id = 1, Name = "Carla", Gender = "female", Age = 17, UniversityId = 1 });
            listStudents.Add(new Student { Id = 2, Name = "Toni", Gender = "male", Age = 21, UniversityId = 1 });
            listStudents.Add(new Student { Id = 2, Name = "Frank", Gender = "male", Age = 22, UniversityId = 2 });
            listStudents.Add(new Student { Id = 3, Name = "Leyla", Gender = "female", Age = 19, UniversityId = 2 });
            listStudents.Add(new Student { Id = 4, Name = "James", Gender = "trans-gender", Age = 25, UniversityId = 2 });
            listStudents.Add(new Student { Id = 5, Name = "linda", Gender = "female", Age = 22, UniversityId = 2 });
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

        public void SortStudentByAge()
        {
            var sortedStudents = from students in listStudents 
                                 orderby students.Age 
                                 select students;
            Console.WriteLine("Sorted students by Age");
            foreach (Student item in sortedStudents)
            {
                item.Print();
            }
        }


        public void AllStudentsFromBeijingTech()
        {
            IEnumerable<Student> bjtStudents = from student in listStudents
                                               join university in listUniversities on student.UniversityId equals university.Id
                                               where university.Name == "Beijing Tech"
                                               select student;

            Console.WriteLine("Students from Beijing Tech");
            foreach (Student item in bjtStudents)
            {
                item.Print();
            }
        }

        public void AllStudentsFromThatUni(int id)
        {
            IEnumerable<Student> bjtStudents = from student in listStudents
                                               join university in listUniversities on student.UniversityId equals university.Id
                                               where university.Id == id
                                               select student;

            Console.WriteLine("Students from that uni {0}",id);
            foreach (Student item in bjtStudents)
            {
                item.Print();
            }
        }


        public void StudentAndUniversityNameColletction()
        {
            var newCollection = from student in listStudents
                                join university in listUniversities on student.UniversityId equals university.Id
                                orderby student.Name
                                select new { StudentName = student.Name, UniversityName = university.Name };

            Console.WriteLine("New Collection: ");

            foreach (var item in newCollection)
            {
                Console.WriteLine("Student {0} from University {1}", item.StudentName, item.UniversityName);
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
        public int UniversityId { get; set; }

        public void Print()
        {
            Console.WriteLine("Student: {0} with Id: {1}, Gender: {2} and Age: {3} from University with the Id: {4} ", Name, Id, Gender, Age, UniversityId);
        }
    }

}
