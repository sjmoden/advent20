using System;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace Day16
{
    public class InputChecker:IInputChecker
    {        
        private const string InputUrl = "https://adventofcode.com/2020/day/16/input";
        private readonly IPuzzleInput _puzzleInput;
        private readonly ITicketValidator _ticketValidator;

        public InputChecker(IPuzzleInput puzzleInput, ITicketValidator ticketValidator)
        {
            _puzzleInput = puzzleInput;
            _ticketValidator = ticketValidator;
        }

        private string _yourTicket;

        private string YourTicket
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_yourTicket))
                {
                    GetValues();
                }

                return _yourTicket;
            }
        }

        private readonly List<string> _nearByTickets = new List<string>();

        private IEnumerable<string> NearByTickets
        {
            get
            {
                if (!_nearByTickets.Any())
                {
                    GetValues();
                }

                return _nearByTickets;
            }
        }

        private int _ticketFailValue;

        private int TicketFailValue
        {
            get
            {
                if (_ticketFailValue == default)
                {
                    GetValues();
                }

                return _ticketFailValue;
            }
        }

        private readonly List<IRule>_rules = new List<IRule>();

        private List<IRule> Rules
        {
            get
            {
                if (!_rules.Any())
                {
                    GetValues();
                }

                return _rules;
            }
        }

        private enum ReadingType
        {
            Rules,
            YourTicket,
            NearbyTickets
        }

        private void GetValues()
        {
            var readingType = ReadingType.Rules;
            foreach (var value in Input)
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    continue;
                }

                if (value.StartsWith("your ticket"))
                {
                    readingType = ReadingType.YourTicket;
                }

                if (value.StartsWith("nearby tickets"))
                {
                    readingType = ReadingType.NearbyTickets;
                    continue;
                }
                
                switch (readingType)
                {
                    case ReadingType.Rules:
                        _rules.Add(new Rule().CreateRule(value));
                        break;
                    case ReadingType.NearbyTickets:
                        if (!_ticketValidator.CheckValidation(_rules, value, out var failValue))
                        {
                            _ticketFailValue += failValue;                            
                        }
                        else
                        {
                            _nearByTickets.Add(value);
                        }
                        break;
                    case  ReadingType.YourTicket:
                        _yourTicket = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        
        public string CheckInputToGetAnswerPart1()
        {
            return TicketFailValue.ToString();
        }

        public string CheckInputToGetAnswerPart2()
        {
            var columns = new List<int[]>();

            for (var i = 0; i < Rules.Count; i++)
            {
                var columnString = NearByTickets.Select(t => t.Split(',')[i]).ToArray();
                var columnInts = Array.ConvertAll(columnString, int.Parse);
                columns.Add(columnInts);
            }


            var mapping = new List<(int postion, string ruleName)>();
            PopulateMappings(mapping, columns);


            var yourTicketValuesSplit = YourTicket.Split(',');
            var yourTicketValuesSplitInt = Array.ConvertAll(yourTicketValuesSplit, int.Parse);
            var answer = mapping.Where(m => m.ruleName.StartsWith("departure"))
                .Aggregate<(int postion, string ruleName), long>(1,
                    (current, departureLocation) => current * yourTicketValuesSplitInt[departureLocation.postion]);

            return answer.ToString();
        }

        private void PopulateMappings(ICollection<(int postion, string ruleName)> mapping, IReadOnlyList<int[]> columns)
        {
            var currentMappingSize = mapping.Count;
            for (var i = 0; i < Rules.Count; i++)
            {
                if (mapping.Any(m => m.postion == i))
                {
                    continue;
                }

                var matches = _ticketValidator.ParseRuleFromValues(Rules, columns[i]).ToList();
                var matchToCheck = matches.Where(m => mapping.All(map => map.ruleName != m.RuleName)).ToList();
                if (matchToCheck.Count == 1)
                {
                    mapping.Add((i, matchToCheck.Single().RuleName));
                    Console.WriteLine($"{i} is {matchToCheck.Single().RuleName}");
                }
            }

            if (currentMappingSize < mapping.Count && columns.Count > mapping.Count)
            {
                PopulateMappings(mapping, columns);
            }
        }


        private string[] _input;

        private IEnumerable<string> Input => _input ??= _puzzleInput.GetPuzzleInputAsArray(InputUrl);
    }
}