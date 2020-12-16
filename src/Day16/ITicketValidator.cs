using System.Collections.Generic;

namespace Day16
{
    public interface ITicketValidator
    {
        public IEnumerable<IRule> ParseRuleFromValues(IEnumerable<IRule> rules, IEnumerable<int> input);
        bool CheckValidation(List<IRule> rules, string ticket, out int failValue);
    }
}