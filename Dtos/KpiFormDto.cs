using KpiNew.Entities;
namespace KpiNew.Dtos
{
    public class KpiFormDto
    {
        public int Id { get; set; }
        public int KpiResultId { get; set; }
        public int KpiId { get; set; }
        public double Percentage { get; set; }
    }

    //public class CreateKpiFormRequestModel
    //{
    //    public int KpiResultId { get; set; }
    //    public int KpiId { get; set; }
    //    public double Percentage { get; set; }
    //}

    public class UpdateKpiFormRequestModel
    {
        public int KpiResultId { get; set; }
        public int KpiId { get; set; }
        public double Percentage { get; set; }
    }
  
}