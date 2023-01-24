using DataAccess.Data;
using DataAccess.Repositories;
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
           
           
            return this.db.Categories.ToList()[0];
          

        }
    }
}
