using KpiNew.Enum;
using KpiNew.Entities;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace KpiNew.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string EmployeeImage { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<KpiResultDto> KpiResults { get; set; } = new List<KpiResultDto>();


    }

    public class CreateEmployeeRequestModel
    {
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "")]
        public string Password { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string Address { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string City { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "")]
        public string PhoneNumber { get; set; }

        public string EmployeeImage { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public IList<int> Roles { get; set; } = new List<int>();

    }

    public class UpdateEmployeeRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string EmployeeImage { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

    }

    public class LoginRespondeModel : BaseRespond<UserDto>
    {
        public string Token { get; set; }
    }


}