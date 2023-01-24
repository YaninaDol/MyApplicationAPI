using Microsoft.EntityFrameworkCore;
using RepositoriesLibrary.Models;

namespace DataAccess.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }

    }
}