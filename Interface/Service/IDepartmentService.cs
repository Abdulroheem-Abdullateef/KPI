using KpiNew.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KpiNew.Interface.Service
{
    public interface IDepartmentService
    {
        Task<BaseRespond<DepartmentDto>> AddDepartmentAsync(CreateDepartmentRequestModel model);
        Task<BaseRespond<DepartmentDto>> UpdateDepartmentAsync(int id, UpdateDepartmentRequestModel model);
        Task<BaseRespond<DepartmentDto>> DeleteDepartmentAsync(int id);
        Task<BaseRespond<DepartmentDto>> GetDepartmentAsyncById(int id);
        Task<BaseRespond<ICollection<DepartmentDto>>> GetAllDepartmentAsync();  
        Task<BaseRespond<DepartmentDto>> GetDepartmentByName(string name);

    }
}