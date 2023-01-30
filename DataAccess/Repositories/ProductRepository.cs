using DataAccess;
using DataAccess.Data;
using JWT_Token.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoriesLibrary;
using RepositoriesLibrary.Interfaces;
using RepositoriesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class ProductRepository : GenericRepository<Product>, IProdRep
    {
        public ProductRepository(DataContext context) : base(context)
        {

        }

        public bool Buy(int prodId, int userId)
        {
            Product product = db.Products.Where(x => x.Id == prodId).FirstOrDefault();
            // User person = _context.Users.Where(x => x.Id.Equals(UserID)).FirstOrDefault();

            if (product != null)
            {
                try
                {
                    db.ListProducts.Add(new ListProduct() { ProductId = product.Id, UserId = userId, Status = "new" });
                    return true;
                }
                catch { return false; }
            }
            else return false;
        }

       public IEnumerable<Product> GetByCategory(int ID)
        {
            if (db.Categories.Any(x => x.Id == ID))
            { return db.Products.ToList().Where(x => x.CategoryId == ID).ToList(); }
            else return null;
            
        }
    }

}
