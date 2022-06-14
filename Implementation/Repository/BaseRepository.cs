using KpiNew.Context;
using KpiNew.Entities;
using KpiNew.Interface.Repository;
using System.Threading.Tasks;

namespace KpiNew.Implementation.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        protected ApplicationContext _context;
        public async Task<T> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void SaveChanges()
        {
              _context.SaveChanges();
        }

        public async Task<T> Update(T entity)
        {
           _context.Set<T>().Update(entity);
           await _context.SaveChangesAsync();
           return entity;
        }

     
    }
}