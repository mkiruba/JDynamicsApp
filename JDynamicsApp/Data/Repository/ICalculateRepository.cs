using JDynamicsApp.Data.Models;
using System.Collections.Generic;

namespace JDynamicsApp.Data.Repository
{
    public interface ICalculateRepository
    {
        bool Save(CalculationResult calc);
        IEnumerable<CalculationResult> GetCalculations();
        IEnumerable<Operation> GetOperations();
    }
}
