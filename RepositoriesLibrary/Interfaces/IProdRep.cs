using Microsoft.AspNetCore.Mvc;
using RepositoriesLibrary.Models;
using RepositoriesLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesLibrary
{
    public interface IProdRep : IGenericRepository<Product>
    {
        bool Buy(int prodId,int userId);
         IEnumerable<Product> GetByCategory(int ID);
    }
}
