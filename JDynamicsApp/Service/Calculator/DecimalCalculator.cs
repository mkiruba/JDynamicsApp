namespace JDynamicsApp.Service.Calculator
{
    public class DecimalCalculator : ICalculatorBase<decimal>
    {
        public decimal Add(decimal operand1, decimal operand2)
        {
            return operand1 + operand2;
        }

        public decimal Divide(decimal operand1, decimal operand2)
        {
            return operand1 / operand2;
        }

        public decimal Subtract(decimal operand1, decimal operand2)
        {
            return operand1 - operand2;
        }
    }
}