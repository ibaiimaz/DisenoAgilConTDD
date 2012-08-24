using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCalculator
{
    public class ExpressionBuilder
    {
        private static string _inputText;
        private static int _currentIndex = 0;
        private static List<MathExpression> _allExpressions;
        private MathExpression _subExpression;

        private ExpressionBuilder() { }

        public static ExpressionBuilder Create()
        {
            ExpressionBuilder builder = new ExpressionBuilder();
            builder.AllExpressions = new List<MathExpression>();
            builder.CurrentIndex = 0;
            builder.InputText = String.Empty;
            builder.SubExpression = new MathExpression(String.Empty);
            return builder;
        }

        public ExpressionBuilder ProcessNewSubExpression()
        {
            ExpressionBuilder builder = new ExpressionBuilder();
            builder.InputText = _inputText;
            builder.SubExpression = new MathExpression(String.Empty);
            updateIndex();
            return builder;
        }

        public bool ThereAreMoreChars()
        {
            return _currentIndex < MaxLength;
        }

        public void AddSubExpressionChar()
        {
            _subExpression.Expression += 
                        _inputText[_currentIndex].ToString();
            if (_subExpression.Order == -1)
                _subExpression.Order = _currentIndex;
            updateIndex();
        }

        public void SubExpressionEndFound()
        {
            _allExpressions.Add(_subExpression);
            updateIndex();
        }

        public string InputText
        {
            get { return _inputText; }
            set { _inputText = value; }
        }

        public char GetCurrentChar()
        {
            return _inputText[_currentIndex];
        }

        public int MaxLength
        {
            get { return _inputText.Length; }
        }
        
        public int CurrentIndex
        {
            get { return _currentIndex; }
            set { _currentIndex = value; }
        }

        public List<MathExpression> AllExpressions
        {
            get { return _allExpressions; }
            set { _allExpressions = value; }
        }

        public MathExpression SubExpression
        {
            get { return _subExpression; }
            set { _subExpression = value; }
        }

        private void updateIndex()
        {
            _currentIndex++;
        }
    }
}
