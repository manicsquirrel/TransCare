using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace TransCare
{
    public class Provider
    {
        public int Id { get; set; }

        //public string Email { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public string ProviderName { get; set; }

        public string Notes { get; set; }

        public string Phone { get; set; }

        public string Url { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }


        public string FullAddress => $"{Street}, {City} {State} {ZipCode}";

        //public string CombinedProperties => $"{Email ?? ""} {Name} {Notes ?? ""} {Phone ?? ""} {Url ?? ""} {Street ?? ""}, {City ?? ""} {State ?? ""} {ZipCode ?? ""}";
    }
}