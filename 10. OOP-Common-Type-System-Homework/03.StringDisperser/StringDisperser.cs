using System;
using System.Collections;

namespace _03.StringDisperser
{
    public class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable
    {
        private string[] elements;

        public StringDisperser(params string[] elements)
        {
            this.Elements = elements;
        }

        public string[] Elements
        {
            get
            {
                return this.elements;
            }

            set
            {
                this.elements = value;
            }
        }

        public int CompareTo(StringDisperser other)
        {
            return this.ToString().CompareTo(other.ToString());
        }

        public override string ToString()
        {
            return string.Join(string.Empty, this.Elements);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public IEnumerator GetEnumerator()
        {
            string disprerse = this.ToString();

            for (int i = 0; i < disprerse.Length; i++)
            {
                yield return disprerse[i];
            }
        }

        public object Clone()
        {
            string[] elementsCopy = new string[this.Elements.Length];

            Array.Copy(this.Elements, elementsCopy, this.Elements.Length);

            return new StringDisperser(elementsCopy);
        }

        public override bool Equals(object obj)
        {
            StringDisperser otherDisperser = (StringDisperser) obj;

            return this.ToString() == otherDisperser.ToString();
        }

        public static bool operator ==(StringDisperser disperser1, StringDisperser disperser2)
        {
            return disperser1.Equals(disperser2);
        }

        public static bool operator !=(StringDisperser disperser1, StringDisperser disperser2)
        {
            return !disperser1.Equals(disperser2);
        }
    }
}
