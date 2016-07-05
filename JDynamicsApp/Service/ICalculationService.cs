using JDynamicsApp.Data.Models;
using JDynamicsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDynamicsApp.Service
{
    public interface ICalculationService
    {
        void Calculate(CalculationModel calculationModel);
        IEnumerable<CalculationModel> GetResults();
        IEnumerable<OperationModel> GetOperations();
    }
}
