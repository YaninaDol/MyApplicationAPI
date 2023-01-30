using JWT_Token.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepositoriesLibrary.Models;

namespace DataAccess.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<History> Histories { get; set; }

        public virtual DbSet<ListProduct> ListProducts { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}