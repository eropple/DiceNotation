using System.Collections.Generic;
using System.Linq;
using DiceNotation.Exceptions;
using DiceNotation.Rollers;
using DiceNotation.Terms;
using NSubstitute;
using NUnit.Framework;

namespace DiceNotation.UnitTests.TermTests
{ 
    [TestFixture]
    public class DiceTermTester
    {
        [Test]
        public void SetsConstructorValues()
        {
            const int multiplicity = 3;
            const int sides = 4;
            const int scalar = 5;

            var diceTerm = new DiceTerm(multiplicity, sides, scalar);

            Assert.AreEqual(multiplicity, diceTerm.Multiplicity);
            Assert.AreEqual(sides, diceTerm.Sides);
            Assert.AreEqual(scalar, diceTerm.Scalar);
        }

        [Test]
        public void ExceptionIsThrownWhenConstructingImpossibleDice()
        {
            const int invalidNumberOfSides = -1;

            TestDelegate constructDieWithNoSides = () => new DiceTerm(1, invalidNumberOfSides, 1);

            Assert.Throws<ImpossibleDieException>(constructDieWithNoSides);
        }

        [Test]
        public void ExceptionIsThrownWhenChoosingMoreDiceThanRolled()
        {
            const int multiplicity = 1;
            const int choose = multiplicity + 1;

            TestDelegate chooseMoreDiceThanRolled = () => new DiceTerm(multiplicity, 6, choose, 1);

            Assert.Throws<InvalidChooseException>(chooseMoreDiceThanRolled);
        }

        [Test]
        public void ExceptionIsThrownWhenChoosingLessThanNoDice()
        {
            const int multiplicity = 1;
            const int choose = -1;

            TestDelegate chooseLessThanAnyDice = () => new DiceTerm(multiplicity, 6, choose, 1);

            Assert.Throws<InvalidChooseException>(chooseLessThanAnyDice);
        }

        [Test]
        public void ExceptionIsThrownWhenConstructingDiceWithInvalidMultiplicity()
        {
            const int invalidMultiplicity = -1;

            TestDelegate rollLessThanNoDice = () => new DiceTerm(invalidMultiplicity, 6, 1);

            Assert.Throws<InvalidMultiplicityException>(rollLessThanNoDice);
        }

        [Test]
        public void ReturnsMultiplicityResultsWhenNoChooseSpecified()
        {
            const int multiplicity = 6;
            const int sides = 6;

            var diceTerm = new DiceTerm(multiplicity, sides, 1);

            var dieRoller = Substitute.For<IDieRoller>();
            dieRoller.RollDie(sides).Returns(sides);

            IEnumerable<TermResult> results = diceTerm.GetResults(dieRoller);

            Assert.AreEqual(multiplicity, results.Count());
        }

        [Test]
        public void StringRepresentationIsCorrectForScalarOfOne()
        {
            const int multiplicity = 3;
            const int sides = 6;

            var diceTerm = new DiceTerm(multiplicity, sides, 1);

            string stringRepresentation = diceTerm.ToString();

            Assert.AreEqual("3d6", stringRepresentation);
        }

        [Test]
        public void StringRepresentationIsCorrectForScalarOfTwo()
        {
            const int multiplicity = 3;
            const int sides = 6;
            const int scalar = 2;

            var diceTerm = new DiceTerm(multiplicity, sides, scalar);

            string stringRepresentation = diceTerm.ToString();

            Assert.AreEqual("2*3d6", stringRepresentation);
        }

        [Test]
        public void StringRepresentationIsCorrectForChoose()
        {
            var diceTerm = new DiceTerm(4, 6, 3, 1);

            string stringRepresentation = diceTerm.ToString();

            Assert.AreEqual("4d6k3", stringRepresentation);
        }
    }
}