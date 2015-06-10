using System;

class Person
{
    private string firstName;
    private string lastName;
    private int age;

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The first name cannot be empty!");
            }
            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The last name cannot be empty!");
            }
            this.lastName = value;
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(("The age cannot be negative number!"));
            }
            this.age = value;
        }
    }

    public Person(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }

    public override string ToString()
    {
        return string.Format("First name: {0}\nLast name: {1}\nAge: {2}\n", 
                        this.FirstName, this.LastName, this.Age);
    }
}
