using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week07.BL
{
    class card
    {
        private int value;
        private int suit;
        public card(int value, int suit)
        {
            this.value = value;
            this.suit = suit;
        }
        public int getvalue()
        {
            return value;
        }
        public int getsuit()
        {
            return suit;
        }
        public string getValueAsString()
        {
            if(value == 1)
            {
                return "Ace";
            }
            else if(value == 11)
            {
                return "Jack";
            }
            else if(value == 13)
            {
                return "King";
            }
            else if(value == 12)
            {
                return "Queen";
            }
            else
            {
                return value.ToString();
            }
        }
        public string getSuotAsString()
        {
            if(suit == 1)
            {
                return "Clubs"; 
            }
            else if (suit == 2)
            {
                return "Diamonds";
            }
            else if(suit == 3)
            {
                return "Spades";
            }
            else
            {
                return "Hearts";
            }
        }
        public string tostring()
        {
            return getSuotAsString() + " of " + getSuotAsString();
        }


    }
    class Deck
    {
        private int count;
        private card[] deck = new card[52];
        public Deck()
        {
            count = 0;
            for(int x=0; x<=4;x++)
            {
                for(int y = 1; y<=13;y++)
                {
                    deck[count] = new card(y, x);
                    count++;
                }
            }
        }
        public void shuffle()
        {
            System.Random rand = new System.Random();
            card temp;
            for(int x=0; x< 52;x++)
            {
                int num = rand.Next(0, 52);
                temp = deck[num];
                deck[num] = deck[x];
                deck[x] = temp;
            }
            count = 52;
        }
        public card dealCard()
        {
            if(count > 0)
            {
                count--;
                return deck[count];
            }
            else
            {
                return null;
            }
        }
        public int cardsLeft()
        {
            return count;
        }

    }

}
