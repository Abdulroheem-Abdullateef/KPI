using KpiNew.Enum;
using System;
using System.Collections.Generic;

namespace KpiNew.Entities
{
    public class KpiResult : BaseEntity
    {
        public Employee Employee {get; set;}
        public int EmployeeId {get; set;}
        public Month Month {get; set;}
        public int Year {get; set;}
        public DateTime DateCreated {get; set;}
        public double TotalPercentage { get; set;}
        public IList<KpiForm> KpiForm { get; set; } = new List<KpiForm>();  
        
    }
}