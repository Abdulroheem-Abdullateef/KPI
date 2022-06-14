using KpiNew.Dtos;
using KpiNew.Entities;
using KpiNew.Enum;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KpiNew.Interface.Repository
{
    public interface IKpiResultRepository : IRepository<KpiResult>
    {
        public Task<KpiResult> GetKpiResultById(int id);
        public Task<KpiResult> Get(Expression<Func<KpiResult, bool>> expression);
        public Task<IList<KpiResult>> GetSelected(IList<int> ids);
        public Task<IList<KpiResult>> GetSelected(Expression<Func<KpiResult, bool>> expression);
        public Task<IList<KpiResult>> GetAll();
        public Task<IList<KpiResultDto>> GetAllEmployeeId(int employeeId);
        public Task<KpiResultDto> GetEmployeeKpiResultByMonth(int employeeId, Month month);
        public Task<KpiResultDto> GetEmployeeKpiResultByYear(int employeeId, int year); 

    }
}
