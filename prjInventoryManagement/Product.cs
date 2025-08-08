using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjInventoryManagement
{
    public class Product
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

    public class Inventory
    {
        public List<Product> Products { get; set; }
        public Inventory()
        {
            Products = new List<Product>();
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public void RemoveProduct(string productId)
        {
            var product = Products.FirstOrDefault(p => p.ID == productId);
            if (product != null)
            {
                Products.Remove(product);
            }
        }
        public Product GetProduct(string productId)
        {
            return Products.FirstOrDefault(p => p.ID == productId);
        }
    }

    // Extension methods for List<Product>
    public static class ProductExtensions
    {
        // Calculates the total value of all products (sum of Quantity * Price)
        public static double TotalValue(this List<Product> products)
        {
            return products.Sum(p => p.Quantity * p.Price);
        }

        // Filters products that are low in stock (Quantity less than threshold)
        public static IEnumerable<Product> LowStock(this List<Product> products, int threshold)
        {
            return products.Where(p => p.Quantity < threshold);
        }
    }

    public class InventoryManagement
    {
        public void DisplayProducts()
        {
            Inventory inventory = new Inventory();
            // Adding products
            inventory.AddProduct(new Product { ID = "1", Name = "Laptop", Quantity = 10, Price = 999.99 });
            inventory.AddProduct(new Product { ID = "2", Name = "Smartphone", Quantity = 2, Price = 499.99 });
            inventory.AddProduct(new Product { ID = "3", Name = "Tablet", Quantity = 1, Price = 299.99 });

            // LINQ query: select product names and prices into an anonymous type
            var productInfo = from p in inventory.Products
                              select new { p.Name, p.Price };

            foreach (var item in productInfo)
            {
                Console.WriteLine($"Product: {item.Name}, Price: {item.Price}");
            }

            // Example usage of extension methods
            double totalValue = inventory.Products.TotalValue();
            Console.WriteLine($"Total Inventory Value: {totalValue}");

            var lowStockProducts = inventory.Products.LowStock(5);
            Console.WriteLine("Low Stock Products (Quantity < 5):");
            foreach (var p in lowStockProducts)
            {
                Console.WriteLine($"Product: {p.Name}, Quantity: {p.Quantity}");
            }
        }
    }
}