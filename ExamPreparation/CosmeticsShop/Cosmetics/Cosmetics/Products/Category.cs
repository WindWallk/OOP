namespace Cosmetics.Products
{
    using Contracts;
    using Common;
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    public class Category : ICategory
    {
        private const int MinCategoryLength = 2;
        private const int MaxCategoryLength = 15;

        private string name;
        private IList<IProduct> products;


        public Category(string name)
        {
            this.Name = name;
            this.products = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format
                    (GlobalErrorMessages.StringCannotBeNullOrEmpty, "Category name"));

                Validator.CheckIfStringLengthIsValid(value,
                    MaxCategoryLength,
                    MinCategoryLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength,
                        "Category name", MinCategoryLength, MaxCategoryLength));

                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.products.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (!this.products.Contains(cosmetics))
            {
                throw new ArgumentException(string.Format(
                    "Product {0} does not exist in category {1}!",
                    cosmetics.Name,
                    this.Name));
            }

            this.products.Remove(cosmetics);
        }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(
                "{0} category - {1} product{2} in total{3}",
                this.Name, this.products.Count,
                this.products.Count == 1 ? string.Empty : "s",
                Environment.NewLine);

            var sortedProducts = this.products
                .OrderBy(product => product.Brand)
                .ThenByDescending(product => product.Price);

            foreach (var product in sortedProducts)
            {
                sb.AppendLine(product.Print());
            }

            return sb.ToString().Trim();
        }
    }
}
