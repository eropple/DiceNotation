namespace DiceNotation
{
    public interface IDiceParser
    {
        DiceExpression Parse(string expression);
    }
}