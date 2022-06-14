using KpiNew.Dtos;
using KpiNew.Interface.Repository;
using KpiNew.Interface.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KpiNew.Implementation.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<BaseRespond<ICollection<UserDto>>> GetAllUserAsync()
        {
            var user = await _userRepository.GetAll();
            var users = user.ToList().Select(user => new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Roles = user.UserRoles.Select(b => new RoleDto
                {
                    Id = b.Role.Id,
                    Name = b.Role.Name
                }).ToList()


            }).ToList();
            return new BaseRespond<ICollection<UserDto>>
            {
                Success = true,
                Data = users,
                Message = "User Retrieved"
            };

        }

        public async Task<BaseRespond<UserDto>> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.Get(d => d.Email == email);
            if (user == null)
            {
                return new BaseRespond<UserDto>
                {
                    Message = $" User with does not exist",
                    Success = false,
                };
            }

            return new BaseRespond<UserDto>
            {
                Success = true,
                Message = $"User with {user.Email} was retrieved Successfully",
                Data = new UserDto
                {

                    Email = user.Email,
                    Password = user.Password,
                    Roles = user.UserRoles.Select(b => new RoleDto
                    {
                        Id = b.Role.Id,
                        Name = b.Role.Name
                    }).ToList()
                }
            };
        }

        public async Task<BaseRespond<UserDto>> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return new BaseRespond<UserDto>
                {
                    Message = "User does not exist",
                    Success = false,
                };

            }
            return new BaseRespond<UserDto>
            {
                Success = true,
                Data = new UserDto
                {
                    Email = user.Email,
                    Password = user.Password,
                    Roles = user.UserRoles.Select(b => new RoleDto
                    {
                        Id = b.Role.Id,
                        Name = b.Role.Name
                    }).ToList()

                },
                Message = "User Retrieved"
            };

        }

        public async Task<BaseRespond<UserDto>> Login(LoginUserDto model)
        {
            var user = await _userRepository.GetByEmail(model.Email);

            if (user == null || user.Password != model.Password)
                return new BaseRespond<UserDto>
                {
                    Message = "Invalid Email Or Password",
                    Success = false,
                };

            return new BaseRespond<UserDto>
            {
                Success = true,
                Message = "Login Successful",
                Data = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Password = user.Password,
                    Department = user.Employee.Department.Name,
                    Roles = user.UserRoles.Select(b => new RoleDto
                    {
                        Id = b.Role.Id,
                        Name = b.Role.Name
                    }).ToList()

                }
            };
        }
    }
}