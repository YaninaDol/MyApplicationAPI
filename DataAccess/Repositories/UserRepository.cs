using DataAccess.Data;
using RepositoriesLibrary.Models;
using RepositoriesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApplicationAPI.Model;
using RepositoriesLibrary.Interfaces;

namespace DataAccess.Repositories
{
    public class UserRepository : GenericRepository<Register>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {

        }
    }
}
