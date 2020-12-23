using System.Collections.Generic;
using NUnit.Framework;
using Day22;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Day22Tests.HandTests
{
    public class When_setting_up_a_hand
    {
        private readonly Hand _sut = new Hand(new List<int>{1,2,3},5);

        [Test]
        public void Then_hand_count_is_correct()
        {
            Assert.That(_sut.HandCount,Is.EqualTo(3));
        }
        
        [Test]
        public void Then_current_hand_is_correct()
        {
            Assert.That(_sut.CurrentHand,Is.EqualTo("1, 2, 3"));
        }
        
        [Test]
        public void Then_top_card_is_correct()
        {
            Assert.That(_sut.GetTopCard(),Is.EqualTo(1));
        }
        
        [Test]
        public void Then_score_is_correct()
        {
            Assert.That(_sut.Score(),Is.EqualTo(10));
        }
        
        [Test]
        public void Then_player_won_gives_the_correct_hand()
        {
            var clonedSut = _sut.Clone();
                clonedSut.PlayerWon(5);
            Assert.That(clonedSut.CurrentHand,Is.EqualTo("2, 3, 1, 5"));
        }
        
        [Test]
        public void Then_player_lost_gives_the_correct_hand()
        {
            var clonedSut = _sut.Clone();
                clonedSut.PlayerLost();
            Assert.That(clonedSut.CurrentHand,Is.EqualTo("2, 3"));
        }
        
        [Test]
        public void Then_clone_gives_the_correct_cards()
        {
            var clonedSut = _sut.Clone();
            Assert.That(clonedSut.CurrentHand,Is.EqualTo("1, 2, 3"));
        }
        
        [Test]
        public void Then_clone_gives_the_correct_id()
        {
            var clonedSut = _sut.Clone();
            Assert.That(clonedSut.Id,Is.EqualTo(5));
        }
        
        [Test]
        public void Then_id_is_correct()
        {
            Assert.That(_sut.Id,Is.EqualTo(5));
        }
        
        [Test]
        public void Then_MakeNewHandSkippingCurrentTopCard__gives_correct_cards()
        {
            var clonedSut = _sut.MakeNewHandSkippingCurrentTopCard(1);
            
            Assert.That(clonedSut.CurrentHand,Is.EqualTo("2"));
        }
    }
}