using DataAccess.Data;
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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRep
    {
        public CategoryRepository(DataContext context) : base(context)

        {
        }


        public Category GetPopular()
        {
            Category popular=new Category();
            int max = 0;
            foreach (var item in db.Categories.ToList())
            {
               int count= db.Products.Where(x=>x.CategoryId==item.Id).Count();
                if (count > max)
                {
                    max = count;
                    popular = item;
                }
              
            }
            return popular;
           
          

        }
        public int GetCount(int Id)
        {

            return db.Products.ToList().Where(x => x.CategoryId.Equals(Id)).Count();
        }
    }
}
