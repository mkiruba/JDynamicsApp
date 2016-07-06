namespace JDynamicsApp.Service.Calculator
{
    public class IntCalculator : ICalculatorBase<int>
    {
        public int Add(int operand1, int operand2)
        {
            return operand1 + operand2;
        }

        public int Divide(int operand1, int operand2)
        {
            return operand1 / operand2;
        }

        public int Subtract(int operand1, int operand2)
        {
            return operand1 - operand2;
        }
    }
}