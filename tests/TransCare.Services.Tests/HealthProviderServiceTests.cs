using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using TransCare.Interfaces;
using TransCare.Models;
using Xunit;

namespace TransCare.Services.Tests
{
    public class HealthProviderServiceTests
    {
        [Fact()]
        public void DeleteTest()
        {
            // Arrange
            var providerRepositoryMock = new Mock<IProviderRepository>();

            // Act
            providerRepositoryMock.Object.Delete(1);

            // Assert
            providerRepositoryMock.Verify(x => x.Delete(1), Times.Once);
        }

        [Fact()]
        public void GetAllTest()
        {
            // Arrange
            var expectedResult = new List<HealthProvider>
            {
                new HealthProvider {Id=1,Latitude=47.245658,Longitude=-68.577575,ProviderName="Fort Kent Family Planning",Notes="",Email="",Phone="",Url="",City="Fort Kent",State=new State{Code="ME",Name="Maine" },Street="139 Market St",ZipCode="04743"},
                new HealthProvider {Id=2,Latitude=44.548562,Longitude=-69.630567,ProviderName="Waterville Family Planning",Notes="",Email="",Phone="",Url="",City="Waterville",State=new State{Code="ME",Name="Maine" },ZipCode="04901"},
                new HealthProvider {Id=3,Latitude=44.824192,Longitude=-68.736230,ProviderName="Mabel Wadsworth Center",Notes="",Email="",Phone="",Url="",City="Bangor",State=new State{Code="ME",Name="Maine" },Street="700 Mt Hope Ave",ZipCode="04401"},
                new HealthProvider {Id=4,Latitude=44.489903,Longitude=-73.206145,ProviderName="Community Health Centers of Burlington",Notes="",Email="",Phone="",Url="",City="Burlington",State=new State{Code="VT",Name="Vermont" },Street="617 Riverside Ave",ZipCode="05401"},
                new HealthProvider {Id=5,Latitude=43.201864,Longitude=-71.535041,ProviderName="Equality Health Center",Notes="",Email="",Phone="",Url="",City="Concord",State=new State{Code="NH",Name="New Hampshire" },Street="38 S Main St",ZipCode="03301"},
            };
            var providerRepositoryMock = new Mock<IProviderRepository>();
            providerRepositoryMock.Setup(p => p.GetAll()).Returns(expectedResult.AsEnumerable());
            var providerService = new HealthProviderService(providerRepositoryMock.Object);

            // Act
            var actualResult = providerService.GetAll();

            // Assert
            CollectionAssert.AreEquivalent(expectedResult, actualResult.ToList());
        }

        [Fact()]
        public void GetFilteredTest()
        {
            // Arrange
            var query = "Fort";
            var expectedResult = new List<HealthProvider>
            {
                new HealthProvider {Id=1,Latitude=47.245658,Longitude=-68.577575,ProviderName="Fort Kent Family Planning",Notes="",Email="",Phone="",Url="",City="Fort Kent",State=new State{Code="ME",Name="Maine" },Street="139 Market St",ZipCode="04743"},
            };
            var providerRepositoryMock = new Mock<IProviderRepository>();
            providerRepositoryMock.Setup(p => p.GetFiltered(query)).Returns(expectedResult.AsEnumerable());
            var providerService = new HealthProviderService(providerRepositoryMock.Object);

            // Act
            var actualResult = providerService.GetFiltered(query);

            // Assert
            CollectionAssert.AreEquivalent(expectedResult, actualResult.ToList());
        }

        [Fact()]
        public void GetTest()
        {
            var expectedResult = new HealthProvider { Id = 1, Latitude = 47.245658, Longitude = -68.577575, ProviderName = "Fort Kent Family Planning", Notes = "", Email = "", Phone = "", Url = "", City = "Fort Kent", State = new State { Code = "ME", Name = "Maine" }, Street = "139 Market St", ZipCode = "04743" };
            var providerRepositoryMock = new Mock<IProviderRepository>();
            providerRepositoryMock.Setup(p => p.Get(1)).Returns(expectedResult);
            var providerService = new HealthProviderService(providerRepositoryMock.Object);

            // Act
            var actualResult = providerService.Get(1);

            // Assert
            Xunit.Assert.Equal(expectedResult, actualResult);
        }

        [Fact()]
        public void SaveTest()
        {
            // Arrange
            var expectedResult = new HealthProvider { Id = 1, Latitude = 47.245658, Longitude = -68.577575, ProviderName = "Fort Kent Family Planning", Notes = "", Email = "", Phone = "", Url = "", City = "Fort Kent", State = new State { Code = "ME", Name = "Maine" }, Street = "139 Market St", ZipCode = "04743" };
            var providerRepositoryMock = new Mock<IProviderRepository>();
            providerRepositoryMock.Setup(p => p.Save(expectedResult)).Returns(expectedResult);
            var providerService = new HealthProviderService(providerRepositoryMock.Object);

            // Act
            var actualResult = providerService.Save(expectedResult);

            // Assert
            Xunit.Assert.Equal(expectedResult, actualResult);
        }
    }
}