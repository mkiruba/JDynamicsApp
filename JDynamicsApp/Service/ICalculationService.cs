using JDynamicsApp.Models;
using System.Collections.Generic;

namespace JDynamicsApp.Service
{
    public interface ICalculationService
    {
        void Calculate(CalculationModel calculationModel);
        IEnumerable<CalculationModel> GetResults();
        IEnumerable<OperationModel> GetOperations();
    }
}
