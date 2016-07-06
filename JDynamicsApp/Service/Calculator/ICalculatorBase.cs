namespace JDynamicsApp.Service.Calculator
{
    public interface ICalculatorBase<T> where T : struct
    {
        T Add(T operand1, T operand2);
        T Divide(T operand1, T operand2);
        T Subtract(T operand1, T operand2);
    }
}