using System.Linq;
using System.Numerics;
using Day17;
using Day17.CycleRunners;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day17Tests.CycleRunnerTests
{
    [TestFixture]
    public class When_running_run_3D
    {
        private readonly PocketDimension[] input =
        {
            new PocketDimension(new Vector3(1, 0, 0), true),
            new PocketDimension(new Vector3(2, 1, 0), true),
            new PocketDimension(new Vector3(0, 2, 0), true),
            new PocketDimension(new Vector3(1, 2, 0), true),
            new PocketDimension(new Vector3(2, 2, 0), true)
            
        };

        [Test]
        public void Then_count_active_is_correct()
        {
            Assert.That(new CycleRunner3D().Run(input).Count(p => p.Active), Is.EqualTo(11));
        }
    }
    
    [TestFixture]
    public class When_running_run_4D
    {
        private readonly PocketDimension[] input =
        {
            new PocketDimension(new Vector4(1, 0, 0,0), true),
            new PocketDimension(new Vector4(2, 1, 0,0), true),
            new PocketDimension(new Vector4(0, 2, 0,0), true),
            new PocketDimension(new Vector4(1, 2, 0,0), true),
            new PocketDimension(new Vector4(2, 2, 0,0), true)
            
        };

        [Test]
        public void Then_count_active_is_correct()
        {
            Assert.That(new CycleRunner4D().Run(input).Count(p => p.Active), Is.EqualTo(29));
        }
    }
}