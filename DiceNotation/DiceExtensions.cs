using System;
using DiceNotation.Rollers;

namespace DiceNotation
{
    public static class DiceExtensions
    {
        private static readonly IDieRoller DieRoller = new StandardDieRoller(new Random());

        public static DiceResult Roll(this DiceExpression diceExpression)
        {
            return diceExpression.Roll(DieRoller);
        }

        public static DiceResult MinRoll(this DiceExpression diceExpression)
        {
            return diceExpression.Roll(new MinDieRoller());
        }

        public static DiceResult MaxRoll(this DiceExpression diceExpression)
        {
            return diceExpression.Roll(new MaxDieRoller());
        }
    }
}