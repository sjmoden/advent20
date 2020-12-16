using System.Collections.Generic;
using Day15;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day15Tests.ElvesGameTests
{
    [TestFixture]
    public class When_running_GetNextValue
    {
        private static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new List<int>{0,3,6},1,0);
                yield return new TestCaseData(new List<int>{0,3,6},2,3);
                yield return new TestCaseData(new List<int>{0,3,6},3,3);
                yield return new TestCaseData(new List<int>{0,3,6},4,1);
                yield return new TestCaseData(new List<int>{0,3,6},5,0);
                yield return new TestCaseData(new List<int>{0,3,6},6,4);
                yield return new TestCaseData(new List<int>{0,3,6},7,0);
            }
        }

        [TestCaseSource(nameof(TestData))]
        public void Then_the_value_is_correct(List<int> input,int numberOfIterations,int output)
        {
            var elvesGame = new ElvesGame().SetUpGame(input);
            var value = 0;
            for (var i = 0; i < numberOfIterations; i++)
            {
                value = elvesGame.GetNextValue();
            }
            Assert.That(value,Is.EqualTo(output));
        }
    }
}