using AulaConexao.Domain.Base;
using System.Collections.Generic;

namespace AulaConexao.Data.Interface
{
    public interface IBaseRepository<T> where T : class, BaseEntity
    {
        List<T> FindAll();
        T FindById(int id);
        void Create(T entity);
        T Update(T entity);
        void Remove(int id);
        void Dispose();
        
    }
}
