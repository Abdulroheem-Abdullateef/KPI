using System.Collections.Generic;

namespace KpiNew.Entities

{
    public class Kpi : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}