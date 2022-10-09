using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public MarketEntities _market = null;
        public DbSet<T> _table = null;
        public GenericRepository()
        {
            _market = new MarketEntities();
            _table = _market.Set<T>();
        }

        public GenericRepository(MarketEntities market)
        {
            _market = market;
            _table = market.Set<T>();
        }
        public void Delete(object id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();        
        }

        public T GetById(object id)
        {
            return _table.Find(id);
        }

        public void Insert(T obj)
        {
            _table.Add(obj);
        }

        public void Save()
        {
            _market.SaveChanges();
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _market.Entry(obj).State = EntityState.Modified;
        }
    }
}
