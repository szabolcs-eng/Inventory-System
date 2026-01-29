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

        public void DeleteProduct(string name)
        {
            var product = _db.Products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
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

        public void UpdateProductQuantity(string name, int newQuantity)
        {
            var product = _db.Products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                product.Quantity = newQuantity;
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
