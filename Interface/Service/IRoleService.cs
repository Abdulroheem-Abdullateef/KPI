using KpiNew.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KpiNew.Interface
{
    public interface IRoleService
    {
         Task<BaseRespond<RoleDto>> AddRoleAsync(CreateRoleRequestModel model);
        Task<BaseRespond<RoleDto>> UpdateRoleAsync(int id, UpdateRoleRequestModel model);
        Task<BaseRespond<RoleDto>> DeleteRoleAsync(int id);
        Task<BaseRespond<RoleDto>> GetRoleByIdAsync(int id);
        Task<BaseRespond<ICollection<RoleDto>>> GetAllRoleAsync();
        
    }
}