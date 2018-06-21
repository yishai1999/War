using System;
using System.Collections.Generic;

namespace dotNet5776_02_2920_0267
{
    public class Game
    {
        CardStock deck;
        public readonly Player player1 = new Player("Player 1");
        public readonly Player player2 = new Player("Player 2");
        const string NoOneWon = "No one won yet.";

        public void StartGame()
        {
            deck = new CardStock();
            deck.Mix();
            deck.Distribute(player1, player2);
        }

        public string Winner()
        {
            if (player1.Lose())
                return player2.Name;
            if (player2.Lose())
                return player1.Name;
            return NoOneWon;
        }

        public bool End()
        {
            return Winner() != NoOneWon;
        }

        override public string ToString()
        {
            return string.Format("{0}: {1} cards\n{2}: {3} cards\n",
                player1.Name, player1.Count, player2.Name, player2.Count);
        }

        public void Move()
        {
            Move(new Queue<Card>());
        }

        // pile -- the cards that are currently in play
        public void Move(Queue<Card> pile)
        {
            if (!OutOfCards(player1, player2, pile))
            {
                // c1, c2 -- top cards
                Card c1 = player1.Pop();
                Card c2 = player2.Pop();
                pile.Enqueue(c1);
                pile.Enqueue(c2);
                if (c1.CompareTo(c2) > 0)
                    player1.AddCards(pile); // player1 wins the battle
                else if (c2.CompareTo(c1) > 0)
                    player2.AddCards(pile); // player2 wins the battle
                else if (!OutOfCards(player1, player2, pile))
                {
                    // add extra cards
                    pile.Enqueue(player1.Pop());
                    pile.Enqueue(player2.Pop());
                    Move(pile); // flip next cards
                }
            }
        }

        // Helper methods

        private bool OutOfCards(Player player1, Player player2, Queue<Card> pile)
        {
            if (player1.Count == 0)
                player2.AddCards(pile);
            else if (player2.Count == 0)
                player1.AddCards(pile);
            else
                return false;
            return true;
        }
    }
}

