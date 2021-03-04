using AulaConexao.Data;
using AulaConexao.Data.Interface;
using AulaConexao.Domain.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace SalaoCampinasTech.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, BaseEntity
    {
        protected readonly Context _context;
        private DbSet<T> dataset;

        public BaseRepository(Context context)
        {
            _context = context;
            dataset = context.Set<T>();
        }

        public virtual List<T> FindAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T FindById(int id)
        {
            return dataset.FirstOrDefault(x => x.Id.Equals(id));
        }

        public virtual void Create(T entity)
        {
            dataset.Add(entity);
            _context.SaveChanges();
        }

        public T Update(T entity)
        {
            var result = FindById(entity.Id);
            if (result == null)
                return null;

            _context.Entry(result).CurrentValues.SetValues(entity);
            _context.SaveChanges();

            return entity;
        }

        public virtual void Remove(int id)
        {
            var entity = FindById(id);
            dataset.Remove(entity);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
