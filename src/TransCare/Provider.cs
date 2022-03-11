using System.Text.RegularExpressions;

namespace TransCare
{
    public class Provider
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Name { get; set; }

        public string Notes { get; set; }

        public string Phone { get; set; }

        public string Web { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }

        public string FullAddress => $"{Street}, {City} {State} {ZipCode}";

        public string CombinedProperties => $"{Email ?? ""} {Name} {Notes ?? ""} {Phone ?? ""} {Web ?? ""} {Street ?? ""}, {City ?? ""} {State ?? ""} {ZipCode ?? ""}";
    }
}