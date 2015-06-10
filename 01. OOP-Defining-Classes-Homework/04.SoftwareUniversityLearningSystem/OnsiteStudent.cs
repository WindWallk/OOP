using System;

class OnsiteStudent : CurrentStudent
{
    private int numberOfVisits;
    public OnsiteStudent(string firstName, string lastName, int age, string studentNumber, double averageGrade, string currentCourse, int numberOfVisits)
        : base(firstName, lastName, age, studentNumber, averageGrade, currentCourse)
    {
        this.NumberOfVisits = numberOfVisits;
    }

    public int NumberOfVisits
    {
        get
        {
            return this.numberOfVisits;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("numberOfVisits", "Number of visits cannot be negative.");
            }
            this.numberOfVisits = value;
        }
    }

    public override string ToString()
    {
        return base.ToString() + string.Format("Number of visits: {0}", this.NumberOfVisits);
    }
}