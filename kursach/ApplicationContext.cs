using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Fine> Fines { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string dbPath = @"C:\Users\tyomy\OneDrive\Desktop\kursach\kursach\bin\Debug\bd.db";
                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }
        }
    }
}
