using System.Collections.Generic;
using JDynamicsApp.Data.Models;
using JDynamicsApp.Data.DbContext;
using System;

namespace JDynamicsApp.Data.Repository
{
    public class CalculateRepository : ICalculateRepository
    {
        private CalculationDbContext _dbContext;
        public CalculateRepository(CalculationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Save(CalculationResult calc)
        {
            _dbContext.Calculations.Add(calc);
            return _dbContext.SaveChanges() > 0;           
        }

        public IEnumerable<CalculationResult> GetCalculations()
        {
            return _dbContext.Calculations;
        }

        public IEnumerable<Operation> GetOperations()
        {
            return _dbContext.Operations;
        }
    }
}