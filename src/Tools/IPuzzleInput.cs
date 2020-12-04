namespace Tools
{
    public interface IPuzzleInput
    {
        string GetPuzzleInput(string url);

        string[] GetPuzzleInputAsArray(string url);

        string[] GetPuzzleInputAsArray(string url, string separator);
    }
}