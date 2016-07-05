using JDynamicsApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JDynamicsApp.Data.Models;
using JDynamicsApp.Models;

namespace JDynamicsApp.Service
{
    public class CalculationService : ICalculationService
    {
        private readonly ICalculateRepository _calculateRepository;
        public CalculationService(ICalculateRepository calculateRepository)
        {
            _calculateRepository = calculateRepository;
        }
        public void Calculate(CalculationModel calculationModel)
        {
            calculationModel.Result = calculationModel.Operand1 + calculationModel.Operand2;
            _calculateRepository.Save(calculationModel.ToEntity());            
        }

        public IEnumerable<OperationModel> GetOperations()
        {
            return _calculateRepository.GetOperations().Select(x => x.ToModel());
        }

        public IEnumerable<CalculationModel> GetResults()
        {            
            return _calculateRepository.GetCalculations().Select(x => x.ToModel());
        }
    }
}