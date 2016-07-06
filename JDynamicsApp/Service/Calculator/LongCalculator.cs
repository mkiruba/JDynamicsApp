namespace JDynamicsApp.Service.Calculator
{
    public class LongCalculator : ICalculatorBase<long>
    {
        public long Add(long operand1, long operand2)
        {
            return operand1 + operand2;
        }

        public long Divide(long operand1, long operand2)
        {
            return operand1 / operand2;
        }

        public long Subtract(long operand1, long operand2)
        {
            return operand1 - operand2;
        }
    }
}