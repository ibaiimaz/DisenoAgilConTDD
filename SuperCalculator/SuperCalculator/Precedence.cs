using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCalculator
{
    public interface TokenPrecedence
    {
        MathToken GetMaxPrecedence(List<MathToken> tokens);
    }

    public class Precedence : TokenPrecedence
    {
        public MathToken GetMaxPrecedence(List<MathToken> tokens)
        {
            int precedence = 0;
            MathToken maxPrecedenceToken = null;

            int index = -1;
            foreach (MathToken token in tokens)
            {
                index++;
                if (token.Precedence >= precedence)
                {
                    precedence = token.Precedence;
                    maxPrecedenceToken = token;
                    maxPrecedenceToken.Index = index;
                }
            }
            return maxPrecedenceToken;
        }
    }
}
