namespace MyBagIsBetterThanYourBag
{
    using System;

    internal class Product : IComparable<Product>
    {
        private decimal price;
        private string name;

        public Product()
        {
        }

        public Product(string productName, decimal productPrice)
        {
            this.Name = productName;
            this.Price = productPrice;
        }

        public string Name
        {
            get
            {
                return this.name.Trim();
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative, please do not cheat.");
                }

                this.price = value;
            }
        }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}