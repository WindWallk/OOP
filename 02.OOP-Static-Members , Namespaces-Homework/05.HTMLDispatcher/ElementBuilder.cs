using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.HTMLDispatcher
{
    class ElementBuilder
    {
        private string name;

        public ElementBuilder(string name)
        {
            this.Name = name;
            this.Content = string.Empty;
            this.Attributes = new Dictionary<string, string>();
        }

        public string Name
        {
            get { return this.name; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("There must be a name!");
                }
                this.name = value;
            }
        }

        public static string operator *(ElementBuilder element, int count)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                result.Append(element);
            }

            return result.ToString();
        }

        public string Content { get; set; }

        public Dictionary<string, string> Attributes { get; set; }

        public void AddAttribute(string attribute, string value)
        {
            if (string.IsNullOrEmpty(attribute))
            {
                throw new ArgumentNullException("Attribute cannot be empty");
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Attribute value cannot be empty");
            }

            this.Attributes.Add(attribute, value);
        }

        public void AddContent(string content)
        {
            this.Content += content;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("<{0}", this.Name);

            for (int i = 0; i < this.Attributes.Count; i++)
            {
                result.AppendFormat(" {0} = \"{1}\"", this.Attributes.ElementAt(i).Key,
                    this.Attributes.ElementAt(i).Value);
            }
            result.AppendFormat(">{0}</{1}>", this.Content, this.Name);
            return result.ToString();
        }
    }
}
