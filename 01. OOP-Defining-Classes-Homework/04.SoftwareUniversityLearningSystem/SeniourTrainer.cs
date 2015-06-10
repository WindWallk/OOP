using System;

class SeniourTrainer : Trainer
{
    public SeniourTrainer(string firstName, string lastName, int age)
        : base(firstName, lastName, age)
    {
    }

    public void DeleteCourse(string courseName)
    {
        Console.WriteLine("Course {0} has been deleted!", courseName);
    }
}