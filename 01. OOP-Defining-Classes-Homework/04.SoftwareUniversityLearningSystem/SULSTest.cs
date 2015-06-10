using System;
using System.Collections.Generic;
using System.Linq;

class SULSTest
{
    static void Main(string[] args)
    {
        Person pesho = new Person("Pesho", "Peshov", 20);
        Trainer gosho = new Trainer("Georgi", "Georgiev", 21);
        JuniourTrainer ivan = new JuniourTrainer("Ivan", "Ivanov", 23);
        SeniourTrainer stamat = new SeniourTrainer("Stamat", "Stamatov", 20);
        GraduateStudent mariika = new GraduateStudent("Mariika", "Mariikina", 25, "1256", 5.53d);
        DropoutStudent mariq = new DropoutStudent("Mariq", "Iordanova", 22, "1245", 3.12d, "Low average grade");
        CurrentStudent goshko = new CurrentStudent("Goshko", "Goshkov", 22, "5153", 5.21d, "OOP");
        OnlineStudent aleksandar = new OnlineStudent("Aleksandar", "Garov", 20, "3089", 5.45d, "OOP");
        OnsiteStudent magdalena = new OnsiteStudent("Magdalena", "Sokolova", 20, "2127", 5.67, "Advanced C#", 3);

        gosho.CreateCourse("OOP");
        ivan.CreateCourse("High-quality Code");
        stamat.CreateCourse("Advanced C#");
        stamat.DeleteCourse("Advanced C#");

        List<Person> persons = new List<Person>()
        {
            pesho,
            gosho,
            ivan,
            stamat,
            mariika,
            mariq,
            goshko,
            aleksandar,
            magdalena
        };

        var currentStudents = persons
            .Where(person => person is CurrentStudent)
            .OrderBy(person => ((Student) person).AverageGrade)
            .Select(person => person);

        foreach (var currentStudent in currentStudents)
        {
            Console.WriteLine(currentStudent);
        }
    }
}