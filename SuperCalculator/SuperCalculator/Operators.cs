using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCalculator
{
    public class MultiplyOperator : MathOperator
    {
        public MultiplyOperator()
            : base(2)
        {
            _token = "*";
        }

        public override int Resolve(int a, int b)
        {
            return _calcProxy.BinaryOperation(
                   _calcProxy.Calculator.Multiply, a, b);
        }
    }

    public class DivideOperator : MathOperator
    {
        public DivideOperator()
            : base(2)
        {
            _token = "/";
        }

        public override int Resolve(int a, int b)
        {
            return _calcProxy.BinaryOperation(
                   _calcProxy.Calculator.Divide, a, b);
        }
    }

    public class AddOperator : MathOperator
    {
        public AddOperator()
            : base(1)
        {
            _token = "+";
        }

        public override int Resolve(int a, int b)
        {
            return _calcProxy.BinaryOperation(
                   _calcProxy.Calculator.Add, a, b);
        }
    }

    public class SubstractOperator : MathOperator
    {
        public SubstractOperator()
            : base(1)
        {
            _token = "-";
        }

        public override int Resolve(int a, int b)
        {
            return _calcProxy.BinaryOperation(
                   _calcProxy.Calculator.Substract, a, b);
        }
    }
}
