using JDynamicsApp.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JDynamicsApp.Data.Repository;
using JDynamicsApp.Data.Models;
using JDynamicsApp.App_Start;
using Moq;

namespace JDynamicsApp.Service.Tests
{
    [TestClass()]
    public class CalculationServiceTests
    {
        private Mock<ICalculateRepository> _mockCalculateRepository;
        [TestInitialize]
        public void Initialize()
        {
            _mockCalculateRepository = new Mock<ICalculateRepository>();
            Automapper.Initialize();
        }

        [TestMethod()]
        public void CalculateTest()
        {
            int operand1 = 5;
            int operand2 = 10;
            int expected = 15;
            CalculationResult calculationEntity = new CalculationResult() { Operand1 = operand1, Operand2 = operand2, Result = expected };


            var service = new CalculationService(_mockCalculateRepository.Object);
            _mockCalculateRepository.Setup(x => x.Save(calculationEntity))
                .Returns(true);

            service.Calculate(calculationEntity.ToModel());

            _mockCalculateRepository.Verify(x => x.Save(calculationEntity), Times.Once);
        }

        [TestMethod()]
        public void GetOperationsTest()
        {
            Assert.Fail();
        }
    }
}