using System.Linq;

namespace Day7
{
    public class InputChecker:IInputChecker
    {
        private readonly IRules _rules;
        private readonly ITree _tree;

        public InputChecker(IRules rules, ITree tree)
        {
            _rules = rules;
            _tree = tree;
        }

        public string CheckInputToGetAnswerPart1()
        {
            var containingGoldBagCount =0;
            foreach (var rule in _rules.Rules)
            {
                if (string.IsNullOrWhiteSpace(rule))
                {
                    continue;
                    
                }
                var bag = new Bag(rule, _rules,_tree);
                if (bag.ContainsAGoldBag)
                {
                    containingGoldBagCount++;
                }
            }

            return containingGoldBagCount.ToString();
        }

        public string CheckInputToGetAnswerPart2()
        {
            var goldRule = _rules.Rules.Single(r => r.StartsWith("shiny gold bag"));
            var bag = new Bag(goldRule,_rules,_tree);
            return  bag.NumberOfBagsInTheContextsRecursive.ToString();
        }
    }
}