using DataAccess.Data;
using DataAccess.Repositories;
using RepositoriesLibrary;
using RepositoriesLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class  UnitOfWork : IUnitOfWork
    {
        private readonly  DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            CategoryRep = new CategoryRepository(_context);
            prodRep = new ProductRepository(_context);
        }

        public ICategoryRep CategoryRep { get;  }


        public IProdRep prodRep { get; }

        public int Commit()=>_context.SaveChanges();    

        public void Dispose()=>_context?.Dispose(); 
    }
}
