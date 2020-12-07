using System;
using Tools;
using Unity;

namespace Day6
{
    internal static class Program
    {
        private static void Main()
        {
            var container = BuildUnityContainer();
            var inputChecker = container.Resolve<IInputChecker>();
            Console.WriteLine($"Part 1: {inputChecker.CheckInputToGetAnswerPart1()}");
            Console.WriteLine($"Part 2: {inputChecker.CheckInputToGetAnswerPart2()}");
        }
        
        private static IUnityContainer BuildUnityContainer()
        {
            var container = UnityCreator.BuildDefaultUnityContainer();
            container.RegisterType<IInputChecker,InputChecker>();
            return container;
        }
    }
}