using KpiNew.Dtos;
using KpiNew.Entities;
using KpiNew.Interface;
using KpiNew.Interface.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KpiNew.Implementation.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService( IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<BaseRespond<RoleDto>> AddRoleAsync(CreateRoleRequestModel model)
        {
             var roleExist = await _roleRepository.Get(a => a.Name == model.Name);
            if (roleExist != null)
            {
                return new BaseRespond<RoleDto>
                {
                    Message = "Admin already exist",
                    Success = false,
                };
            }

            else
            {
                var role = new Role
                {
                    
                    Name = model.Name,
                    Description = model.Description,
                   
                };

                await _roleRepository.Create(role);
                return new BaseRespond<RoleDto>
                {
                    Success = true,
                    Message = "Role Create Successfully",
                    Data = new RoleDto
                    {
                        Id = role.Id,
                        Name = role.Name,
                        Description = role.Description
                    }
                };
            }


        }

        public async Task<BaseRespond<RoleDto>> DeleteRoleAsync(int id)
        {
            var role = await _roleRepository.GetRoleById(id);
            if (role == null)
            {
                return new BaseRespond<RoleDto>
                {
                    Message = "Role not found",
                    Success = true,

                };
            }
            role.IsDeleted = true;
            _roleRepository.SaveChanges();

            return new BaseRespond<RoleDto>
            {
                Success = true,
                Message = $"Role with {role.Name} was delete Successfully",
              
            };
        }

        public async Task<BaseRespond<ICollection<RoleDto>>> GetAllRoleAsync()
        {
            var role = await _roleRepository.GetAll();
            var roles = role.Select(a => new RoleDto
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                
            }).ToList();
            return new BaseRespond<ICollection<RoleDto>>
            {
                Success = true,
                Data = roles,
                Message = "Role Retrieved"
            };
        }

        public async Task<BaseRespond<RoleDto>> GetRoleByIdAsync(int id)
        {
                  var role = await _roleRepository.GetRoleById(id);
            if (role == null)
                {return new BaseRespond<RoleDto>
                {
                    Message = $"role does not exixt",
                    Success = false,
                };
            }
            return new BaseRespond<RoleDto>
            {
                Success = true,
                Data = new RoleDto
                {
                    Name = role.Name,
                    Description = role.Description
                },
                Message = "Role Retrieved"
            };
        }

        public async Task<BaseRespond<RoleDto>> UpdateRoleAsync(int id, UpdateRoleRequestModel model)
        {
             var role = await _roleRepository.GetRoleById(id);
            if (role == null)
            {
                return new BaseRespond<RoleDto>
                {
                    Message = $"Role does not exixt",
                    Success = false,
                };
            }
            else
            {
                role.Name = model.Name;
                role.Description = model.Description;
                await _roleRepository.Update(role);

                return new BaseRespond<RoleDto>
                {
                    Success = true,
                    Message = $"{role.Name} Successfully Update",
                    Data = new RoleDto
                    {
                        Name = role.Name,
                        Description = role.Description,
                    }
                };
            }   
        }
    }
}