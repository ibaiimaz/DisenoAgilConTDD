using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCalculator
{
    public class Resolver
    {
        Lexer _lexer;
        TokenPrecedence _precedence;

        public Resolver(Lexer lexer,TokenPrecedence precedence)
        {
            _lexer = lexer;
            _precedence = precedence;
        }

        public int ResolveSimpleExpression(string expression)
        {
            if (!MathRegex.IsExpressionValid(expression))
                throw new InvalidOperationException(expression);
            
            List<MathToken> mathExp = _lexer.GetTokens(expression);
            while (mathExp.Count > 1)
            {
                MathToken op = _precedence.GetMaxPrecedence(mathExp);
                op.PreviousToken = mathExp[op.Index - 1];
                op.NextToken = mathExp[op.Index + 1];
                int result = op.Resolve();
                replaceTokensWithResult(mathExp, op.Index, result);
            }
            return mathExp[0].Resolve();
        }

        private void replaceTokensWithResult(List<MathToken> tokens,
            int indexOfOperator, int result)
        {
            tokens[indexOfOperator - 1] = new MathNumber(result.ToString());
            tokens.RemoveAt(indexOfOperator);
            tokens.RemoveAt(indexOfOperator);
        }
    }
}
