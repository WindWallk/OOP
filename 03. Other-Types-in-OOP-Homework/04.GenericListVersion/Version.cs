namespace _04.GenericListVersion
{
    using System;

    [AttributeUsage(
        AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum
        | AttributeTargets.Method, AllowMultiple = true)]
    public class Version : System.Attribute
    {
        private int major;

        private int minor;

        public Version(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public int Major
        {
            get
            {
                return this.major;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("major", "Major must be a positive integer or zero!");
                }
                this.major = value;
            }
        }

        public int Minor
        {
            get
            {
                return this.minor;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("minor", "Minor must be a positive integer or zero!");
                }
                this.minor = value;
            }
        }
    }
}
