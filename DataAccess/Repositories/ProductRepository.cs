using DataAccess;
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


namespace DataAccess.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProdRep
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }



    }

}
