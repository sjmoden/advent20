using System.Collections.Generic;
using Day22;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Day22Tests.CombatGameTests
{
    [TestFixture]
    public class When_running_combat_game
    {
        private readonly Hand Player1 = new Hand(new List<int>{9, 2, 6, 3, 1}, 1);
        private readonly Hand Player2 = new Hand(new List<int>{5,8,4,7,10}, 2);
        
        [Test]
        public void Then_the_score_for_the_winner_of_vanilla_game_is_correct()
        {
            Assert.That(CombatGame.PlayGameAndReturnWinner(Player1.Clone(),Player2.Clone()).Score(), Is.EqualTo(306));
        }
        
        [Test]
        public void Then_the_score_for_the_winner_of_recursive_game_is_correct()
        {
            Assert.That(CombatGame.PlayRecursiveGameAndReturnWinner(Player1.Clone(),Player2.Clone(),1).Score(), Is.EqualTo(291));
        }
    }
}