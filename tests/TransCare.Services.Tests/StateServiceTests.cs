using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TransCare.Data;
using TransCare.Data.Entities;
using TransCare.Interfaces;
using TransCare.Models;
using Xunit;
using Xunit.Abstractions;

namespace TransCare.Services.Tests
{
    public class StateServiceTests
    {
        [Fact()]
        public void GetAllTest()
        {
            var expectedResult = new List<State>
            {
                new State { Code="AR" , Name ="Arkansas"},
                new State { Code="AR" , Name ="Arkansas"},
                new State { Code="AZ" , Name ="Arizona"},
                new State { Code="AK" , Name ="Alaska"},
                new State { Code="NV" , Name ="Nevada"},
                new State { Code="NM" , Name ="New Mexico"}
            };

            var stateRepositoryMock = new Mock<IStateRepository>();
            stateRepositoryMock.Setup(c => c.GetAll()).Returns(expectedResult.AsEnumerable());
            var stateService = new StateService(stateRepositoryMock.Object);

            // Act
            var actualResult = stateService.GetAll();

            // Assert
            CollectionAssert.AreEquivalent(expectedResult, actualResult.ToList());
        }
    }
}