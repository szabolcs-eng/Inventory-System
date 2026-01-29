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
                Console.WriteLine("=== RAKTÁRKEZELŐ RENDSZER (v1.0) ===");
                Console.WriteLine("1. Termékek listázása");
                Console.WriteLine("2. Új termék hozzáadása");
                Console.WriteLine("3. Termék módosítása (Ár/Darab)");
                Console.WriteLine("4. Termék törlése");
                Console.WriteLine("5. Kilépés");
                Console.Write("\nVálassz egy opciót: ");

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
                        Console.WriteLine("Érvénytelen választás! Nyomj Entert...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void ListItems()
        {
            Console.Clear();
            Console.WriteLine("--- JELENLEGI KÉSZLET ---\n");
            _service.ListProducts();
            Console.WriteLine("\nNyomj Entert a visszalépéshez...");
            Console.ReadLine();
        }

        static void AddItem()
        {
            Console.Clear();
            Console.WriteLine("--- ÚJ TERMÉK FELVÉTELE ---\n");

            Console.Write("Név: ");
            string name = Console.ReadLine();

            Console.Write("Mennyiség (db): ");
            int quantity = int.Parse(Console.ReadLine());

            Console.Write("Ár (Ft): ");
            decimal price = decimal.Parse(Console.ReadLine());

            _service.AddProduct(name, quantity, price);

            Console.WriteLine("\nSikeres mentés! Nyomj Entert...");
            Console.ReadLine();
        }

        static void UpdateItem()
        {
            Console.Clear();
            Console.WriteLine("--- TERMÉK MÓDOSÍTÁSA ---\n");
            _service.ListProducts(); 
            Console.WriteLine("-------------------------");

            Console.Write("Melyik ID-jú terméket módosítanád?: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Új mennyiség: ");
            int quantity = int.Parse(Console.ReadLine());

            Console.Write("Új ár: ");
            decimal price = decimal.Parse(Console.ReadLine());

            _service.UpdateProduct(id, quantity, price);

            Console.WriteLine("\nSikeres módosítás! Nyomj Entert...");
            Console.ReadLine();
        }

        static void DeleteItem()
        {
            Console.Clear();
            Console.WriteLine("--- TERMÉK TÖRLÉSE ---\n");
            _service.ListProducts();
            Console.WriteLine("-------------------------");

            Console.Write("Melyik ID-jú terméket töröljük?: ");
            int id = int.Parse(Console.ReadLine());

            _service.DeleteProduct(id);

            Console.WriteLine("\nTermék törölve! Nyomj Entert...");
            Console.ReadLine();
        }
    }
}
