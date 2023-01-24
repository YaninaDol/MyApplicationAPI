using RepositoriesLibrary.Interfaces;
using RepositoriesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesLibrary
{
    public interface ICategoryRep:IGenericRepository<Category>
    {
        Category GetPopular();
    }
}
