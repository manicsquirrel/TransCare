namespace TransCare.Web.Models.Requests
{
    public class HealthProviderFilterRequest
    {
        public string Query { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}