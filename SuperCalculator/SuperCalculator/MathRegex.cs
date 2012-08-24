using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SuperCalculator
{
    public class MathRegex
    {
        public static string operators = @"[*|\-|/|+]";

        public static bool IsExpressionValid(string expression)
        {
            Regex fullRegex = new Regex(@"^-{0,1}\d+((\s+)" +
                operators + @"(\s+)-{0,1}\d+)+$");
            return (fullRegex.IsMatch(expression, 0) ||
                    IsNumber(expression) ||
                    IsOperator(expression));
        }

        public static bool IsNumberAndOperator(string expression)
        {
            Regex startsWithOperator =
                new Regex(@"^(\s*)(" + operators + @")(\s+)");
            Regex endsWithOperator =
                new Regex(@"(\s+)(" + operators + @")(\s*)$");
            
            string exp = expression;
            if (startsWithOperator.IsMatch(exp) ||
                 endsWithOperator.IsMatch(exp))
                return true;
            return false;
        }

        public static bool IsSubExpression(string expression)
        {
            Regex operatorRegex = new Regex(operators);
            Regex numberRegex = new Regex(@"\d+");
            if (numberRegex.IsMatch(expression) &&
                operatorRegex.IsMatch(expression))
                return true;
            return false;
        }

        public static bool IsNumber(string token)
        {
            return IsExactMatch(token, @"\d+");
        }

        public static bool IsOperator(string token)
        {
            return IsExactMatch(token, operators);
        }

        public static bool IsExactMatch(string token, string regex)
        {
            Regex exactRegex = new Regex(@"^" + regex + "$");
            return exactRegex.IsMatch(token, 0);
        }

    }
}
