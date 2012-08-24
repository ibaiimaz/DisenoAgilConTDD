using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperCalculator;
using Rhino.Mocks;

namespace SuperCalculatorTests
{
    [TestClass]
    public class ParserTests
    {
        MathLexer _lexer;
        MathRegex _mathRegex;
        ExpressionFixer _fixer;
        MathParser _parser;
        Calculator _calculator;
        CalculatorProxy _calcProxy;
        Resolver _resolver;

        [TestInitialize()]
        public void SetUp()
        {
            _mathRegex = new MathRegex();
            _fixer = new ExpressionFixer();
            _lexer = new MathLexer(_fixer);
            _calculator = new Calculator();
            _calcProxy = new CalcProxy(new Validator(-100, 100),
                                           _calculator);
            _resolver = new Resolver(_lexer, new Precedence());
            _parser = new MathParser(_lexer, _resolver);
        }

        [TestMethod]
        public void ProcessSimpleExpression()
        {
            Assert.AreEqual(4, _parser.ProcessExpression("2 + 2"));
        }

        [TestMethod]
        public void ProcessExpression2Operators()
        {
            Assert.AreEqual(6, _parser.ProcessExpression("3 + 1 + 2"));
        }

        [TestMethod]
        public void ProcessExpressionWithPrecedence()
        {
            Assert.AreEqual(9, _parser.ProcessExpression("3 + 3 * 2"));
        }

        [TestMethod]
        public void ProcessAcceptanceExpression()
        {
            Assert.AreEqual(9, _parser.ProcessExpression("5 + 4 * 2 / 2"));
        }

        [TestMethod]
        public void ProcessAcceptanceExpressionWithAllOperators()
        {
            Assert.AreEqual(8, _parser.ProcessExpression("5 + 4 - 1 * 2 / 2"));
        }

        [TestMethod]
        public void ProcessAcceptanceExpressionWithParenthesis()
        {
            Assert.AreEqual(16, _parser.ProcessExpression("(2 + 2) * (3 + 1)"));
        }

        [TestMethod]
        public void ProcessComplexNestedExpressions()
        {
            Assert.AreEqual(20, _parser.ProcessExpression("((2 + 2) + 1)  * (3 + 1)"));
        }
    }
}
