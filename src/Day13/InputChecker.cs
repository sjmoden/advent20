using System;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace Day13
{
    public class InputChecker:IInputChecker
    {
        private const string InputUrl = "https://adventofcode.com/2020/day/13/input";
        private readonly IPuzzleInput _puzzleInput;

        public InputChecker(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }
        public string CheckInputToGetAnswerPart1()
        {
            if (Input.Count() != 2)
            {
                throw  new ApplicationException("Lenght of input is not what is expected");
            }

            var arrivalTime = Input.First();

            if (!int.TryParse(arrivalTime, out var arrivalTimeValue))
            {
                throw  new ApplicationException("Arrival time is not a number");
            }
            
            var timeTable = Input.Last();
            
            var busInfo = new List<(int WaitTime, int BusNumber)>();
            
            foreach (var bus in timeTable.Split(',').Where(t => t != "x"))
            {
                if (!int.TryParse(bus, out var busValue))
                {
                    throw  new ApplicationException("Bus is not a number");
                }
                
                busInfo.Add((GetWaitTime(busValue,arrivalTimeValue), busValue));
            }

            var nextBus = busInfo.OrderBy(b => b.WaitTime).First();
            return (nextBus.BusNumber * nextBus.WaitTime).ToString();
        }

        public string CheckInputToGetAnswerPart2()
        {
            if (Input.Count() != 2)
            {
                throw  new ApplicationException("Lenght of input is not what is expected");
            }

            var counter = 0;
            var dictionary = new Dictionary<int, long>();
            foreach (var bus in Input.Last().Split(','))
            {
                if (bus == "x")
                {
                    counter++;
                    continue;
                }
                
                if (!int.TryParse(bus, out var busValue))
                {
                    throw  new ApplicationException("Bus is not a number");
                }
                dictionary.Add(counter,busValue);
                counter++;
            }

            var bigNValue = dictionary.Values.Aggregate((mult, next) => mult * next);
            long result = 0;
            foreach (var entry in dictionary)
            {
                var conguenceFormula = new CongruenceFormula(bigNValue,(int)entry.Value,(int)((entry.Value - entry.Key)%entry.Value));
                result += conguenceFormula.GetAiWiNumber();
            }

            var resultSimplified = result % bigNValue;

            return resultSimplified.ToString();

        }

        private int GetWaitTime(int busValue, int arrivalTimeValue)
        {
            return busValue - (arrivalTimeValue % busValue);
        }
        
        private string[] _input;

        private IEnumerable<string> Input => _input ??= _puzzleInput.GetPuzzleInputAsArray(InputUrl);
    }
}