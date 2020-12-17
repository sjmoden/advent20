using System.Collections.Generic;
using System.Linq;
using Day17.CycleRunners;
using Day17.InputParsers;
using Tools;
using Unity;

namespace Day17
{
    public class InputChecker:IInputChecker
    {
        //If I was to make a change to this project I would investigate a better solution to using Vector3 and Vector4
        //This would mean we could refactor the 3d & 4D versions of InputParser and CycleRunner to reduce duplicated code
        //I have spent far too much time building this today so I will not be looking into this.
        
        //Part 2 runs fairly slowly. If I had more time I would explore how to make it more efficient (It look approx 2 mins to run)

        private const string InputUrl = "https://adventofcode.com/2020/day/17/input";
        private readonly ICycleRunner _cycleRunner3;
        private readonly ICycleRunner _cycleRunner4;
        private readonly IInputParser _inputParser3;
        private readonly IInputParser _inputParser4;
        private readonly IPuzzleInput _puzzleInput;

        public InputChecker(IPuzzleInput puzzleInput, [Dependency(nameof(CycleRunner3D))] ICycleRunner cycleRunner3,
            [Dependency(nameof(InputParser3D))] IInputParser inputParser3,
            [Dependency(nameof(CycleRunner4D))] ICycleRunner cycleRunner4,
            [Dependency(nameof(InputParser4D))] IInputParser inputParser4)
        {
            _puzzleInput = puzzleInput;
            _cycleRunner3 = cycleRunner3;
            _inputParser3 = inputParser3;
            _cycleRunner4 = cycleRunner4;
            _inputParser4 = inputParser4;
        }

        public string CheckInputToGetAnswerPart1()
        {
            var parsedInput = _inputParser3.ParseInput(Input.ToArray());

            var cycledInput = _cycleRunner3.Run(parsedInput);
            cycledInput = _cycleRunner3.Run(cycledInput);
            cycledInput = _cycleRunner3.Run(cycledInput);
            cycledInput = _cycleRunner3.Run(cycledInput);
            cycledInput = _cycleRunner3.Run(cycledInput);
            cycledInput = _cycleRunner3.Run(cycledInput);

            return cycledInput.Count(c => c.Active).ToString();
        }
        
        public string CheckInputToGetAnswerPart2()
        {
            var parsedInput = _inputParser4.ParseInput(Input.ToArray());

            var cycledInput = _cycleRunner4.Run(parsedInput);
            cycledInput = _cycleRunner4.Run(cycledInput);
            cycledInput = _cycleRunner4.Run(cycledInput);
            cycledInput = _cycleRunner4.Run(cycledInput);
            cycledInput = _cycleRunner4.Run(cycledInput);
            cycledInput = _cycleRunner4.Run(cycledInput);

            return cycledInput.Count(c => c.Active).ToString();
        }
        
        private string[] _input;

        private IEnumerable<string> Input => _input ??= _puzzleInput.GetPuzzleInputAsArray(InputUrl);
    }
}