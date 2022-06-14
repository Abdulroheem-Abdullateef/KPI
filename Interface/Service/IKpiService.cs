using KpiNew.Dtos;
using KpiNew.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KpiNew.Interface
{
    public interface IKpiService
    {
        Task<BaseRespond<KpiDto>> AddKpiAsync(CreateKpiRequestModel model);
        Task<BaseRespond<KpiDto>> UpdateKpiAsync(int id, UpdateKpiRequestModel model);
        Task<BaseRespond<KpiDto>> DeleteKpiAsync(int id);
        Task<BaseRespond<KpiDto>> GetKpiByIdAsync(int id);
        Task<BaseRespond<ICollection<KpiDto>>> GetAllKpiAsync();
        Task<BaseRespond<ICollection<KpiDto>>> GetAllKpiByDepartmentIdAsync(int departmentId);


    }
}