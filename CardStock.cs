using System;
using System.Collections.Generic;
using System.Collections;

namespace dotNet5776_02_2920_0267
{
    public class CardStock : IEnumerable<Card>
    {
        readonly List<Card> Cards = new List<Card>();

        public CardStock()
        {
            for (int i = 2; i <= 14; i++) // Makes a full deck
                for (int j = 0; j < 2; j++)
                    Cards.Add(new Card((E_Color)j, i));
        }

        public void Mix()
        {
            var r = new Random();
            for (int i = 0; i < Cards.Count; i++) // Switch random cards
            {
                int a = r.Next(0, Cards.Count);
                int b = r.Next(0, Cards.Count);
                Utils.ListSwap<Card>(Cards, a, b);
            }
        }

        override public string ToString()
        {
            string result = "";
            foreach (Card c in Cards)
                result += c + "\n";
            return result;
        }

        public void Distribute(params Player[] players)
        {
            int i = 0;
            while (i < Cards.Count)
                foreach (Player p in players)
                { 
                    p.AddCards(Cards[i]);
                    i++;
                }
            Cards.Clear();
        }

        public Card this [string n]
        {
            get
            {
                foreach (Card c in Cards)
                    if (c.CardName == n)
                        return c;
                return null;
            }
        }

        public void Sort()
        {
            Cards.Sort();
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return Cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddCard(Card c)
        {
            Cards.Add(c);
        }

        public void RemoveCard(Card c)
        {
            Cards.Remove(c);
        }

        public static explicit operator CardStock(Card c)
        {
            var result = new CardStock();
            result.Cards.Clear();
            result.AddCard(c);
            return result;
        }
    }
}
