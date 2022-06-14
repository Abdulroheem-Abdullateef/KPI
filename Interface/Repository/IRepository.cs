using System;
using System.Threading.Tasks;

namespace KpiNew.Interface.Repository
{
    public interface IRepository<T>
    {
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        void SaveChanges();

    }
}