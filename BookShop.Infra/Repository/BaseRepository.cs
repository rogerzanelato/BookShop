using System.Collections.Generic;
using System.Linq;
using BookShop.Domain.Entities;
using BookShop.Domain.Interfaces;
using BookShop.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Domain.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public virtual void Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }
        public virtual void Update(T obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            _context.Set<T>().Remove(Select(id));
            _context.SaveChanges();
        }

        public virtual T Select(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual IList<T> Select()
        {
            return _context.Set<T>().ToList();
        }
    }
}
