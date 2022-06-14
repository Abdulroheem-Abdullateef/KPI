using KpiNew.Dtos;
using KpiNew.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KpiNew.Interface.Service
{
    public interface IKpiResultService
    {
        Task<BaseRespond<KpiResultDto>> AddKpiResultAsync(CreateKpiResultRequestModel model);
        Task<BaseRespond<KpiResultDto>> UpdateKpiResultAsync(int id, UpdateKpiResultRequestModel model);
        Task<BaseRespond<KpiResultDto>> DeleteKpiResultAsync(int id);
        Task<BaseRespond<KpiResultDto>> GetKpiResultByIdAsync(int id);
        Task<BaseRespond<ICollection<KpiResultDto>>> GetAllKpiResultAsync();
        Task<BaseRespond<ICollection<KpiResultDto>>> GetAllEmployeeKpiResultAsync( int employeeId);
        Task<BaseRespond<KpiResultDto>> GetEmployeeKpiResultByMonthAsync(int employeeId, Month month);
        Task<BaseRespond<KpiResultDto>> GetEmployeeKpiResultByYearAsync(int employeeId, int year);
    }
}
