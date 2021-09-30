using AdoTemplate.Abstraction;
using DAL;
using DAL.DB;
using DAL.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class DataAccessConnectorTests : UnitTestBase
    {
        private readonly IDataAccessConnector _dataAccessConnector;
        private readonly Mock<AdoRepository<Person>> _mockAdoRepository;
        public DataAccessConnectorTests()
        {
            _mockAdoRepository = _mockRepository.Create<AdoRepository<Person>>();
            _dataAccessConnector = new DataAccessConnector(_logger.Object, _loggerFactory.Object, _configuration, _sqlHelper.Object, _personInitializationDataTable.Object, _mockAdoRepository.Object);
        }

        [Fact]
        public async Task GetPersonTest()
        {
            //Arrange
            var result = new List<Person> { new Person { Address = "SomeAddress", Age = 30, City = "Holon", FirstName = "Naor", LastName= "Shmueli", Id = "123456" } };
            _personAdoRepository.Setup(x => x.ExecuteQueryAsync(It.IsAny<SqlCommand>())).Returns(Task.FromResult<IEnumerable<Person>>(result));
            //Act
            var person = await _dataAccessConnector.GetPerson("123456");
            //Assert
            Assert.True(person.Id == "123456");
        }
    }
}
