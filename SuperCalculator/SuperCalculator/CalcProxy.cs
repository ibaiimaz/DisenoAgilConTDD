using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SuperCalculator
{
    public class CalcProxy
    {
        private BasicCalculator _calculator;
        private LimitsValidator _validator;

        public CalcProxy(LimitsValidator validator,
                           BasicCalculator calculator)
        {
            _calculator = calculator;
            _validator = validator;
        }

        public int BinaryOperation(SingleBinaryOperation operation, int arg1, int arg2)
        {
            _validator.ValidateArgs(arg1, arg2);

            int result = 0;
            MethodInfo[] calcultatorMethods = _calculator.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach (MethodInfo method in calcultatorMethods)
            {
                if (method == operation.Method)
                {
                    result = (int)method.Invoke(_calculator, new Object[] { arg1, arg2 });
                }
            }
            _validator.ValidateResult(result);
            return result;
        }
    }
}
