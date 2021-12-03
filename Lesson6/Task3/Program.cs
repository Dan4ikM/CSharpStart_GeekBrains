using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// 3. Переделать программу Пример использования коллекций для решения следующих задач:
    /// а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
    /// б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(*частотный массив);
    /// в) отсортировать список по возрасту студента;
    /// г) * отсортировать список по курсу и возрасту студента;
    /// </summary>
    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;
        int age;
        public int Age => age;
        // Создаем конструктор
        public Student(string firstName, string lastName, string university, string faculty, string department,  int age, int course, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.age = age;
            this.course = course;
            this.group = group;
            this.city = city;
        }

        public override string ToString()
        {
            return $"{firstName} {lastName} {university} {faculty} {department} {age} {course} {group} {city}";  
        }
    }
    class Program
    {
        static int MyDelegat(Student st1, Student st2)          // Создаем метод для сравнения для экземпляров
        {
            return String.Compare(st1.firstName, st2.firstName);          // Сравниваем две строки
        }
        static void Main(string[] args)
        {
            int bakalavr = 0;
            int magistr = 0;
            List<Student> list = new List<Student>();                             // Создаем список студентов
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("students.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    // Добавляем в список новый экземпляр класса Student
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    // Одновременно подсчитываем количество бакалавров и магистров
                    if (int.Parse(s[5]) < 5) bakalavr++; else magistr++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
            list.Sort(new Comparison<Student>(MyDelegat));
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine("Магистров:{0}", magistr);
            Console.WriteLine("Бакалавров:{0}", bakalavr);
            foreach (var v in list) Console.WriteLine(v.firstName);
            Console.WriteLine(DateTime.Now - dt);
            // а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
            NumberOfStudentInCourse(list, 5);
            NumberOfStudentInCourse(list, 6);

            // б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(*частотный массив);
            int[] studCourseCounter = new int[6];
            IEnumerable<int> courseNumbers = list.Where(student => student.Age < 21 && student.Age > 17).Select(student => student.course);
            foreach (int course in courseNumbers)
            {
                studCourseCounter[course - 1]++;
            }
            for (int course = 0; course < studCourseCounter.Length; course++)
            {
                if (studCourseCounter[course] != 0)
                    Console.WriteLine("На {0} курсе {1} студентов возрастом от 18 до 20",course+1, studCourseCounter[course]);
            }
            Console.WriteLine();

            // в) отсортировать список по возрасту студента;
            list.Sort(new Comparison<Student>((stud1, stud2) => stud1.Age < stud2.Age ? -1 : 1));

            foreach (var student in list)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            // г) * отсортировать список по курсу и возрасту студента;
            IEnumerable<Student> listSortByCourseAndAge = list.OrderBy(student => student.course).ThenBy(student => student.Age);

            foreach (var student in listSortByCourseAndAge)
            {
                Console.WriteLine(student);
            }

            Console.ReadKey();
        }

        static void NumberOfStudentInCourse(List<Student> list, int course)
        {
            Console.WriteLine("Курс {0} - количество студентов:{1}",course ,list.FindAll(student => student.course == course).Count);
        }
    }

}
