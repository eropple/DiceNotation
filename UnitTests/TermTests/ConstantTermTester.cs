using DiceNotation.Terms;
using NUnit.Framework;

namespace DiceNotation.UnitTests.TermTests
{
    public class ConstantTermTester
    {
        [Test]
        public void ToStringReturnsValue()
        {
            const int constant = 5;
            var constantTerm = new ConstantTerm(constant);

            Assert.AreEqual(constant.ToString(), constantTerm.ToString());
        }
    }
}