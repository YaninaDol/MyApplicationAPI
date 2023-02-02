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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class ProductRepository : GenericRepository<Product>, IProdRep
    {
        public ProductRepository(DataContext context) : base(context)
        {

        }

        public void Buy(int prodId, string userId)
        {
            Product product = db.Products.Where(x => x.Id == prodId).FirstOrDefault();
            // User person = _context.Users.Where(x => x.Id.Equals(UserID)).FirstOrDefault();

            if (product != null)
            {
                
                    db.ListProducts.Add(new ListProduct() {Date=DateTime.Now.ToString(), ProductId = product.Id,UserId=userId, Status = "new" });
                
            }
            
        }

       public IEnumerable<Product> GetByCategory(int ID)
        {
            if (db.Categories.Any(x => x.Id == ID))
            { return db.Products.ToList().Where(x => x.CategoryId == ID).ToList(); }
            else return null;
            
        }
        public IEnumerable<string> GetBrand()
        {
            List<string> brands = new List<string>();
            foreach (var item in db.Products.ToList())
            {
                if(!brands.Any(x=>x.Equals(item.Name.ToString())))
                {
                    brands.Add(item.Name.ToString());
                }
            }
            return brands;
           
        }

        public IEnumerable<ListProduct> GetOrders()
        {
            return db.ListProducts.ToList();

        }

        public IEnumerable<Product> GetPopular()
        {
          return db.Products.Where(x => x.Popular == 1);
        }

        public bool UpdateProduct(int id, Product item)
        {
            if (db.Products.Any(x => x.Id == id))
            {
                db.Products.Where(x => x.Id == id).FirstOrDefault().Name = item.Name;
                db.Products.Where(x => x.Id == id).FirstOrDefault().Model = item.Model;
                db.Products.Where(x => x.Id == id).FirstOrDefault().Price = item.Price;
                db.Products.Where(x => x.Id == id).FirstOrDefault().Capacity = item.Capacity;
                db.Products.Where(x => x.Id == id).FirstOrDefault().Visible = item.Visible;
                db.Products.Where(x => x.Id == id).FirstOrDefault().Sold = item.Sold;
                db.Products.Where(x => x.Id == id).FirstOrDefault().Image = item.Image;
                db.Products.Where(x => x.Id == id).FirstOrDefault().CategoryId = item.CategoryId;
                db.Products.Where(x => x.Id == id).FirstOrDefault().Popular = item.Popular;
                return true;

            }
            else return false;
        }

        public IEnumerable<Product> GetbyFilter(string brand, float from, float to)
        {
            List<Product> list= db.Products.ToList().Where(x => x.Name.Equals(brand) && x.Price >= from && x.Price <= to).ToList();
            if (list.Count > 0)
            {
                return list;

            }
            else return db.Products.ToList();
    }

    }


   

}
