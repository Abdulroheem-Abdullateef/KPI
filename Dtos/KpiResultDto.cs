using KpiNew.Entities;
using KpiNew.Enum;
using System;
using System.Collections.Generic;

namespace KpiNew.Dtos
{
    public class KpiResultDto
    {
        public int Id { get; set; }
        public IList<KpiFormDto> KpiForms { get; set; } = new List<KpiFormDto>();
        public int EmployeeId { get; set; }
        public Month Month { get; set; }
        public int Year { get; set; }
        public DateTime DateCreated { get; set; }
        public double TotalPercentage { get; set; }

    }

    public class CreateKpiResultRequestModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Month Month { get; set; }
        public int Year { get; set; }
        public DateTime DateCreated { get; set; }
        public double TotalPercentage { get; set; }

        public IList<CreateKpiFormResultRequestModel> KpiForms = new List<CreateKpiFormResultRequestModel>(); 


    }
    public class CreateKpiFormResultRequestModel
    {
        public double Percentage { get; set; }
        public int KpiId { get; set; }
    }

    public class UpdateKpiResultRequestModel
    {
        public int EmployeeId { get; set; }
        public Month Month { get; set; }
        public int Year { get; set; }
        public DateTime DateCreated { get; set; }
        public double TotalPercentage { get; set; }

    }
}