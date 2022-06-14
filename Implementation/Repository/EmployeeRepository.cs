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
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Employee> Get(Expression<Func<Employee, bool>> expression)
        {

            return await _context.Employees
                  .Include(a => a.Department)
               .Include(e => e.KpiResults)
               .ThenInclude(e => e.KpiForm)
                   .Where(b => b.IsDeleted == false)
                  .SingleOrDefaultAsync(expression);

        }

        public async Task<IList<Employee>> GetAll()
        {
             return await _context.Employees
                .Include(a => a.Department)
               .Include(e => e.KpiResults)
               .ThenInclude(a => a.KpiForm)
               .Where(b => b.IsDeleted == false)
                .ToListAsync();   
        }

        public async Task<ICollection<Employee>> GetAllEmployeeDepartmentAsync(int departmentId)
        {
            return await _context.Employees
             .Include(a => a.Department)
               .Include(e => e.KpiResults)
               .ThenInclude(a => a.KpiForm)
               .Where(d => d.DepartmentId == departmentId).ToListAsync();
        }

        public async Task<ICollection<Employee>> GetAllEmployeeDepartmentByNameAsync(string departmentName)
        {
            return await _context.Employees
               .Include(a => a.Department)
               .Include(e => e.KpiResults)
               .ThenInclude(a => a.KpiForm)
               .Where(b => b.IsDeleted == false && b.Department.Name == departmentName)
               .ToListAsync();
        }

        public async Task<ICollection<Employee>> GetAllHodAsync()
        {
            return await _context.Employees
               .Include(a => a.Department)
              .Include(e => e.KpiResults)
              .ThenInclude(a => a.KpiForm)
              .Include(u => u.User)
              .ThenInclude(ur => ur.UserRoles)
              .ThenInclude(r => r.Role)
              .Where(b => b.User.UserRoles.Any(a => a.Role.Name == "HOD"))
              .ToListAsync();
              
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees
                .Include(a => a.Department)
               .Include(e => e.KpiResults)
               .ThenInclude(a => a.KpiForm)
               .Where(b => b.IsDeleted == false)
                .SingleOrDefaultAsync(a => a.Id==id);
        }
        public async Task<IList<Employee>> GetSelected(IList<int> ids)
        {
             return await _context.Employees
                  .Include(a => a.Department)
               .Include(e => e.KpiResults)
               .ThenInclude(a => a.KpiForm)
                   .Where(b => b.IsDeleted == false)
                  .Where(a => ids.Contains(a.Id)).ToListAsync();
        }

        public async Task<IList<Employee>> GetSelected(Expression<Func<Employee, bool>> expression)
        {
             return await _context.Employees
                  .Include(a => a.Department)
               .Include(e => e.KpiResults)
               .ThenInclude(a => a.KpiForm)
                   .Where(b => b.IsDeleted == false)
                  .Where(expression).ToListAsync();
        }
    }
}