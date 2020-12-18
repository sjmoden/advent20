using Day18;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day18Tests.HomeworkSolverTests
{
    public class When_running_SolveProblem
    {
        [TestCase("1 + 2 * 3 + 4 * 5 + 6",71)]
        [TestCase("1 + (2 * 3) + (4 * (5 + 6))",51)]
        [TestCase("2 * 3 + (4 * 5)",26)]
        [TestCase("5 + (8 * 3 + 9 + 3 * 4 * 3)",437)]
        [TestCase("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))",12240)]
        [TestCase("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2",13632)]
        [TestCase("((8 + 6 + 4 + 9 * 2 + 9) * 8 + 2 * (7 + 2 + 4 * 2 + 4) * 2 * 5) * 3",455400)]
        [TestCase("3 * 8 * 2 + 9 * ((6 + 5 * 3) * 7 * 9 * 7 * 7) * (7 * 4 + 5 + 8 * 8)",1904580216)]
        [TestCase("9 + (5 * 5 + 2 + (5 * 2 + 6 * 9 * 3 + 6) * 4) + 3 * 5",9360)]
        [TestCase("3 + (6 * 9 * (4 * 4) * (7 + 2 + 9 * 3 + 5 + 8)) + (3 * (6 + 7 * 4 + 9 * 8) + 3 * 5 + 9 * (5 + 9)) ",160707)]
        [TestCase("6 + (8 * 5 * 3 + 9 + 3 * 4) + 9 + 3 * 3",1638)]
        [TestCase("(8 + 8 * 4 + 3 + 6) + (4 + 3 * 7 + 7 + 4 + 2) + 7 + (3 + (2 * 8 + 7 + 7) * 7 + 5 * (3 * 2 + 9 + 2 + 8 + 7) * (4 + 2 + 8))",105870)]
        [TestCase("7 + 6 + (9 * 8 * 7 * 3) + (4 + 5 * (2 * 8 * 2 * 5 + 4) + (2 + 8 + 4 * 3 + 3) * (6 * 6 * 7 + 4 * 2 * 7)) * 6 + 9",32716743)]
        [TestCase("6 * 8 * (2 * 9) + 2 * 8 * 4",27712 )]
        [TestCase("(4 + 7 * (4 * 9) + 4) + 7 * 5 * (7 * (4 * 5 + 2) * 9 + 6 * 7 * (6 * 8)) * 5 + (5 + (3 * 6 + 3 * 3 * 7))",4758970046 )]
        [TestCase("(7 + 5 * 6) + (3 + 6) * (5 * 7 * 8 + 5 * 7 + 4) + 3",161922 )]
        [TestCase("5 * 7 * 8 + 5 * 7 + 4",1999 )]
        public void Then_the_result_is_correct(string input, long result)
        {
            Assert.That(new HomeworkSolver().SolveProblem(input), Is.EqualTo(result));
        }
    }
}