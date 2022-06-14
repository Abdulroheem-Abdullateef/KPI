using System.Collections.Generic;

namespace KpiNew.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
        public ICollection<KpiDto> Kpis { get; set; } = new List<KpiDto>();

    }

    public class CreateDepartmentRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }


    public class UpdateDepartmentRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }

}