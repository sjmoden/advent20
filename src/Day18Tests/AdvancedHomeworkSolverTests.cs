using Day18;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day18Tests.AdvancedHomeworkSolverTests
{
    public class When_running_SolveProblem
    {
        [TestCase("1 + 2 * 3 + 4 * 5 + 6",231)]
        [TestCase("1 + (2 * 3) + (4 * (5 + 6))",51)]
        [TestCase("2 * 3 + (4 * 5)",46)]
        [TestCase("5 + (8 * 3 + 9 + 3 * 4 * 3)",1445)]
        [TestCase("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))",669060)]
        [TestCase("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2 ",23340)]
        [TestCase("((7 * 4) * 9 * 4 + 9 + 4 + (8 * 4 + 6 + 2)) + 2 * 5 + 8 + 6 * 5",2705410)]
        [TestCase("3 + ((5 + 7 + 7 * 2) * 4 * 2 * 5 + (3 * 9 * 5 + 7) + (7 + 3)) + ((9 + 4 + 6) * 9 + 3 + 3 + 9 + (2 * 9 + 8))",104161)]
        [TestCase("3 * (7 + 5 + 3 + 7 * 5) + (7 + 6 + 2 * 8 + (3 * 7 + 2) + 6)",2175)]
        [TestCase("7 + 6 + 2 * 8 + 27 + 6",615)]
        public void Then_the_result_is_correct(string input, long result)
        {
            Assert.That(new AdvancedHomeworkSolver().SolveProblem(input), Is.EqualTo(result));
        }
    }
}