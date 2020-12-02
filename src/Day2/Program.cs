using System;
using Tools;
using Unity;

namespace Day2
{
    public static class Program
    {
        private static void Main()
        {
            var container = BuildUnityContainer();
            var inputChecker = container.Resolve<IInputChecker>();
            Console.WriteLine($"Part 1: {inputChecker.Part1Answer}");
            Console.WriteLine($"Part 2: {inputChecker.Part2Answer}");
        }
        
        private static IUnityContainer BuildUnityContainer()
        {
            var container = UnityCreator.BuildDefaultUnityContainer();
            container.RegisterType<IInputChecker,InputChecker>();
            return container;
        }
    }
}