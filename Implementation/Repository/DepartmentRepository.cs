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
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {

        public DepartmentRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Department> Get(Expression<Func<Department, bool>> expression)
        {
           return await _context.Departments
           .Include(e => e.Employees).ThenInclude(a => a.KpiResults)
           .Include(b => b.Kpis)
           .Where(d => d.IsDeleted == false)
           .SingleOrDefaultAsync(expression);
        }

        public async Task<IList<Department>> GetAll()
        {
           return await _context.Departments
           .Include(a => a.Employees).ThenInclude(a => a.KpiResults)
           .Where(a => a.IsDeleted == false).ToListAsync();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _context.Departments
            .Include(a => a.Employees).ThenInclude(a => a.KpiResults)
            .Where(a => a.IsDeleted == false)
            .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IList<Department>> GetSelected(IList<int> ids)
        {
            return await _context.Departments
            .Include(e => e.Employees).ThenInclude(a => a.KpiResults)
            .Where(a => a.IsDeleted == false)
            .Where(a => ids.Contains(a.Id))
            .ToListAsync();
        }

        public async Task<IList<Department>> GetSelected(Expression<Func<Department, bool>> expression)
        {
            return await _context.Departments
            .Include(e => e.Employees).ThenInclude(a => a.KpiResults)
            .Where(a => a.IsDeleted == false)
            .Where(expression).ToListAsync();
        }
    }
}