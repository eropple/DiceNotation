using System;

namespace DiceNotation.Rollers
{
    public class StandardDieRoller : IDieRoller
    {
        private static readonly Random Random = new Random();
        
        private readonly Random _random;

        public StandardDieRoller() : this(Random)
        { }

        public StandardDieRoller(Random random)
        {
            _random = random;
        }

        public int RollDie(int sides)
        {
            return _random.Next(0, sides) + 1;
        }
    }
}