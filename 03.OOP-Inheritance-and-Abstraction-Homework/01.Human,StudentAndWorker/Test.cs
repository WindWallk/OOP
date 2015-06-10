using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HumanStudentWorker.Models;

namespace _01.Human_StudentAndWorker
{
    class Test
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Students:");
                List<Student> students = new List<Student>
                {
                    new Student("Ivan", "Ivanov", "fn126512"),
                    new Student("Georgi", "Ivanov", "fn23612"),
                    new Student("Georgi", "Georgiev", "fn12412"),
                    new Student("Aleksandar", "Garov", "fn001242"),
                    new Student("Petur", "Petorv", "fn184512"),
                    new Student("Goshko", "Goshkov", "fn100512"),
                    new Student("Pesho", "Peshev", "fn12600212"),
                    new Student("Teodor", "Ivanov", "fn12634512"),
                    new Student("Stamat", "Ivanov", "fn12651512"),
                    new Student("Mariika", "Ivanova", "fn126002")
                };

                var sortStudents =
                    from student in students
                    orderby student.FacultyNumber
                    select student;

                foreach (var student in sortStudents)
                {
                    Console.WriteLine(student);
                }

                Console.WriteLine("Workers:");

                List<Worker> workers = new List<Worker>
                {
                    new Worker("Ivan", "Ivanov", 8, 512m),
                    new Worker("Georgi", "Ivanov", 10, 999m),
                    new Worker("Georgi", "Georgiev", 4, 330m),
                    new Worker("Aleksandar", "Garov", 11, 1100m),
                    new Worker("Petur", "Petorv", 6, 650m),
                    new Worker("Goshko", "Goshkov", 8, 660m),
                    new Worker("Pesho", "Peshev", 4, 660m),
                    new Worker("Teodor", "Ivanov", 3, 142m),
                    new Worker("Stamat", "Ivanov", 10, 2200m),
                    new Worker("Mariika", "Ivanova", 7, 860m)
                };

                var sortWorkers =
                    from worker in workers
                    orderby worker.MoneyPerHour() descending 
                    select worker;

                foreach (var worker in sortWorkers)
                {
                    Console.WriteLine(worker);
                }

                Console.WriteLine("Merged:");

                List<Human> humans = new List<Human>();
                humans.AddRange(students);
                humans.AddRange(workers);

                humans = humans.OrderBy(human => human.FirstName).ThenBy(human => human.LastName).ToList();

                foreach (var human in humans)
                {
                    Console.WriteLine(human);
                }
            }
            catch(DuplicateNameException dne)
            {
                Console.WriteLine(dne.Message);
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                Console.WriteLine(aoore.Message);
            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
