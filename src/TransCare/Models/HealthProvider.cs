namespace TransCare.Models
{
    public class HealthProvider
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string ProviderName { get; set; }

        public string Notes { get; set; }

        public string Phone { get; set; }

        public string Url { get; set; }

        public string City { get; set; }

        public string StateCode { get; set; }

        public State State { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }

        public double Distance { get; set; }
    }
}