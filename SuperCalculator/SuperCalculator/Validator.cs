using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCalculator
{
    public class Validator : LimitsValidator
    {
        private int _upperLimit;
        private int _lowerLimit;

        public Validator(int lowerLimit, int upperLimit)
        {
            SetLimits(lowerLimit, upperLimit);
        }

        public int LowerLimit
        {
            get { return _lowerLimit; }
            set { _lowerLimit = value; }
        }

        public int UpperLimit
        {
            get { return _upperLimit; }
            set { _upperLimit = value; }
        }

        public void ValidateArgs(int arg1, int arg2)
        {
            breakIfOverflow(arg1, "First argument exceeds limits");
            breakIfOverflow(arg2, "Second argument exceeds limits");
        }

        public void ValidateResult(int result)
        {
            breakIfOverflow(result, "Result exceeds limits");
        }

        private void breakIfOverflow(int arg, string msg)
        {
            if (ValueExceedLimits(arg))
                throw new OverflowException(msg);
        }

        public bool ValueExceedLimits(int arg)
        {
            if (arg > _upperLimit)
                return true;
            if (arg < _lowerLimit)
                return true;
            return false;
        }

        public void SetLimits(int lower, int upper)
        {
            _lowerLimit = lower;
            _upperLimit = upper;
        }
    }
}
