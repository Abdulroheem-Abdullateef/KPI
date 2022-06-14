namespace KpiNew.Entities
{
    public class KpiForm : BaseEntity
    {
        public int KpiResultId { get; set; }
        public KpiResult KpiResult { get; set; }
        public int KpiId { get; set; }
        public Kpi Kpis { get; set; }
        public double Percentage { get; set; }


    }
}
