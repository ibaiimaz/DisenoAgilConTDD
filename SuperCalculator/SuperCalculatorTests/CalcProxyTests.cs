using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperCalculator;

namespace SuperCalculatorTests
{
    [TestClass()]
    public class CalcProxyTests
    {
        private Calculator _calculator;
        private CalcProxy _coordinator;
        private CalcProxy _coordinatorWithLimits;

        [TestInitialize()]
        public void TestInitialize()
        {
            _calculator = new Calculator();
            _coordinator = new CalcProxy(new Validator(-100, 100), _calculator);
            _coordinatorWithLimits = new CalcProxy(new Validator(-10, 10), _calculator);
        }

        [TestMethod]
        public void Add()
        {
            int result = _coordinator.BinaryOperation(_calculator.Add, 2, 2);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Substract()
        {
            int result = _coordinator.BinaryOperation(_calculator.Substract, 5, 3);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void AddWithDifferentArguments()
        {
            int result = _coordinator.BinaryOperation(_calculator.Add, 2, 5);
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void SubstractReturningNegative()
        {
            int result = _coordinator.BinaryOperation(_calculator.Substract, 3, 5);
            Assert.AreEqual(-2, result);
        }

        [TestMethod]
        public void ArgumentsExceedLimits()
        {
            try
            {
                _coordinatorWithLimits.BinaryOperation(
                                       _calculator.Add, 30, 50);
                Assert.Fail("This should fail as arguments exceed both limits");
            }
            catch (OverflowException)
            {
                // Ok, this works
            }
        }

        [TestMethod]
        public void ArgumentsExceedLimitsInverse()
        {
            try
            {
                _coordinatorWithLimits.BinaryOperation(
                                            _calculator.Add, -30, -50);
                Assert.Fail("This should fail as arguments exceed both limits");
            }
            catch (OverflowException)
            {
                // Ok, this works
            }
        }

        [TestMethod]
        public void ValidateResultExceedingUpperLimit()
        {
            try
            {
                _coordinatorWithLimits.BinaryOperation(
                                            _calculator.Add, 10, 10);
                Assert.Fail("This should fail as result exceed upper limit");
            }
            catch (OverflowException)
            {
                // Ok, this works
            }
        }

        [TestMethod]
        public void ValidateResultExceedingLowerLimit()
        {
            try
            {
                _coordinatorWithLimits.BinaryOperation(
                                            _calculator.Add, -20, -1);
                Assert.Fail("This should fail as result exceed upper limit");
            }
            catch (OverflowException)
            {
                // Ok, this works
            }
        }
    }
}
