﻿using System;
using Tools;
using Unity;
using Unity.Lifetime;

namespace Day10
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
            container.RegisterType<ITree<JoltNode>,JoltTree>(new ContainerControlledLifetimeManager());
            container.RegisterType<ITree<PathNode>,PathTree>(new ContainerControlledLifetimeManager());
            container.RegisterType<IInputChecker,InputChecker>();
            return container;
        }
    }
}