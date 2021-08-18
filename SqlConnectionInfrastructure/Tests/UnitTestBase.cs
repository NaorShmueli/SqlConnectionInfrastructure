using DAL;
using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class UnitTestBase
    {
        protected readonly MockRepository _mockRepository;
        protected readonly IConfiguration _configuration;
        internal readonly Mock<PersonAdoRepository> _personAdoRepository;
        protected Mock<ILogger<DataAccessConnector>> _logger;
        protected Mock<ILoggerFactory> _loggerFactory;
        protected readonly Mock<ISqlHelper> _sqlHelper;
        protected readonly Mock<IPersonInitializationDataTable> _personInitializationDataTable;

        public UnitTestBase()
        {
            _mockRepository = new MockRepository(MockBehavior.Default);
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();
            _logger = _mockRepository.Create<ILogger<DataAccessConnector>>();
            _sqlHelper = _mockRepository.Create<ISqlHelper>();
            _personInitializationDataTable = _mockRepository.Create<IPersonInitializationDataTable>();
            _loggerFactory = _mockRepository.Create<ILoggerFactory>();
            _personAdoRepository = new Mock<PersonAdoRepository> { CallBase = true };
        }
    }
}
