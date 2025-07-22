using System;

namespace CalcLibrary
{
    public interface ICalculatorOperations
    {
        double Add(double x, double y);
        double Subtract(double x, double y);
        double Multiply(double x, double y);
        double Divide(double x, double y);
    }

    public class SimpleCalculator : ICalculatorOperations
    {
        private double _lastResult = 0;

        public double Add(double x, double y)
        {
            _lastResult = x + y;
            return _lastResult;
        }

        public double Subtract(double x, double y)
        {
            _lastResult = x - y;
            return _lastResult;
        }

        public double Multiply(double x, double y)
        {
            _lastResult = x * y;
            return _lastResult;
        }

        public double Divide(double x, double y)
        {
            if (y == 0)
                throw new ArgumentException("Cannot divide by zero.");
            _lastResult = x / y;
            return _lastResult;
        }

        public void Reset()
        {
            _lastResult = 0;
        }

        public double Result
        {
            get { return _lastResult; }
        }
    }
}
