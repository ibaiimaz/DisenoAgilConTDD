using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCalculator
{
    public class MathNumber : MathToken
    { 
        public MathNumber()
            : base(0)
        {}

        public MathNumber(string token)
            : base (token)
        {}

        public int IntValue
        {
            get { return Int32.Parse(_token); }
        }

        public override int Resolve()
        {
            return IntValue;
        }
    }
}
