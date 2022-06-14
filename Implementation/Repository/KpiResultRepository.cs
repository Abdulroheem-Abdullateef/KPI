using KpiNew.Context;
using KpiNew.Dtos;
using KpiNew.Entities;
using KpiNew.Enum;
using KpiNew.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KpiNew.Implementation.Repository
{
    public class KpiResultRepository : BaseRepository<KpiResult>, IKpiResultRepository
    {

        public KpiResultRepository( ApplicationContext context)
        {
            _context = context;
        }
        public async Task<KpiResult> Get(Expression<Func<KpiResult, bool>> expression)
        {
            return await _context.KpiResults.Include(a => a.Employee)
                 .ThenInclude(d => d.Department)
                 .Where(a => a.IsDeleted == false)
                 .SingleOrDefaultAsync(expression);
        }

        public async Task<IList<KpiResult>> GetAll()
        {
            return await _context.KpiResults.Include(a => a.Employee)
                  .ThenInclude(d => d.Department).ThenInclude(a => a.Employees)
                  .ThenInclude(k => k.KpiResults).ToListAsync();
                
        }

        public async Task<IList<KpiResultDto>> GetAllEmployeeId(int employeeId)
        {
            return await _context.KpiResults.Include(a => a.Employee).Where(a => a.EmployeeId == employeeId)
            .Select(a => new KpiResultDto
            {
                DateCreated = a.DateCreated,
                Month = a.Month,
                Year = a.Year,
                TotalPercentage = a.TotalPercentage,
                KpiForms = a.KpiForm.Select(k => new KpiFormDto
                {
                    Id = k.Id,
                    KpiId = k.KpiId,
                    KpiResultId = k.KpiResultId,
                    Percentage = k.Percentage,
                }).ToList()

            }).ToListAsync();
        }

        public async Task<KpiResultDto> GetEmployeeKpiResultByMonth(int employeeId, Month month)
        {
            var x = await _context.KpiResults
              .Where(r => r.Id == employeeId && r.Month == month).Select(e => new KpiResultDto
              {
                  DateCreated = e.DateCreated,
                  Month = e.Month,
                  TotalPercentage = e.TotalPercentage,
                  Year = e.Year,
                  KpiForms = e.KpiForm.Select(k => new KpiFormDto
                  {
                      Id = k.Id,
                      KpiId = k.KpiId,
                      KpiResultId = k.KpiResultId,
                      Percentage = k.Percentage,
                      
                      
                  }).ToList()

              }).FirstOrDefaultAsync();
            return x;
        }

        public async Task<KpiResultDto> GetEmployeeKpiResultByYear(int employeeId, int year)
        {
            var x = await _context.KpiResults
             .Where(r => r.Id == employeeId && r.Year == year).Select(e => new KpiResultDto
             {
                 DateCreated = e.DateCreated,
                 Month = e.Month,
                 TotalPercentage = e.TotalPercentage,
                 Year = e.Year,

             }).FirstOrDefaultAsync();
            return x;
        }

        public async Task<KpiResult> GetKpiResultById(int id)
        {
            return await _context.KpiResults.Include(a => a.Employee)
                 .ThenInclude(d => d.Department).ThenInclude(d => d.Employees)
                 .ThenInclude(d => d.KpiResults).Where(a => a.IsDeleted == false)
                 .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IList<KpiResult>> GetSelected(IList<int> ids)
        {
            return await _context.KpiResults.Include(a => a.Employee)
                 .ThenInclude(d => d.Department).ThenInclude(d => d.Employees)
                 .ThenInclude(d => d.KpiResults).Where(a => a.IsDeleted == false)
                 .Where(a => ids.Contains(a.Id)).ToListAsync();
        }

        public async Task<IList<KpiResult>> GetSelected(Expression<Func<KpiResult, bool>> expression)
        {
            return await _context.KpiResults.Include(a => a.Employee)
                .ThenInclude(d => d.Department).ThenInclude(d => d.Employees)
                .ThenInclude(d => d.KpiResults).Where(a => a.IsDeleted == false)
                .Where(expression).ToListAsync();
        }
    }
}
