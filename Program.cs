using Inventory_System.Services;

namespace Inventory_System
{
    class Program
    {
        static ProductService _service = new ProductService();

        static void Main(string[] args)
        {
            _service.EnsureDatabaseCreated();

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== INVENTORY SYSTEM (v1.0) ===");
                Console.WriteLine("1. List products");
                Console.WriteLine("2. Add new product");
                Console.WriteLine("3. Update product (Price/Quantity)");
                Console.WriteLine("4. Delete product");
                Console.WriteLine("5. Quit");
                Console.Write("\nChoose an option: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ListItems();
                        break;
                    case "2":
                        AddItem();
                        break;
                    case "3":
                        UpdateItem();
                        break;
                    case "4":
                        DeleteItem();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Press Enter...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void ListItems()
        {
            Console.Clear();
            Console.WriteLine("--- CURRENT STOCK ---\n");
            _service.ListProducts();
            Console.WriteLine("\nPress Enter to go back....");
            Console.ReadLine();
        }

        static void AddItem()
        {
            Console.Clear();
            Console.WriteLine("--- ADDING NEW PRODUCT ---\n");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            Console.Write("Price (HUF): ");
            decimal price = decimal.Parse(Console.ReadLine());

            _service.AddProduct(name, quantity, price);

            Console.WriteLine("\nSuccessful save! Press Enter...");
            Console.ReadLine();
        }

        static void UpdateItem()
        {
            Console.Clear();
            Console.WriteLine("--- UPDATING PRODUCT ---\n");
            _service.ListProducts(); 
            Console.WriteLine("-------------------------");

            Console.Write("Which product ID would you like to update?: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("New quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            Console.Write("New price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            _service.UpdateProduct(id, quantity, price);

            Console.WriteLine("\nSuccessful update! Press Enter...");
            Console.ReadLine();
        }

        static void DeleteItem()
        {
            Console.Clear();
            Console.WriteLine("--- DELETING PRODUCT ---\n");
            _service.ListProducts();
            Console.WriteLine("-------------------------");

            Console.Write("Which product ID would you like to delete?: ");
            int id = int.Parse(Console.ReadLine());

            _service.DeleteProduct(id);

            Console.WriteLine("\nProduct deleted! Press Enter...");
            Console.ReadLine();
        }
    }
}
