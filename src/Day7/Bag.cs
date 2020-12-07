using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    public class Bag:IBag
    {
        private readonly string _bagDetailsString;
        private readonly IRules _rules;
        private readonly ITree _tree;
        
        public Bag(string bagDetailsString, IRules rules, ITree tree)
        {
            _bagDetailsString = bagDetailsString;
            _rules = rules;
            _tree = tree;
        }

        private string _bagName;

        public string BagName => _bagName ??= GetBagName();

        private IEnumerable<IBag> _contents;
        
        public IEnumerable<IBag>Contents
        {
            get
            {
                if (_contents == null)
                {
                    PopulateContents();
                }
                return _contents;

            }
        }

        public int NumberOfBagsInTheContextsRecursive => Contents.Count()+Contents.Sum(c => c.NumberOfBagsInTheContextsRecursive);

        public bool ContainsAGoldBag
        {
            get
            {
                return Contents.Any(b => b.BagName.Equals("shiny gold", StringComparison.InvariantCultureIgnoreCase)) ||
                       Contents.Distinct().Any(bag => bag.ContainsAGoldBag);
            }
        }

        private string GetBagName()
        {
            var bagPositionInString = _bagDetailsString.IndexOf("bag", StringComparison.InvariantCultureIgnoreCase);
            return _bagDetailsString.Substring(0,bagPositionInString).Trim();
        }

        private void PopulateContents()
        {
            if (_tree.TryGetNode(BagName, out var bagFromTree))
            {
                _contents = bagFromTree.Contents;
                return;
            }
            
            var containingBags = new List<IBag>();
            
            var containPositionInString = _bagDetailsString.IndexOf("contain", StringComparison.InvariantCultureIgnoreCase);
            var contentsDetails = _bagDetailsString.Substring(containPositionInString + 8);

            if (contentsDetails.Equals("no other bags.",StringComparison.InvariantCultureIgnoreCase))
            {
                _tree.AddNode(this);
                _contents = containingBags;
                return;
            }
            
            var bagsDetails = contentsDetails.Split(',');
            foreach (var bagsDetail in bagsDetails)
            {
                var numberOfBagsStr = bagsDetail.Trim().Substring(0,bagsDetail.Trim().IndexOf(" ", StringComparison.InvariantCultureIgnoreCase));
                var bagName = bagsDetail.Trim().Substring(bagsDetail.Trim().IndexOf(" ", StringComparison.InvariantCultureIgnoreCase)).Replace("bags","").Replace("bag","").Replace(@".", string.Empty).Trim();
                var matchingBagRule =
                    _rules.Rules.Single(r => r.StartsWith(bagName, StringComparison.InvariantCultureIgnoreCase));

                if (!int.TryParse(numberOfBagsStr, out var numberOfBags))
                {
                    throw new ArgumentException("The rule is in an incorrect format so that the number of bags is not read.");
                }

                for (var i = 0; i < numberOfBags; i++)
                {
                    if (_tree.TryGetNode(bagName, out var subBagFromTree))
                    {
                        containingBags.Add(subBagFromTree);
                    }
                    else
                    {
                        var subBag = new Bag(matchingBagRule, _rules, _tree).GetBagAndContainingBags();
                        containingBags.Add(subBag);    
                    }
                    
                }
            }

            _contents = containingBags;
            _tree.AddNode(this);
        }

        private Bag GetBagAndContainingBags()
        {
            PopulateContents();
            return this;
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