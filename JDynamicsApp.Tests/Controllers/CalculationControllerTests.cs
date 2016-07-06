using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using JDynamicsApp.Models;
using JDynamicsApp.Service;
using Moq;

namespace JDynamicsApp.Controllers.Tests
{
    [TestClass()]
    public class CalculationControllerTests
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
            List<CalculationModel> calculationModels = new List<CalculationModel>()
            {
                new CalculationModel() { Operand1 = "5", Operand2 = "10", Result = "15"},
                new CalculationModel() { Operand1 = "15", Operand2 = "10", Result = "25"},                
                new CalculationModel() { Operand1 = "5", Operand2 = "40", Result = "45"}
            };

            CalculationController controller = new CalculationController(_mockCalculationService.Object);
            _mockCalculationService.Setup(x => x.GetResults())
               .Returns(calculationModels);

            // Act
            IEnumerable<CalculationModel> results = controller.Get();

            // Assert            
            Assert.AreEqual(calculationModels.Count, results.Count());
           
        }
    }
}