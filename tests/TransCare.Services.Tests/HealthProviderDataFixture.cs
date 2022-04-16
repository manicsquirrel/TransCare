using Microsoft.EntityFrameworkCore;
using System;
using TransCare.Data;
using TransCare.Models;

namespace TransCare.Services.Tests
{
    public class HealthProviderDataFixture : IDisposable
    {
        public TransCareContextDb TransCareContext { get; private set; } = 
            new TransCareContextDb(new DbContextOptionsBuilder<TransCareContextDb>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options);

        public HealthProviderDataFixture()
        {
            TransCareContext.HealthProviders.Add(new HealthProvider { Id = 1, Latitude = 47.245658, Longitude = -68.577575, ProviderName = "Fort Kent Family Planning", Notes = "", Email = "", Phone = "", Url = "", City = "Fort Kent", State = new State { Code = "ME", Name = "Maine" }, Street = "139 Market St", ZipCode = "04743" });
            TransCareContext.HealthProviders.Add(new HealthProvider { Id = 2, Latitude = 44.548562, Longitude = -69.630567, ProviderName = "Waterville Family Planning", Notes = "", Email = "", Phone = "", Url = "", City = "Waterville", State = new State { Code = "ME", Name = "Maine" }, ZipCode = "04901" });
            TransCareContext.HealthProviders.Add(new HealthProvider { Id = 3, Latitude = 44.824192, Longitude = -68.736230, ProviderName = "Mabel Wadsworth Center", Notes = "", Email = "", Phone = "", Url = "", City = "Bangor", State = new State { Code = "ME", Name = "Maine" }, Street = "700 Mt Hope Ave", ZipCode = "04401" });
            TransCareContext.HealthProviders.Add(new HealthProvider { Id = 4, Latitude = 44.489903, Longitude = -73.206145, ProviderName = "Community Health Centers of Burlington", Notes = "", Email = "", Phone = "", Url = "", City = "Burlington", State = new State { Code = "VT", Name = "Vermont" }, Street = "617 Riverside Ave", ZipCode = "05401" });
            TransCareContext.HealthProviders.Add(new HealthProvider { Id = 5, Latitude = 43.201864, Longitude = -71.535041, ProviderName = "Equality Health Center", Notes = "", Email = "", Phone = "", Url = "", City = "Concord", State = new State { Code = "NH", Name = "New Hampshire" }, Street = "38 S Main St", ZipCode = "03301" });
            TransCareContext.SaveChanges();
        }

        public void Dispose()
        {
            TransCareContext.Dispose();
        }
    }
}