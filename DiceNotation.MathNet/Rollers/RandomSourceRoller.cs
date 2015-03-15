using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiceNotation.Rollers;
using JetBrains.Annotations;
using MathNet.Numerics.Random;

namespace DiceNotation.MathNet.Rollers
{
    public class RandomSourceRoller : IDieRoller
    {
        private readonly RandomSource _source;

        public RandomSourceRoller([NotNull] RandomSource source)
        {
            _source = source;
        }

        public Int32 RollDie(int sides)
        {
            return _source.Next(0, sides) + 1;
        }
    }
}
