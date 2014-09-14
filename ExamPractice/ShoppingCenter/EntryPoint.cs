// BG CODER: http://bgcoder.com/Contests/Practice/Index/90#4
namespace ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;
    
    class EntryPoint
    {
        private static StringBuilder result = new StringBuilder();

        static void Main(string[] args)
        {
            int totalCommands = int.Parse(Console.ReadLine());

            var shoppingCenter = new ShoppingCenter();

            for (int i = 0; i < totalCommands; i++)
            {
                string[] commandLine = Console.ReadLine().Split(new char[] { ' ' }, 2);

                string[] parameters = commandLine[1].Split(';');

                switch (commandLine[0])
                {
                    case "AddProduct":
                        {
                            shoppingCenter.AddProduct(new Product(
                                name: parameters[0],
                                price: double.Parse(parameters[1]),
                                producer: parameters[2])
                            );

                            result.AppendLine("Product added");
                            break;
                        }
                    case "DeleteProducts":
                        {
                            int deletedCount = 0;

                            switch (parameters.Length)
                            {
                                case 1:
                                    {
                                        deletedCount = shoppingCenter.DeleteProducts(parameters[0]);
                                        break;
                                    }

                                case 2:
                                    {
                                        deletedCount = shoppingCenter.DeleteProducts(parameters[0], parameters[1]);
                                        break;
                                    }
                                default:
                                    throw new ArgumentException("Invalid Delete Parameters");
                            }

                            if (deletedCount == 0)
                            {
                                result.AppendLine("No products found");
                                break;
                            }

                            result.AppendLine(string.Format("{0} products deleted", deletedCount));
                            break;
                        }
                    case "FindProductsByName":
                        {
                            PrintProducts(shoppingCenter.FindProductsByName(parameters[0]));
                            break;
                        }
                    case "FindProductsByPriceRange":
                        {
                            PrintProducts(shoppingCenter.FindProductsByPriceRange(
                                min: double.Parse(parameters[0]),
                                max: double.Parse(parameters[1])));
                            break;
                        }
                    case "FindProductsByProducer":
                        {
                            PrintProducts(shoppingCenter.FindProductsByProducer(parameters[0]));
                            break;
                        }
                    default:
                        throw new ArgumentException("Invalid command!");
                }
            }

            Console.WriteLine(result.ToString().Trim());
        }

        private static void PrintProducts(IEnumerable<Product> products)
        {
            if (!products.Any())
            {
                result.AppendLine("No products found");
                return;
            }

            var sorted = products
                                 .OrderBy(p => p.Name)
                                 .ThenBy(p => p.Producer)
                                 .ThenBy(p => p.Price);

            foreach (var product in sorted)
            {
                result.AppendLine(product.ToString());
            }
        }
    }

    public class Product :IComparable<Product>
    {
        public Product(string name, double price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public Product()
        {

        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Producer { get; set; }

        public override string ToString()
        {
            return "{" + string.Format("{0};{1};{2:0.00}", this.Name, this.Producer, this.Price) + "}";
        }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }

    public class ShoppingCenter
    {
        private readonly MultiDictionary<string, Product> byName;
        private readonly MultiDictionary<string, Product> byProducer;
        private readonly MultiDictionary<Tuple<string, string>, Product> byNameAndProducer;
        private readonly OrderedBag<Product> byPrice;

        public ShoppingCenter()
        {
            this.byName = new MultiDictionary<string, Product>(true);
            this.byProducer = new MultiDictionary<string, Product>(true);
            this.byNameAndProducer = new MultiDictionary<Tuple<string, string>, Product>(true);
            this.byPrice = new OrderedBag<Product>();
        }

        public void AddProduct(Product product)
        {
            this.byName[product.Name].Add(product);
            this.byProducer[product.Producer].Add(product);
            this.byNameAndProducer[Tuple.Create<string, string>(product.Name, product.Producer)].Add(product);
            this.byPrice.Add(product);
        }

        public IEnumerable<Product> FindProductsByName(string name)
        {
            var products = this.byName[name];
            return products;
        }

        public IEnumerable<Product> FindProductsByProducer(string producer)
        {
            var products = this.byProducer[producer];
            return products;
        }

        public IEnumerable<Product> FindProductsByPriceRange(double min, double max)
        {
            var products = this.byPrice.Range(new Product { Price = min }, true, new Product { Price = max }, true);
            return products;
        }

        public int DeleteProducts(string producer)
        {
            var products = this.byProducer[producer];
            var count = products.Count;

            foreach (var product in products)
            {
                this.byName[product.Name].Remove(product);
                this.byNameAndProducer[Tuple.Create<string, string>(product.Name, product.Producer)].Remove(product);
                this.byPrice.Remove(product);
            }

            this.byProducer.Remove(producer);

            return count;
        }

        public int DeleteProducts(string name, string producer)
        {
            var key = Tuple.Create<string, string>(name, producer);
            var products = this.byNameAndProducer[key];
            var count = products.Count;

            foreach (var product in products)
            {
                this.byName[product.Name].Remove(product);
                this.byProducer[product.Producer].Remove(product);
                this.byPrice.Remove(product);
            }

            this.byNameAndProducer.Remove(key);

            return count;
        }
    }
}