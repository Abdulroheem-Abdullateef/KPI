namespace KpiNew.Dtos
{
    public class BaseRespond<T>
    {
     public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; } 
    }
}