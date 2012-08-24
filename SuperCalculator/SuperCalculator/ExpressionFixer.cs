using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SuperCalculator
{
    public class ExpressionFixer
    {
        public void FixExpressions(List<MathExpression> expressions)
        {
            bool listHasChanged = true;
            while (listHasChanged)
            {
                listHasChanged = false;
                for (int i = 0; i < expressions.Count; i++)
                {
                    expressions[i].Expression = expressions[i].Expression.Trim();
                    if (MathRegex.IsNumberAndOperator(expressions[i].Expression))
                    {
                        splitByOperator(expressions, expressions[i].Expression, i);
                        listHasChanged = true;
                        break;
                    }
                    if (expressions[i].IsEmpty())
                    {
                        expressions.RemoveAt(i);
                        listHasChanged = true;
                        break;
                    }
                }
            }
        }

        private void splitByOperator(List<MathExpression> expressions,
            string inputExpression, int position)
        {
            string[] nextExps = Regex.Split(inputExpression, @"([+|\-|/|*])");
            int j = position;
            expressions.RemoveAt(j);
            foreach (string subExp in nextExps)
            {
                expressions.Insert(j, new MathExpression(subExp.Trim()));
                j++;
            }
        }
    }
}
