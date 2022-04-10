using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using TransCare.Services.Abstractions;
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
        public void GetById_When_Valid_Returns_Ok(int id)
        {
            // Act
            var actualResult = sut.Get(id) as OkObjectResult;

            // Assert
            Assert.Equal(200, actualResult?.StatusCode);
        }

        [Theory]
        [AutoMoqData]
        public void Search_When_Valid_Returns_Ok(string query)
        {
            // Act
            var actualResult = sut.Search(query) as OkObjectResult;

            // Assert
            Assert.Equal(200, actualResult?.StatusCode);
        }
    }
}