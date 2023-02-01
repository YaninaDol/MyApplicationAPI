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
        void Buy(int prodId,string userId);
         IEnumerable<Product> GetByCategory(int ID);

        IEnumerable<Product> GetPopular();
        IEnumerable<string> GetBrand();


        IEnumerable<Product> GetbyFilter(string brand, float from, float to);

        bool UpdateProduct(int id, Product item);
    }
}
