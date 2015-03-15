using System.Collections.Generic;
using DiceNotation.Rollers;

namespace DiceNotation.Terms
{
    public interface IDiceExpressionTerm
    {
        IEnumerable<TermResult> GetResults(IDieRoller dieRoller);
    }
}