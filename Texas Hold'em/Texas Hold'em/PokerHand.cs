using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Texas_Hold_em
{
    internal class PokerHand:IComparable<PokerHand>
    {
        //It should have 5 cards use this class with ICompareObject interface---> We can use this interface to sort items
        public Card firstCard { get; }
        public Card secondCard { get; }
        public Card thirdCard { get; }
        public Card fourthCard { get; }
        public Card fifthCard { get; }
        public ScoreCard pokerScoreCard;
        public List<Card> _cards;
        public PokerHand(Card a, Card b, Card c, Card d, Card e)
        {
            this.firstCard = a;
            this.secondCard = b;
            this.thirdCard = c;
            this.fourthCard = d;
            this.fifthCard = e;
            sortCards();
            pokerScoreCard = new ScoreCard(_cards);
        }

        


        void swapCards(List<Card> cards, int first, int second)
        {
            var temp = cards[first];
            cards[first] = cards[second];
            cards[second] = temp;
        }
        void sortCards()
        {
            _cards = new List<Card>();
            _cards.Add(firstCard); _cards.Add(secondCard); _cards.Add(thirdCard); _cards.Add(fourthCard); _cards.Add(fifthCard);
            //insertion sort
            for (int i = 0; i < _cards.Count - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (_cards[j].getValue() < _cards[j - 1].getValue())
                    {
                        swapCards(_cards, j, j - 1);
                    }
                    else { break; }
                }
            }
        }

        public int getBestValue()
        {

            if (pokerScoreCard.isStraightFlush()) { return 10; }
            else if (pokerScoreCard.isFourOfKind()) { return 9; }
            else if (pokerScoreCard.isFullHouse()) { return 8; }
            else if(pokerScoreCard.isFlush()) { return 7; }
            else if (pokerScoreCard.isStraight()) { return 6; }
            else if(pokerScoreCard.isThreeOfKind()) { return 5; }
            else if(pokerScoreCard.isTwoPairs()) { return 4; }
            else if(pokerScoreCard.isOnePair()) { return 3; }
            else { return 2; }
        }
        
        public int CompareTo(PokerHand? other)
        {
            return getBestValue() - other.getBestValue();
        }
    }
}
