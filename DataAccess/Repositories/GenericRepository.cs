using DataAccess.Data;
using MyApplicationAPI.Cache;
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
      private readonly ICacheService _cacheService;
        public GenericRepository(DataContext context, ICacheService cacheService)
        {
            this.db = context;
            this._cacheService = cacheService;
        }

        public void Create(T item) => db.Set<T>().Add(item); 
       

        public void Delete(int id)
        {
             db.Set<T>().Remove(db.Set<T>().Find(id));
        }

        public T Get(int id) 
        {
            //List<T> collection = _cacheService.GetData<List<T>>($"{T}");
            //if (collection == null)
            //{
            //    var productSQL = await db.Set<T>().ToList();
            //    if (productSQL.Count > 0)
            //    {
            //        productsCache = productSQL;
            //        _cacheService.SetData($"{T}", productSQL, DateTimeOffset.Now.AddDays(1));



            //    }
            //}
            //return collection;

            return db.Set<T>().Find(id);
            
        }

        public IEnumerable<T> GetAll()=>db.Set<T>().ToList();

        public void Update(T item)
        {
            db.Set<T>().Update(item);
        }
    }
}
