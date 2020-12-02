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
            Console.WriteLine($"Part 1: {inputChecker.CheckInputToGetAnswerPart1()}");
        }
        
        private static IUnityContainer BuildUnityContainer()
        {
            var container = UnityCreator.BuildDefaultUnityContainer();
            container.RegisterType<IInputChecker,InputChecker>();
            return container;
        }
    }
}