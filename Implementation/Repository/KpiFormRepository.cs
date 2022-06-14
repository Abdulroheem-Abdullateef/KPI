using KpiNew.Context;
using KpiNew.Entities;
using KpiNew.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KpiNew.Implementation.Repository
{
    public class KpiFormRepository : BaseRepository<KpiForm>, IKpiFormRepository
    {

        public KpiFormRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<KpiForm> Get(Expression<Func<KpiForm, bool>> expression)
        {
            return await _context.KpiForms.Include(a => a.KpiResult)
                .ThenInclude(e => e.Employee).ThenInclude(a => a.Department)
                .Where(a =>a.IsDeleted == false)
                .SingleOrDefaultAsync(expression);
        }

        public async Task<IList<KpiForm>> GetAll()
        {
            return await _context.KpiForms.Include(a => a.KpiResult)
                 .ThenInclude(e => e.Employee).ThenInclude(a => a.Department)
                 .Where(a => a.IsDeleted == false).ToListAsync(); 
        }

        public async Task<KpiForm> GetKpiFormById(int id)
        {
            return await _context.KpiForms.Include(a => a.KpiResult)
                  .ThenInclude(e => e.Employee).ThenInclude(a => a.Department)
                  .Where(a => a.IsDeleted == false)
                  .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IList<KpiForm>> GetSelected(IList<int> ids)
        {
            return await _context.KpiForms
                  .Include(a => a.KpiResult)
               .ThenInclude(k => k.Employee).ThenInclude(e => e.Department)
                .Where(b => b.IsDeleted == false)
                  .Where(a => ids.Contains(a.Id)).ToListAsync();
        }

        public async Task<IList<KpiForm>> GetSelected(Expression<Func<KpiForm, bool>> expression)
        {
            return await _context.KpiForms
                 .Include(a => a.KpiResult)
              .ThenInclude(k => k.Employee).ThenInclude(e => e.Department)
               .Where(b => b.IsDeleted == false)
               .ToListAsync();
        }
    }
}
