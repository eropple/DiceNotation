using System;
using NUnit.Framework;

namespace DiceNotation.UnitTests.ParseTests
{
    [TestFixture]
    public class ParseTester
    {
        private readonly DiceParser _diceParser;

        public ParseTester()
        {
            _diceParser = new DiceParser();
        }

        [Test]
        public void HandlesOneDieTerm()
        {
            DiceExpression diceExpression = _diceParser.Parse("3d6");
            Assert.AreEqual("3d6", diceExpression.ToString());
        }

        [Test]
        public void HandlesDieTermPlusConstant()
        {
            DiceExpression diceExpression = _diceParser.Parse("3d6+5");
            Assert.AreEqual("3d6 + 5", diceExpression.ToString());
        }

        [Test]
        public void HandlesDieTermWithChooseAndScalar()
        {
            const string expression = "2 + 3*4d6k3";
            DiceExpression diceExpression = _diceParser.Parse(expression);
            Assert.AreEqual(expression, diceExpression.ToString());
        }

        [Test]
        public void HandlesDieWithImplicitMultiplicityOf1()
        {
            const string expression = "2 + 2*d6";
            const string expectedExpression = "2 + 2*1d6";

            DiceExpression diceExpression = _diceParser.Parse(expression);
            Assert.AreEqual(expectedExpression, diceExpression.ToString());
        }

        [Test]
        public void HandlesNegativeScalar()
        {
            const string expression = "2 + -2*1d6";

            DiceExpression diceExpression = _diceParser.Parse(expression);
            Assert.AreEqual(expression, diceExpression.ToString());
        }

        [Test]
        public void RejectsExpressionWithInvalidCharacters()
        {
            const string expression = "2d6/2";
            Assert.Throws<ArgumentException>(() => _diceParser.Parse(expression));
        }
    }
}