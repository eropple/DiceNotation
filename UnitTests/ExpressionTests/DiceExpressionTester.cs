using System;
using DiceNotation.Rollers;
using NUnit.Framework;

namespace DiceNotation.UnitTests.ExpressionTests
{
    [TestFixture]
    public class DiceExpressionTester
    {
        [Test]
        public void ContainsAndReturnsCorrectNumberOfValues()
        {
            DiceExpression diceExpression = new DiceExpression()
                .Constant(5)
                .Die(8)
                .Dice(4, 6, choose: 3);

            DiceResult result = diceExpression.Roll(new StandardDieRoller(new Random()));

            const int expectedNumberOfTerms = 1 + 1 + 3;

            Assert.AreEqual(expectedNumberOfTerms, result.Results.Count);
        }

        [Test]
        public void ToStringReturnsTermsSeparatedByPlus()
        {
            DiceExpression diceExpression = new DiceExpression().Constant(10).Die(8, -1);

            string toString = diceExpression.ToString();

            Assert.AreEqual("10 + -1*1d8", toString);
        }
    }
}