using System;

namespace prjInventoryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InventoryManagement manager = new InventoryManagement();
            manager.DisplayProducts();

            // Keep the console window open
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}