using Microsoft.Extensions.Options;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransCare.Interfaces;
using TransCare.Models;
using Xunit;

namespace TransCare.Services.Tests
{
    public class HealthProviderServiceTests
    {
        [Fact()]
        public async Task GetAllTest()
        {
            // Arrange
            var repositoryMock = new Mock<IHealthProviderRepository>();
            repositoryMock
                .Setup(r => r.GetAllAsync())
                .Returns(Task.FromResult(new List<HealthProvider>
                {
                    new HealthProvider
                    {
                        Id = 1,
                        Latitude = 47.245658,
                        Longitude = -68.577575,
                        ProviderName = "Fort Kent Family Planning",
                        Notes = "",
                        Email = "",
                        Phone = "",
                        Url = "",
                        City = "Fort Kent",
                        State = new State { Code = "ME", Name = "Maine" },
                        Street = "139 Market St",
                        ZipCode = "04743"
                    },
                    new HealthProvider
                    {
                        Id = 2,
                        Latitude = 44.548562,
                        Longitude = -69.630567,
                        ProviderName = "Waterville Family Planning",
                        Notes = "",
                        Email = "",
                        Phone = "",
                        Url = "",
                        City = "Waterville",
                        State = new State { Code = "ME", Name = "Maine" },
                        ZipCode = "04901"
                    }
                }.AsEnumerable()));
            var sut = new HealthProviderService(repositoryMock.Object, new Mock<IOptionsMonitor<ApiKeyOptions>>().Object);

            // Act
            var providers = await sut.GetAllAsync();

            // Assert
            repositoryMock.Verify(r => r.GetAllAsync());
            Xunit.Assert.Equal("Fort Kent Family Planning", providers.ElementAt(0).ProviderName);
            Xunit.Assert.Equal("Waterville Family Planning", providers.ElementAt(1).ProviderName);
        }

        [Fact()]
        public async Task GetFilteredTest()
        {
            // Arrange
            var query = "fort";
            var repositoryMock = new Mock<IHealthProviderRepository>();
            repositoryMock
                .Setup(r => r.GetFilteredAsync(query))
                .Returns(Task.FromResult(new List<HealthProvider>
                {
                    new HealthProvider
                    {
                        Id = 1,
                        Latitude = 47.245658,
                        Longitude = -68.577575,
                        ProviderName = "Fort Kent Family Planning",
                        Notes = "",
                        Email = "",
                        Phone = "",
                        Url = "",
                        City = "Fort Kent",
                        State = new State { Code = "ME", Name = "Maine" },
                        Street = "139 Market St",
                        ZipCode = "04743"
                    }
                }.AsEnumerable()));
            var sut = new HealthProviderService(repositoryMock.Object, new Mock<IOptionsMonitor<ApiKeyOptions>>().Object);

            // Act
            var providers = await sut.GetFilteredAsync(query);

            // Assert
            repositoryMock.Verify(r => r.GetFilteredAsync(query));
            Xunit.Assert.Equal("Fort Kent Family Planning", providers.ElementAt(0).ProviderName);
        }

        [Fact()]
        public async Task GetTest()
        {
            // Arrange
            var repositoryMock = new Mock<IHealthProviderRepository>();
            repositoryMock
                .Setup(r => r.GetAsync(1))
                .Returns(Task.FromResult(new HealthProvider
                {
                    Id = 1,
                    Latitude = 47.245658,
                    Longitude = -68.577575,
                    ProviderName = "Fort Kent Family Planning",
                    City = "Fort Kent",
                    State = new State { Code = "ME", Name = "Maine" },
                    Street = "139 Market St",
                    ZipCode = "04743"
                }));
            var sut = new HealthProviderService(repositoryMock.Object, new Mock<IOptionsMonitor<ApiKeyOptions>>().Object);

            // Act
            var actualResult = await sut.GetAsync(1);

            // Assert
            repositoryMock.Verify(r => r.GetAsync(1));
            Xunit.Assert.Equal("Fort Kent Family Planning", actualResult.ProviderName);
        }
    }
}