namespace OnlineMarket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    class Market
    {
        static StringBuilder result = new StringBuilder();

        static void Main()
        {
            var market = new OnlineMarket();

            while (true)
            {
                string[] command = Console.ReadLine().Split(' ');

                if (command[0] == "end")
                {
                    break;
                }

                switch (command[0])
                {
                    case "add":
                        {
                            var product = new Product(command[1], double.Parse(command[2]), command[3]);

                            var withThisName = market.FindProductsByName(command[1]);
                            if (withThisName.Count() != 0)
                            {
                                result.AppendLine(string.Format("Error: Product {0} already exists", command[1]));
                                break;
                            }

                            market.AddProduct(product);

                            result.AppendLine(string.Format("Ok: Product {0} added successfully", command[1]));
                            break;
                        }
                    case "filter":
                        {
                            switch (command[2])
                            {
                                case "type":
                                    {
                                        // filter by type PRODUCT_TYPE
                                        var products = market.FindProductsByType(command[3]);
                                        PrintProductsByType(products, command[3]);
                                        break;
                                    }
                                case "price":
                                    {
                                        if (command.Length == 7)
                                        {
                                            // filter by price from MIN_PRICE to MAX_PRICE 
                                            double min = double.Parse(command[4]);
                                            double max = double.Parse(command[6]);
                                            var products = market.FindProductsByPriceRange(min, max);
                                            PrintProducts(products);
                                            break;
                                        }
                                        else
                                        {
                                            if (command[3] == "from")
                                            {
                                                // filter by price from MIN_PRICE   
                                                double min = double.Parse(command[4]);
                                                var products = market.FindProductsByMinPrice(min);
                                                PrintProducts(products);
                                                break;
                                            }
                                            else
                                            {
                                                // filter by price to MAX_PRICE
                                                double max = double.Parse(command[4]);
                                                var products = market.FindProductsByMaxPrice(max);
                                                PrintProductsToMaxPrice(products);
                                                break;
                                            }
                                        }
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
                    default:
                        break;
                }
            }

            Console.WriteLine(result.ToString());
        }

        private static void PrintProductsByType(IEnumerable<Product> products, string type)
        {
            if (!products.Any())
            {
                result.AppendLine(string.Format("Error: Type {0} does not exists", type));
                return;
            }

            var sorted = products
                                 .Take(10);
                                 //.OrderBy(p => p.Price)
                                 //.ThenBy(p => p.Name)
                                 //.ThenBy(p => p.Type);
            result.Append(string.Format("Ok: {0}", string.Join(", ", sorted)));
            result.AppendLine();
        }

        private static void PrintProducts(IEnumerable<Product> products)
        {
            var sorted = products
                                 .Take(10);
                                 //.OrderBy(p => p.Price)
                                 //.ThenBy(p => p.Name)
                                 //.ThenBy(p => p.Type);
            result.Append(string.Format("Ok: {0}", string.Join(", ", sorted)));
            result.AppendLine();
        }

        private static void PrintProductsToMaxPrice(IEnumerable<Product> products)
        {
            var sorted = products
                                 .Take(10);
                                 //.OrderBy(p => p.Price)
                                 //.ThenBy(p => p.Name)
                                 //.ThenBy(p => p.Type);
            result.Append(string.Format("Ok: {0}", string.Join(", ", sorted)));
            result.AppendLine();
        }
    }

    public class Product : IComparable<Product>
    {
        public Product(string name, double price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public Product()
        {
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {
            // Milk(1.9)
            return this.Name + "(" + this.Price + ")";
        }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }

    public class OnlineMarket
    {
        private readonly MultiDictionary<string, Product> byName;
        private readonly MultiDictionary<string, Product> byType;
        private readonly OrderedBag<Product> byPrice;

        public OnlineMarket()
        {
            this.byName = new MultiDictionary<string, Product>(false);
            this.byType = new MultiDictionary<string, Product>(true);
            this.byPrice = new OrderedBag<Product>();
        }

        public void AddProduct(Product product)
        {
            this.byName.Add(product.Name, product);
            this.byType[product.Type].Add(product);
            this.byPrice.Add(product);
        }

        public IEnumerable<Product> FindProductsByName(string name)
        {
            var products = this.byName[name];
            return products
                           .OrderBy(p => p.Price)
                           .ThenBy(p => p.Name)
                           .ThenBy(p => p.Type);
        }

        public IEnumerable<Product> FindProductsByType(string type)
        {
            var products = this.byType[type];
            return products
                           .OrderBy(p => p.Price)
                           .ThenBy(p => p.Name)
                           .ThenBy(p => p.Type);
        }

        public IEnumerable<Product> FindProductsByPriceRange(double min, double max)
        {
            var products = this.byPrice.Range(new Product { Price = min }, true, new Product { Price = max }, true);
            return products
                           .OrderBy(p => p.Price)
                           .ThenBy(p => p.Name)
                           .ThenBy(p => p.Type);
        }

        public IEnumerable<Product> FindProductsByMinPrice(double min)
        {
            var products = this.FindProductsByPriceRange(min, double.MaxValue);
            return products
                           .OrderBy(p => p.Price)
                           .ThenBy(p => p.Name)
                           .ThenBy(p => p.Type);
        }

        public IEnumerable<Product> FindProductsByMaxPrice(double max)
        {
            var products = this.FindProductsByPriceRange(0, max);
            return products
                           .OrderBy(p => p.Price)
                           .ThenBy(p => p.Name)
                           .ThenBy(p => p.Type);
        }
    }
}