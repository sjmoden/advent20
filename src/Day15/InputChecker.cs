using System.Collections.Generic;

namespace Day15
{
    public class InputChecker:IInputChecker
    {
        public string CheckInputToGetAnswerPart1()
        {
            var startingList = new List<int>{9,3,1,0,8,4};
            var elvesGame = new ElvesGame().SetUpGame(startingList);


            var currentValue = 0;
            while (elvesGame.Position < 2020)
            {
                currentValue = elvesGame.GetNextValue();
            }
            
            return currentValue.ToString();
        }

        public string CheckInputToGetAnswerPart2()
        {
            var startingList = new List<int>{9,3,1,0,8,4};
            var elvesGame = new ElvesGame().SetUpGame(startingList);


            var currentValue = 0;
            while (elvesGame.Position < 30000000)
            {
                currentValue = elvesGame.GetNextValue();
            }
            
            return currentValue.ToString();
        }
    }
}