using System;
using System.Collections.Generic;
using System.Linq;

namespace Day22
{
    public class Hand
    {
        private List<int> _currentHand;
        public int Id;
        public Hand(List<int> hand, int id)
        {
            Id = id;
            _currentHand = hand;
        }

        public int HandCount => _currentHand.Count;

        public int GetTopCard()
        {
            return _currentHand.First();
        }

        public void PlayerLost()
        {
            _currentHand = _currentHand.Skip(1).ToList();
        }

        public string CurrentHand => string.Join(", ", _currentHand);

        public int Score()
        {
            var position = HandCount;
            var aggregate = 0;

            foreach (var card in _currentHand)
            {
                aggregate += position * card;
                position--;
            }
            
            return aggregate;
        }
        

        public void PlayerWon(int newCard)
        {
            var newHand = _currentHand.Skip(1).ToList();
            newHand.Add(_currentHand.First());
            newHand.Add(newCard);
            _currentHand = newHand;
        }

        public Hand MakeNewHandSkippingCurrentTopCard(int numberOfCards)
        {
            return new Hand(_currentHand.Skip(1).Take(numberOfCards).ToList(),Id);
        }

        public Hand Clone()
        {
            return new Hand(_currentHand,Id);
        }
        
    }
}