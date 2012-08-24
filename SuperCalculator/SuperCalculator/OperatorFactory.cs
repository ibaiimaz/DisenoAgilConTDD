using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCalculator
{
    public class OperatorFactory
    {
        public static MathOperator Create(MathToken token)
        {
            return Create(token.Token);
        }

        public static MathOperator Create(string token)
        {
            if (token == "*")
                return new MultiplyOperator();
            else if (token == "/")
                return new DivideOperator();
            else if (token == "+")
                return new AddOperator();
            else if (token == "-")
                return new SubstractOperator();

            throw new InvalidOperationException(
                "The given token is not a valid operator");
        }

        
    }
}
