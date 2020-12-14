using System;
using Tools;
using Unity;
using Unity.Injection;

namespace Day12
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
            container.RegisterType<IShipMover,ShipMover>(nameof(ShipMover));
            container.RegisterType<IShipMover,ShipMoverUsingWaypoint>(nameof(ShipMoverUsingWaypoint));
            container.RegisterType<IShip,Ship>("Ship",new InjectionConstructor(container.Resolve<IShipMover>(nameof(ShipMover))));
            container.RegisterType<IShip,Ship>("ShipUsingWaypoint", new InjectionConstructor(container.Resolve<IShipMover>(nameof(ShipMoverUsingWaypoint))));
            container.RegisterType<IInputChecker,InputChecker>();
            return container;
        }
    }
}