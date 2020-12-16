namespace Day16
{
    public interface IRule
    {
        string RuleName { get; }
        IRule CreateRule(string ruleString);
        bool Validate(int value);
    }
}