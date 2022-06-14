using KpiNew.Dtos;
using KpiNew.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KpiNew.Interface.Service
{
    public interface IEmployeeService
    {
        Task<BaseRespond<EmployeeDto>> AddEmployeeAsync(CreateEmployeeRequestModel model);
        Task<BaseRespond<EmployeeDto>> UpdateEmployeeAsync(int id, UpdateEmployeeRequestModel model);
        Task<BaseRespond<EmployeeDto>> DeleteEmployeeAsync(int id);
        Task<BaseRespond<EmployeeDto>> GetEmployeeByIdAsync(int id);
        Task<BaseRespond<ICollection<EmployeeDto>>> GetAllEmployeeDepartmentByNameAsync( string departmentname);
        Task<BaseRespond<ICollection<EmployeeDto>>> GetAllEmployeeAsync();
        Task<BaseRespond<EmployeeDto>> GetEmployeeByName(string name);
        Task<BaseRespond<ICollection<EmployeeDto>>> GetAllHodAsync();



    }
}