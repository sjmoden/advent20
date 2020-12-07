using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    public class Bag:IBag
    {
        private readonly string _bagDetailsString;
        private readonly IRules _rules;
        
        public Bag(string bagDetailsString, IRules rules)
        {
            _bagDetailsString = bagDetailsString;
            _rules = rules;
        }

        private string _bagName;

        public string BagName => _bagName ??= GetBagName();

        private IEnumerable<IBag> _contents;
        
        public IEnumerable<IBag>Contents=> _contents ??=GetContents();

        public int NumberOfBagsInTheContextsRecursive => Contents.Count()+Contents.Sum(c => c.NumberOfBagsInTheContextsRecursive);

        public bool ContainsAGoldBag
        {
            get
            {
                //This could be more efficient by adding a cache that details whether a bags status has already been decided.

                return Contents.Any(b => b.BagName.Equals("shiny gold", StringComparison.InvariantCultureIgnoreCase)) ||
                       Contents.Distinct().Any(bag => bag.ContainsAGoldBag);
            }
        }

        private string GetBagName()
        {
            var bagPositionInString = _bagDetailsString.IndexOf("bag", StringComparison.InvariantCultureIgnoreCase);
            return _bagDetailsString.Substring(0,bagPositionInString).Trim();
        }

        private IEnumerable<IBag> GetContents()
        {
            var containingBags = new List<IBag>();
            
            var containPositionInString = _bagDetailsString.IndexOf("contain", StringComparison.InvariantCultureIgnoreCase);
            var contentsDetails = _bagDetailsString.Substring(containPositionInString + 8);

            if (contentsDetails.Equals("no other bags.",StringComparison.InvariantCultureIgnoreCase))
            {
                return containingBags;
            }
            
            var bagsDetails = contentsDetails.Split(',');
            foreach (var bagsDetail in bagsDetails)
            {
                var numberOfBagsStr = bagsDetail.Trim().Substring(0,bagsDetail.Trim().IndexOf(" ", StringComparison.InvariantCultureIgnoreCase));
                var bagName = bagsDetail.Trim().Substring(bagsDetail.Trim().IndexOf(" ", StringComparison.InvariantCultureIgnoreCase)).Replace(@".", string.Empty).Trim();
                var matchingBagRule =
                    _rules.Rules.Single(r => r.StartsWith(bagName, StringComparison.InvariantCultureIgnoreCase));

                if (!int.TryParse(numberOfBagsStr, out var numberOfBags))
                {
                    throw new ArgumentException("The rule is in an incorrect format so that the number of bags is not read.");
                }

                for (var i = 0; i < numberOfBags; i++)
                {
                    containingBags.Add(new Bag(matchingBagRule,_rules));
                }
            }
            
            
            return containingBags;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }
            
            if (obj is Bag bag)
            {
                return bag.BagName.Equals(BagName, StringComparison.InvariantCultureIgnoreCase);
            }
            
            return false;
        }
        
        public override int GetHashCode()
        {
            return (_bagDetailsString != null ? _bagDetailsString.GetHashCode() : 0);
        }
    }
}