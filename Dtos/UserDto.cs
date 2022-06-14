using KpiNew.Entities;
using System.Collections.Generic;

namespace KpiNew.Dtos
{
    public class UserDto
    {
        public int Id {get; set;}
        public string Email { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }
        public Employee  Employee { get; set; }
        public ICollection<RoleDto> Roles { get; set; } = new List<RoleDto>();

    }

    public class CreateUserRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
       
    }

    public class UpdateUserRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
       
    }

    public class LoginUserDto
    {
         public string Email { get; set; }
        public string Password { get; set; }
    }
}