using Inventory_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Data
{
    public class InventoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; } // DbSet representing the Products table

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=inventory.db"); // Configuring SQLite as the database
    }
}
