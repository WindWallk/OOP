using System;

class PersonsTest
{
    static void Main()
    {
        Person g = new Person("Georgi", 23);
        Console.WriteLine(g);

        Person i = new Person("Ivan", 20, "ivan.ivanov@gmail.com");
        Console.WriteLine(i);

    }
}
