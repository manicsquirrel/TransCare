using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransCare.Interfaces;
using TransCare.Models;
using Xunit;

namespace TransCare.Services.Tests
{
    public class StateServiceTests
    {
        [Fact()]
        public async Task GetAllTest()
        {
            // Arrange
            var repositoryMock = new Mock<IStateRepository>();
            repositoryMock
                .Setup(r => r.GetAllAsync())
                .Returns(Task.FromResult(new List<State>
                {
                    new State { Code="AR" , Name ="Arkansas"},
                    new State { Code="AZ" , Name ="Arizona"}
                }.AsEnumerable()));
            var sut = new StateService(repositoryMock.Object);

            // Act
            var providers = await sut.GetAllAsync();

            // Assert
            repositoryMock.Verify(r => r.GetAllAsync());
            Xunit.Assert.Equal("Arkansas", providers.ElementAt(0).Name);
            Xunit.Assert.Equal("Arizona", providers.ElementAt(1).Name);
        }
    }
}