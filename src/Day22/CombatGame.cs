using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Day22
{
    public static class CombatGame
    {
        public static Hand PlayGameAndReturnWinner(Hand player1, Hand player2)
        {
            var round = 1;
            while (player1.HandCount > 0 && player2.HandCount > 0)
            {
                Console.WriteLine($"Round: {round}");
                Console.WriteLine($"Player 1 plays: {player1.GetTopCard()}");
                Console.WriteLine($"Player 2 plays: {player2.GetTopCard()}");

                if (player1.GetTopCard() > player2.GetTopCard())
                {
                    Console.WriteLine("Player 1 won!!!");
                    player1.PlayerWon(player2.GetTopCard());
                    player2.PlayerLost();
                }
                else if (player1.GetTopCard() < player2.GetTopCard())
                {
                    Console.WriteLine("Player 2 won!!!");
                    player2.PlayerWon(player1.GetTopCard());
                    player1.PlayerLost();
                    
                }
                
                Console.WriteLine();
                Console.WriteLine();
                round++;
            }

            if (player1.HandCount > 0)
            {
                return player1;
            }

            return player2;
        }

        public static Hand PlayRecursiveGameAndReturnWinner(Hand player1, Hand player2, int game)
        {
            Console.WriteLine($"=== Game {game} ===");
            var previousRounds = new HashSet<string>();

            
            
            var round = 0;
            while (player1.HandCount > 0 && player2.HandCount > 0)
            {
                var currentRoundHash = GetRoundHash(player1.CurrentHand, player2.CurrentHand);
                
                if (previousRounds.Contains(currentRoundHash))
                {
                    return player1;
                }

                previousRounds.Add(currentRoundHash);
                
                round++;
                Console.WriteLine();
                
                Console.WriteLine($"-- Round {round} (Game {game}) --");
                Console.WriteLine($"Player 1's deck: {player1.CurrentHand}");
                Console.WriteLine($"Player 2's deck: {player2.CurrentHand}");
                Console.WriteLine($"Player 1 plays: {player1.GetTopCard()}");
                Console.WriteLine($"Player 2 plays: {player2.GetTopCard()}");
                //Console.WriteLine($"Player 1 plays: {player1.GetTopCard()}");
                //Console.WriteLine($"Player 2 plays: {player2.GetTopCard()}");

                if ((player1.GetTopCard() > player1.HandCount - 1) || (player2.GetTopCard() > player2.HandCount - 1))
                {
                    if (player1.GetTopCard() > player2.GetTopCard())
                    {
                        Console.WriteLine($"Player 1 wins round {round} of game {game}!");
                        player1.PlayerWon(player2.GetTopCard());
                        player2.PlayerLost();
                        continue;
                    }

                    Console.WriteLine($"Player 2 wins round {round} of game {game}!");
                    player2.PlayerWon(player1.GetTopCard());
                    player1.PlayerLost();
                    continue;
                }

                var player1SubHand = player1.MakeNewHandSkippingCurrentTopCard(player1.GetTopCard());
                var player2SubHand = player2.MakeNewHandSkippingCurrentTopCard(player2.GetTopCard());
                Console.WriteLine("Playing a sub-game to determine the winner...");
                var winner = PlayRecursiveGameAndReturnWinner(player1SubHand, player2SubHand, game +1);

                if (winner.Id == 1)
                {
                    //Console.WriteLine("Player 1 won!!!");
                    player1.PlayerWon(player2.GetTopCard());
                    player2.PlayerLost();
                    continue;
                }
                
                //Console.WriteLine("Player 2 won!!!");
                player2.PlayerWon(player1.GetTopCard());
                player1.PlayerLost();
            }
            
            if (player1.HandCount > 0)
            {
                return player1;
            }
            
            return player2;
        }

        private static string GetRoundHash(string player1Cards, string player2Cards)
        {
            using var md5 = new MD5CryptoServiceProvider();
            var bytes = Encoding.ASCII.GetBytes($"{player1Cards}{player2Cards}");
            var hashed = md5.ComputeHash(bytes);
            var asString = Convert.ToBase64String(hashed);
            return asString;
        }
        
    }
}