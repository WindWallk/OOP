using System;

class Person
{
    private string email;
    private string name;
    private int age;

    public Person(string name, int age)
        : this(name, age, null)
    {
    }

    public Person(string name, int age, string email)
    {
        this.Name = name;
        this.Age = age;
        this.Email = email;
    }

    public string Name
    {
        get { return this.name; }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name cannot be empty!");
            }
            this.name = value;
        }
    }

    public int Age
    {
        get { return this.age; }

        set
        {
            if (age < 1 || age > 100)
            {
                throw new ArgumentOutOfRangeException("Please enter a valid age!");
            }
            this.age = value;
        }
    }

    public string Email
    {
        get
        {
            return this.email;
        }
        set
        {
            if (value == string.Empty || !value.Contains("@"))
            {
                throw new ArgumentOutOfRangeException("Invalid email!");
            }
            this.email = value;
        }
    }

    public override string ToString()
    {
        return string.Format("Name = {0}, Age = {1}, Email = {2}", this.Name, this.Age, this.Email ?? "No email");
    }
}
