using System;
using Day17.CycleRunners;
using Day17.InputParsers;
using Tools;
using Unity;

namespace Day17
{
    internal static class Program
    {
        private static void Main()
        {
            var container = BuildUnityContainer();
            var inputChecker = container.Resolve<IInputChecker>();
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            Console.WriteLine($"Part 1: {inputChecker.CheckInputToGetAnswerPart1()}");
            Console.WriteLine($"Part 1 Execution Time: {watch.ElapsedMilliseconds} ms");

            watch.Restart();
            Console.WriteLine($"Part 2: {inputChecker.CheckInputToGetAnswerPart2()}");
            Console.WriteLine($"Part 2 Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = UnityCreator.BuildDefaultUnityContainer();
            container.RegisterType<IInputParser,InputParser3D>(nameof(InputParser3D));
            container.RegisterType<IInputParser,InputParser4D>(nameof(InputParser4D));
            container.RegisterType<ICycleRunner,CycleRunner3D>(nameof(CycleRunner3D));
            container.RegisterType<ICycleRunner,CycleRunner4D>(nameof(CycleRunner4D));
            container.RegisterType<IInputChecker,InputChecker>();
            return container;
        }
    }
}