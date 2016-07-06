using Microsoft.VisualStudio.TestTools.UnitTesting;
using JDynamicsApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JDynamicsApp.Models;
using JDynamicsApp.Service;
using Moq;

namespace JDynamicsApp.Controllers.Tests
{
    [TestClass()]
    public class OperationControllerTests
    {
        private Mock<ICalculationService> _mockCalculationService;
        [TestInitialize]
        public void Initialize()
        {
            _mockCalculationService = new Mock<ICalculationService>();
        }

        [TestMethod()]
        public void GetTest()
        {
            // Arrange
            List<OperationModel> operationModels = new List<OperationModel>()
            {
                new OperationModel() { Name ="Add"},
                new OperationModel() { Name ="Subtract"},
                new OperationModel() { Name ="Divide"}
            };

            OperationController controller = new OperationController(_mockCalculationService.Object);
            _mockCalculationService.Setup(x => x.GetOperations())
               .Returns(operationModels);

            // Act
            IEnumerable<OperationModel> results = controller.Get();

            // Assert            
            Assert.AreEqual(operationModels.Count, results.Count());
        }
    }
}