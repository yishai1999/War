using System;

namespace dotNet5776_02_2920_0267
{
    public enum E_Color
    {
        Red,
        Black
    }

    public class Card : IComparable
    {

        public E_Color Color
        {
            get;
            set;
        }

        private int number;

        public int Number
        { 
            get
            {
                return number;
            }
            set
            {
                if (Utils.InRange(value, 2, 14))
                    number = value;
                else
                    Console.WriteLine("No such card, man!");
            } 
        }

        public string CardName
        {
            get
            {
                if (Utils.InRange(number, 2, 10))
                    return number.ToString();
                else
                    switch (number)
                    {
                        case 11:
                            return "Jack";
                        case 12:
                            return "Queen";
                        case 13:
                            return "King";
                        case 14:
                            return "Ace";
                        default:
                            return "";
                    }
            }
        }

        public Card(E_Color c, int num)
        {
            Color = c;
            Number = num;
        }

        override public string ToString()
        {
            return  Color.ToString() + " " + CardName;
        }

        public int CompareTo(object obj)
        {
            Card card = obj as Card;
            if (card == null)
                throw new ArgumentException();
            else
                return Number - card.Number;
        }
    }
}

