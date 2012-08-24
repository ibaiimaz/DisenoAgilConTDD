using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SuperCalculator
{
    public class ExpressionValidator
    {
        public bool IsExpressionValid(string expression)
        {
            Regex regex = new Regex(@"^-{0,1}\d+((\s+)[+|\-|/|*](\s+)-{0,1}\d+)+$");
            return regex.IsMatch(expression, 0);
        }
    }
}
