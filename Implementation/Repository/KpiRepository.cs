using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KpiNew.Context;
using KpiNew.Entities;
using KpiNew.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace KpiNew.Implementation.Repository
{
    public class KpiRepository : BaseRepository<Kpi>, IKpiRepository
    {
        public KpiRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Kpi> Get(Expression<Func<Kpi, bool>> expression)
        {
                 return await _context.Kpis
                  .Include(a => a.Department)
                  .ThenInclude(k => k.Employees).ThenInclude(a => a.KpiResults)
                  .ThenInclude(a => a.KpiForm)
                 .Where(a => a.IsDeleted == false)
                  .SingleOrDefaultAsync(expression);

        }

        public async Task<IList<Kpi>> GetAll()
        {
             return await _context.Kpis
                  .Include(a => a.Department)
                  .ThenInclude(a => a.Employees).ThenInclude(k => k.KpiResults)
                  .ThenInclude(a => a.KpiForm)
                 .Where(a => a.IsDeleted == false).ToListAsync();
              

        }

        public async Task<Kpi> GetKpiById(int id)
        {
             return await _context.Kpis
                  .Include(a => a.Department)
                  .ThenInclude(a => a.Employees).ThenInclude(k => k.KpiResults)
                  .ThenInclude(a => a.KpiForm)
                 .Where(a => a.IsDeleted == false)
                  .SingleOrDefaultAsync(a => a.Id == id);

        }

        public async Task<IList<Kpi>> GetSelected(IList<int> ids)
        {
            return await _context.Kpis
            .Include(a => a.Department)
                  .ThenInclude(a => a.Employees).ThenInclude(k => k.KpiResults)
                  .ThenInclude(a => a.KpiForm)
            .Where(a => a.IsDeleted == false)
            .Where(a => ids.Contains(a.Id)).ToListAsync();
        }

        public async Task<IList<Kpi>> GetSelected(Expression<Func<Kpi, bool>> expression)
        {
           return await _context.Kpis
           .Include(a => a.Department)
                  .ThenInclude(a => a.Employees).ThenInclude(k => k.KpiResults)
                  .ThenInclude(a => a.KpiForm)
                  .Where(a => a.IsDeleted == false)
                  .Where(expression).ToListAsync(); 
           
        }
    }
}