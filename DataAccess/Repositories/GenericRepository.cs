using DataAccess.Data;
using RepositoriesLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
       readonly protected DataContext db;

        public GenericRepository(DataContext context)
        {
            this.db = context;
        }

        public void Create(T item) => db.Set<T>().Add(item); 
       

        public void Delete(int id)
        {
             db.Set<T>().Remove(db.Set<T>().Find(id));
        }

        public T Get(int id) 
        {
            return db.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()=>db.Set<T>().ToList();

        public void Update(T item)
        {
            db.Set<T>().Update(item);
        }
    }
}
