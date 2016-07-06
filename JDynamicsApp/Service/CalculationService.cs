using JDynamicsApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using JDynamicsApp.Models;
using JDynamicsApp.Service.Factories;

namespace JDynamicsApp.Service
{
    public class CalculationService : ICalculationService
    {
        private const string ADD = "Add";
        private const string SUB = "Subtract";
        private const string DIV = "Divide";
        private readonly ICalculateRepository _calculateRepository;
        public CalculationService(ICalculateRepository calculateRepository)
        {
            _calculateRepository = calculateRepository;
        }
        public void Calculate(CalculationModel calculationModel)
        {
            switch (calculationModel.Operation.Name)
            {
                case ADD:
                    calculationModel.Result = Add(calculationModel);
                    break;
                case SUB:
                    calculationModel.Result = Subtract(calculationModel);
                    break;
                case DIV:
                    calculationModel.Result = Divide(calculationModel);
                    break;
                default:
                    throw new InvalidOperationException("Invalid operation.");
                    break;
            }
            
            _calculateRepository.Save(calculationModel.ToEntity());            
        }

        private string Divide(CalculationModel calculationModel)
        {
            int intOperand1;
            int intOperand2;
            int intResult;
            if (int.TryParse(calculationModel.Operand1, out intOperand1) && int.TryParse(calculationModel.Operand2, out intOperand2))
            {
                var calculator = CalculatorFactory.CreateInstance<int>();
                intResult = calculator.Divide(intOperand1, intOperand2);
                return intResult.ToString();
            }

            long longOperand1;
            long longOperand2;
            long longResult;
            if (long.TryParse(calculationModel.Operand1, out longOperand1) && long.TryParse(calculationModel.Operand2, out longOperand2))
            {
                var calculator = CalculatorFactory.CreateInstance<long>();
                longResult = calculator.Divide(longOperand1, longOperand2);
                return longResult.ToString();
            }

            decimal decimalOperand1;
            decimal decimalOperand2;
            decimal decimalResult;
            if (decimal.TryParse(calculationModel.Operand1, out decimalOperand1) && decimal.TryParse(calculationModel.Operand2, out decimalOperand2))
            {
                var calculator = CalculatorFactory.CreateInstance<decimal>();
                decimalResult = calculator.Divide(decimalOperand1, decimalOperand2);
                return decimalResult.ToString();
            }
            
            return string.Empty;
        }

        private string Subtract(CalculationModel calculationModel)
        {
            int intOperand1;
            int intOperand2;
            int intResult;
            if (int.TryParse(calculationModel.Operand1, out intOperand1) && int.TryParse(calculationModel.Operand2, out intOperand2))
            {
                var calculator = CalculatorFactory.CreateInstance<int>();
                intResult = calculator.Subtract(intOperand1, intOperand2);
                return intResult.ToString();
            }

            long longOperand1;
            long longOperand2;
            long longResult;
            if (long.TryParse(calculationModel.Operand1, out longOperand1) && long.TryParse(calculationModel.Operand2, out longOperand2))
            {
                var calculator = CalculatorFactory.CreateInstance<long>();
                longResult = calculator.Subtract(longOperand1, longOperand2);
                return longResult.ToString();
            }

            decimal decimalOperand1;
            decimal decimalOperand2;
            decimal decimalResult;
            if (decimal.TryParse(calculationModel.Operand1, out decimalOperand1) && decimal.TryParse(calculationModel.Operand2, out decimalOperand2))
            {
                var calculator = CalculatorFactory.CreateInstance<decimal>();
                decimalResult = calculator.Subtract(decimalOperand1, decimalOperand2);
                return decimalResult.ToString();
            }
            
            return string.Empty;
        }

        private string Add(CalculationModel calculationModel)
        {
            int intOperand1;
            int intOperand2;
            int intResult;
            if (int.TryParse(calculationModel.Operand1, out intOperand1) && int.TryParse(calculationModel.Operand2, out intOperand2))
            {
                var calculator = CalculatorFactory.CreateInstance<int>();
                intResult = calculator.Add(intOperand1, intOperand2);
                return intResult.ToString();
            }

            long longOperand1;
            long longOperand2;
            long longResult;
            if (long.TryParse(calculationModel.Operand1, out longOperand1) && long.TryParse(calculationModel.Operand2, out longOperand2))
            {
                var calculator = CalculatorFactory.CreateInstance<long>();
                longResult = calculator.Add(longOperand1, longOperand2);
                return longResult.ToString();
            }

            decimal decimalOperand1;
            decimal decimalOperand2;
            decimal decimalResult;
            if (decimal.TryParse(calculationModel.Operand1, out decimalOperand1) && decimal.TryParse(calculationModel.Operand2, out decimalOperand2))
            {
                var calculator = CalculatorFactory.CreateInstance<decimal>();
                decimalResult = calculator.Add(decimalOperand1, decimalOperand2);
                return decimalResult.ToString();
            }
            
            return string.Empty;
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