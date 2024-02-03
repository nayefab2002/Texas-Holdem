using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Texas_Hold_em
{
    public class Card
    {
        string name;
        string suit;
        int value;
        public Card(string name = "", string suit = "", int value = 0)
        {
            this.name = name; this.suit = suit; this.value = value;
        }
        public string getName() { return this.name; }
        public string getSuit() { return this.suit; }
        public int getValue() { return this.value; }

    }
    public class Deck
    {
        static int numSuits = 4;
        static int numRanks = 13;
        int numCards = numSuits * numRanks;
        List<Card> cards;
        Random random = new Random();

        public List<Card> GetDeck()
        {
            cards = new List<Card>();

            string suit = "";
            string name = "";
            int value = 0;
            
            for (int i = 1; i <= numSuits; i++)
            {
                for (int j = 1; j <= numRanks; j++)
                {
                    switch (i)
                    {
                        case 1: suit = "Clubs"; break;
                        case 2: suit = "Diamonds"; break;
                        case 3: suit = "Hearts"; break;
                        case 4: suit = "Spades"; break;
                    }
                    switch (j)
                    {
                        case 1: name = "Ace"; value = 1; break;
                        case 2: name = "Two"; value = 2; break;
                        case 3: name = "Three"; value = 3; break;
                        case 4: name = "Four"; value = 4; break;
                        case 5: name = "Five"; value = 5; break;
                        case 6: name = "Six"; value = 6; break;
                        case 7: name = "Seven"; value = 7; break;
                        case 8: name = "Eight"; value = 8; break;
                        case 9: name = "Nine"; value = 9; break;
                        case 10: name = "Ten"; value = 10; break;
                        case 11: name = "Jack"; value = 11; break;
                        case 12: name = "Queen"; value = 12; break;
                        case 13: name = "King"; value = 13; break;
                        default:
                            break;
                    }
                    Card newCard = new Card(name, suit, value);
                    cards.Add(newCard);
                }


            }
            return cards;
        }
        public int getCardSize() { return this.cards.Count; }
        public Card callRandomCard()
        {
            Card firstCard = cards[random.Next(0, this.cards.Count)];
            cards.Remove(firstCard);
            return firstCard;

        }
    }
    internal class HoldemCards
    {
        private Card firstCard;
        private Card secondCard;
        private Deck myCards;
        public HoldemCards()
        {
            myCards = new Deck();
            myCards.GetDeck();
            this.firstCard = myCards.callRandomCard();
            this.secondCard = myCards.callRandomCard();

        }
        public string getFirstCardName() { return this.firstCard.getName(); }
        public string getSecondCardName() { return this.secondCard.getName(); }
        public int getFirstCardValue() { return this.firstCard.getValue(); }
        public int getSecondCardValue() { return this.secondCard.getValue(); }
        public string getFirstCardSuit() { return this.firstCard.getSuit(); }
        public string getSecondCardSuit() { return this.secondCard.getSuit(); }

    }
}
