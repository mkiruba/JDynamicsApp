using System;
using JDynamicsApp.Service.Calculator;

namespace JDynamicsApp.Service.Factories
{   
    public class CalculatorFactory
    {
        public static ICalculatorBase<T> CreateInstance<T>() where T : struct
        {
            Type type = typeof(T);
            if (type == typeof(int))
            {
                return new IntCalculator() as ICalculatorBase<T>;
            }
            else if (type == typeof(long))
            {
                return new LongCalculator() as ICalculatorBase<T>;
            }
            else if (type == typeof(decimal))
            {
                return new DecimalCalculator() as ICalculatorBase<T>;
            }            
            else
            {
                throw new InvalidOperationException("Invalid type");
            }
        }
    }
}