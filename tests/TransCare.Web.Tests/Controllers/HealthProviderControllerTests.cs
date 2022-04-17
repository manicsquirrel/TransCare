using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using System.Threading.Tasks;
using TransCare.Interfaces;
using TransCare.Models;
using TransCare.Services.Abstractions;
using TransCare.Web.Models.Requests;
using TransCare.Web.Models.Responses;
using TransCare.Web.Tests;
using Xunit;

namespace TransCare.Web.Controllers.Tests
{
    public class HealthProviderControllerTests
    {
        private HealthProviderController sut;

        public HealthProviderControllerTests()
        {
            Fixture fixture = new();
            fixture.Customize(new AutoMoqCustomization());
            var service = fixture.Freeze<Mock<IHealthProviderService>>();
            var mapper = fixture.Freeze<Mock<IMapper>>();
            sut = new HealthProviderController(service.Object, mapper.Object);
        }

        [Theory]
        [AutoMoqData]
        public async Task GetById_When_Valid_Returns_Ok(int id)
        {
            // Act
            var actualResult = await sut.GetAsync(id) as OkObjectResult;

            // Assert
            Assert.Equal(200, actualResult?.StatusCode);
        }

        [Theory]
        [AutoMoqData]
        public async Task Search_When_Valid_Returns_Ok(string query, double latitude, double longitude)
        {
            // Act
            var healthProviderFilterRequest = new HealthProviderFilterRequest
            {
                Query = query,
                Latitude = latitude,
                Longitude = longitude
            };
            var actualResult = await sut.SearchAsync(healthProviderFilterRequest) as OkObjectResult;

            // Assert
            Assert.Equal(200, actualResult?.StatusCode);
        }
    }
}