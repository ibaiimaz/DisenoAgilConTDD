using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCalculator
{
    public class Calculator : BasicCalculator
    {

        public int Add(int arg1, int arg2)
        {
            int result = arg1 + arg2;
            //if (result > _upperLimit)
            //    throw new OverflowException("Upper limit exceeded");

            return result;
        }


        public int Substract(int arg1, int arg2)
        {
            int result = arg1 - arg2;
            //if (result < _lowerLimit)
            //    throw new OverflowException("Lower limit exceeded");

            return result;
        }
    }
}
