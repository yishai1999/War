using System.Collections.Generic;

namespace dotNet5776_02_2920_0267
{
    public class Player
    {
        public string Name
        {
            get;
            set;
        }

        public int Count
        {
            get
            {
                return Pile.Count;
            }
        }

        public Player(string n)
        {
            Name = n;
        }

        readonly Queue<Card> Pile = new Queue<Card>();

        public void AddCards(params Card[] cards)
        {
            AddCards(new List<Card>(cards));
        }

        public void AddCards(IEnumerable<Card> cards)
        {
            foreach (Card c in cards)
                Pile.Enqueue(c);
        }

        override public string ToString()
        {
            string result = string.Format("Name: {0}\nCards: {1}\n", Name, Pile.Count);
            foreach (Card c in Pile) // Add all cards
                result += c + "\n";
            return result;
        }

        public bool Lose()
        {
            return Pile.Count == 0;
        }

        public Card Pop()
        {
            return Pile.Dequeue();
        }
    }
}

