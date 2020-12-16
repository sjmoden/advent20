using System;
using System.Collections.Generic;
using System.Linq;

namespace Day16
{
    public class TicketValidator:ITicketValidator
    {
        public IEnumerable<IRule> ParseRuleFromValues(IEnumerable<IRule> rules, IEnumerable<int> input)
        {
            return rules.Where(rule => CheckValidation(new List<IRule> {rule}, input, out _)).ToList();
        }

        public bool CheckValidation(List<IRule> rules, string ticket, out int failValue)
        {
            var fields = ticket.Split(',');
            var fieldsInts = Array.ConvertAll(fields, int.Parse);
            return CheckValidation(rules, fieldsInts, out failValue);
        }

        private static bool CheckValidation(List<IRule> rules, IEnumerable<int> fieldsInts, out int failValue)
        {
            var incorrectField = fieldsInts.Sum(field => GetFieldFailValue(rules, field));

            failValue = incorrectField;

            return failValue == 0;
        }

        private static int GetFieldFailValue(IEnumerable<IRule> rules, int field) =>
            rules.Any(rule => rule.Validate(field)) ? 0 : field;
    }
}