using Inventory_System.Data;
using Inventory_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Services
{
    public class ProductService
    {
        private InventoryContext _db = new InventoryContext();

        public void EnsureDatabaseCreated()
        {
            _db.Database.EnsureCreated();
        }

        public void AddProduct(string name, int quantity, decimal price)
        {
            var newProduct = new Product
            {
                Name = name,
                Quantity = quantity,
                Price = price
            };
            _db.Products.Add(newProduct);
            _db.SaveChanges();
            Console.WriteLine("Product added successfully!");
        }

        public void ListProducts()
        {
            var products = _db.Products.ToList();
            Console.WriteLine("Product List:");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Quantity: {product.Quantity}, Price: {product.Price:C} Ft");
            }
        }    

        public void DeleteProduct(int id)
        {
            var product = _db.Products.Find(id);
            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
                Console.WriteLine("Product deleted successfully!");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public void UpdateProduct(int id, int newQuantity, decimal newPrice)
        {
            var product = _db.Products.Find(id);
            if (product != null)
            {
                product.Quantity = newQuantity;
                product.Price = newPrice;
                _db.SaveChanges();
                Console.WriteLine("Product quantity updated successfully!");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
    }
}
