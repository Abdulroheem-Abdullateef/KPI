using System.Collections.Generic;

namespace KpiNew.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<Kpi> Kpis {get; set;} = new List<Kpi>();


    }
}