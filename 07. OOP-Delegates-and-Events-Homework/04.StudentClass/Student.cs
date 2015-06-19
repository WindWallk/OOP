namespace _04.StudentClass
{
    public delegate void OnPropertyChangeEventHandler(Student student, PropertyChangedEventArgs args);

    public class Student
    {
        public event OnPropertyChangeEventHandler PropertyChanged;

        private string name;

        private int age;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name {
            get
            {
                return this.name;
            }

            set
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this,
                        new PropertyChangedEventArgs("Name", this.name, value));
                }

                this.name = value;
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
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this,
                        new PropertyChangedEventArgs("Age", this.age, value));
                }

                this.age = value;
            }
        }
    }
}
