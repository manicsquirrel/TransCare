namespace TransCare.Web.Models.Requests
{
    public class HealthProviderNearMeRequest
    {
        public int Take { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}