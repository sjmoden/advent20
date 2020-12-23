using System.Collections.Generic;
using System.Linq;
using Tools;

namespace Day22
{
    public class InputChecker:IInputChecker
    {
        private const string InputUrl = "https://adventofcode.com/2020/day/22/input";
        private readonly IPuzzleInput _puzzleInput;

        public InputChecker(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }
        public string CheckInputToGetAnswerPart1()
        {
            var winner = CombatGame.PlayGameAndReturnWinner(PlayerHands.player1.Clone(), PlayerHands.player2.Clone());
            return winner.Score().ToString();
        }

        public string CheckInputToGetAnswerPart2()
        {
            var winner = CombatGame.PlayRecursiveGameAndReturnWinner(PlayerHands.player1.Clone(), PlayerHands.player2.Clone(),1);
            //return winner.CurrentHand.ToString();
            return winner.Score().ToString();
        }

        private (Hand player1, Hand player2) _playerHands;

        private (Hand player1, Hand player2) PlayerHands
        {
            get
            {
                if (_playerHands.player1 == null)
                {
                    SetUpPlayers();
                }

                return _playerHands;
            }
        }

        private void SetUpPlayers()
        {
            var player1Cards = new List<string>();
            var player2Cards = new List<string>();


            var whichPlayersCards = 1;
            foreach (var card in Input)
            {
                if (string.IsNullOrWhiteSpace(card))
                {
                    continue;
                }
                
                if (card == "Player 1:")
                {
                    whichPlayersCards = 1;
                    continue;
                }
                
                if (card == "Player 2:")
                {
                    whichPlayersCards = 2;
                    continue;
                }

                switch (whichPlayersCards)
                {
                    case 1:
                        player1Cards.Add(card);
                        break;
                    case 2:
                        player2Cards.Add(card);
                        break;
                }
            }
            var player1 = new Hand(player1Cards.Select(c => int.Parse(c)).ToList(),1);
            var player2 = new Hand(player2Cards.Select(c => int.Parse(c)).ToList(),2);
            _playerHands = (player1, player2);
        }


        private string[] _input;
        private IEnumerable<string> Input => _input ??= _puzzleInput.GetPuzzleInputAsArray(InputUrl);
    }
}