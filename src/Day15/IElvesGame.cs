using System.Collections.Generic;

namespace Day15
{
    public interface IElvesGame
    {
        ElvesGame SetUpGame(List<int> startingList);
        int GetNextValue();
    }
}