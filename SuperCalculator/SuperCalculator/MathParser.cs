using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCalculator
{
    public class MathParser
    {
        Lexer _lexer;
        Resolver _resolver;

        public MathParser(Lexer lexer, Resolver resolver)
        {
            _lexer = lexer;
            _resolver = resolver;
        }

        public int ProcessExpression(string expression)
        {
            List<MathExpression> subExpressions =
                _lexer.GetExpressions(expression);
            String flatExpression = String.Empty;
            foreach (MathExpression subExp in subExpressions)
            {
                if (MathRegex.IsSubExpression(subExp.Expression))
                    flatExpression +=
                        _resolver.ResolveSimpleExpression(subExp.Expression);
                else
                    flatExpression += " " + subExp.Expression + " ";
            }
            return _resolver.ResolveSimpleExpression(flatExpression);
        }
    }
}
