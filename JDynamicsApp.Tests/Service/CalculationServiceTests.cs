using Microsoft.VisualStudio.TestTools.UnitTesting;
using JDynamicsApp.Data.Repository;
using JDynamicsApp.Data.Models;
using JDynamicsApp.App_Start;
using Moq;
using JDynamicsApp.Models;
using JDynamicsApp.Data.DbContext;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace JDynamicsApp.Service.Tests
{
    [TestClass()]
    public class CalculationServiceTests
    {
        private Mock<ICalculateRepository> _mockCalculateRepository;
        private Mock<CalculationDbContext> _mockCalculationDbContext;
        private Mock<DbSet<CalculationResult>> _mockDbSetCalculationResult;
        private Mock<DbSet<Operation>> _mockDbSetOperation;

        [TestInitialize]
        public void Initialize()
        {            
            _mockCalculationDbContext = new Mock<CalculationDbContext>();
            _mockCalculateRepository = new Mock<ICalculateRepository>();
            _mockDbSetCalculationResult = new Mock<DbSet<CalculationResult>>();
            _mockDbSetOperation = new Mock<DbSet<Operation>>();
            Automapper.Initialize();
        }

        [TestMethod()]
        public void TestCalculate_Add_Integer()
        {
            string operand1 = "5";
            string operand2 = "10";
            string expected = "15";
            CalculationModel calculationModel = new CalculationModel()
            {
                Operand1 = operand1,
                Operand2 = operand2,
                Operation = new OperationModel() { Name = "Add"}
            };


            var service = new CalculationService(_mockCalculateRepository.Object);
            _mockCalculationDbContext.Setup(x => x.Calculations).Returns(_mockDbSetCalculationResult.Object);
            _mockCalculateRepository.Setup(x => x.Save(calculationModel.ToEntity()))
                .Returns(true);

            service.Calculate(calculationModel);

            Assert.AreEqual(expected, calculationModel.Result);
            _mockCalculateRepository.Verify(x => x.Save(It.IsAny<CalculationResult>()), Times.Once);            
        }

        [TestMethod()]
        public void TestCalculate_Subtract_Integer()
        {
            string operand1 = "10";
            string operand2 = "5";
            string expected = "5";
            CalculationModel calculationModel = new CalculationModel()
            {
                Operand1 = operand1,
                Operand2 = operand2,
                Operation = new OperationModel() { Name = "Subtract" }
            };


            var service = new CalculationService(_mockCalculateRepository.Object);
            _mockCalculationDbContext.Setup(x => x.Calculations).Returns(_mockDbSetCalculationResult.Object);
            _mockCalculateRepository.Setup(x => x.Save(calculationModel.ToEntity()))
                .Returns(true);

            service.Calculate(calculationModel);

            Assert.AreEqual(expected, calculationModel.Result);
            _mockCalculateRepository.Verify(x => x.Save(It.IsAny<CalculationResult>()), Times.Once);
        }

        [TestMethod()]
        public void TestCalculate_Divide_Integer()
        {
            string operand1 = "10";
            string operand2 = "5";
            string expected = "2";
            CalculationModel calculationModel = new CalculationModel()
            {
                Operand1 = operand1,
                Operand2 = operand2,
                Operation = new OperationModel() { Name = "Divide" }
            };


            var service = new CalculationService(_mockCalculateRepository.Object);
            _mockCalculationDbContext.Setup(x => x.Calculations).Returns(_mockDbSetCalculationResult.Object);
            _mockCalculateRepository.Setup(x => x.Save(calculationModel.ToEntity()))
                .Returns(true);

            service.Calculate(calculationModel);

            Assert.AreEqual(expected, calculationModel.Result);
            _mockCalculateRepository.Verify(x => x.Save(It.IsAny<CalculationResult>()), Times.Once);
        }

        [TestMethod()]
        public void GetResultsTest()
        {
            var results = new List<CalculationResult>
            {
                new CalculationResult() { Id =1, Operand1 ="10", Operand2 = "20", Result = "30"},
                new CalculationResult() { Id =2, Operand1 ="50", Operand2 = "70", Result = "120"}
            }.AsQueryable();
            
            
            _mockDbSetCalculationResult.As<IQueryable<CalculationResult>>().Setup(x => x.Provider).Returns(results.Provider);
            _mockDbSetCalculationResult.As<IQueryable<CalculationResult>>().Setup(x => x.Expression).Returns(results.Expression);
            _mockDbSetCalculationResult.As<IQueryable<CalculationResult>>().Setup(x => x.ElementType).Returns(results.ElementType);
            _mockDbSetCalculationResult.As<IQueryable<CalculationResult>>().Setup(x => x.GetEnumerator()).Returns(results.GetEnumerator());
            _mockCalculationDbContext.Setup(x => x.Calculations).Returns(_mockDbSetCalculationResult.Object);
            _mockCalculateRepository.Setup(x => x.GetCalculations()).Returns(results);
            var service = new CalculationService(_mockCalculateRepository.Object);

            var actualresults =  service.GetResults().ToList();
            
            _mockCalculateRepository.Verify(x => x.GetCalculations(), Times.Once);
            Assert.AreEqual(results.Count(), actualresults.Count);
            Assert.AreEqual("30", actualresults[0].Result);
            Assert.AreEqual("70", actualresults[1].Operand2);
        }

        [TestMethod()]
        public void GetOperationsTest()
        {
            var results = new List<Operation>
            {
                new Operation() { Id =1, Name ="Add", Description = "Add Numbers"},
                new Operation() { Id =2,  Name ="Subtract", Description = "Subtract Numbers"}
            }.AsQueryable();


            _mockDbSetCalculationResult.As<IQueryable<Operation>>().Setup(x => x.Provider).Returns(results.Provider);
            _mockDbSetCalculationResult.As<IQueryable<Operation>>().Setup(x => x.Expression).Returns(results.Expression);
            _mockDbSetCalculationResult.As<IQueryable<Operation>>().Setup(x => x.ElementType).Returns(results.ElementType);
            _mockDbSetCalculationResult.As<IQueryable<Operation>>().Setup(x => x.GetEnumerator()).Returns(results.GetEnumerator());
            _mockCalculationDbContext.Setup(x => x.Operations).Returns(_mockDbSetOperation.Object);
            _mockCalculateRepository.Setup(x => x.GetOperations()).Returns(results);
            var service = new CalculationService(_mockCalculateRepository.Object);

            var actualresults = service.GetOperations().ToList();

            _mockCalculateRepository.Verify(x => x.GetOperations(), Times.Once);
            Assert.AreEqual(results.Count(), actualresults.Count);
            Assert.AreEqual("Add", actualresults[0].Name);
        }
    }
}

