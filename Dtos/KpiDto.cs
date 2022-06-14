using KpiNew.Entities;
using KpiNew.Enum;
using System.Collections.Generic;

namespace KpiNew.Dtos
{
    public class KpiDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Month Month { get; set; }

        public IList<CreateKpiFormResultRequestModel> KpiForms = new List<CreateKpiFormResultRequestModel>();

    }

    public class CreateKpiRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
    }

    public class UpdateKpiRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
    }


}