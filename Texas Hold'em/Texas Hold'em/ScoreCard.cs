using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Texas_Hold_em
{
    internal class ScoreCard
    {
        //Take poker hand--> isStraightFlush, isStraight, isFlush, ThreeOfKind, FourOfKind, FullHouse, TwoPairs, OnePair,High Card

        public PokerHand pokerHands { get; private set; }
        List<Card> cards = new List<Card>();

        public ScoreCard(List<Card> cards) => this.cards = cards;



        //Add all the function here--> isStraightFlush, isStraight, isFlush, ThreeOfKind, FourOfKind, FullHouse, TwoPairs, OnePair,High Card
        //Using list for isStraight and isFLush
        //Using map for tok,fok,full,twos,ones,high

        public bool isStraight()
        {
            // Ace High
            if (cards.ElementAt(0).getValue() == 1 && cards.ElementAt(1).getValue() == 10 && cards.ElementAt(2).getValue() == 11 && cards.ElementAt(3).getValue() == 12 && cards.ElementAt(4).getValue() == 13){
                return true;
            }
            return (cards.ElementAt(0).getValue() == (cards.ElementAt(1).getValue() - 1) && cards.ElementAt(1).getValue() == (cards.ElementAt(2).getValue() - 1) && cards.ElementAt(2).getValue() == (cards.ElementAt(3).getValue() - 1) && cards.ElementAt(3).getValue() == (cards.ElementAt(4).getValue() - 1));
        }

        public bool isFlush()
        {
            var firstSuit=cards.ElementAt(0).getSuit();
            for(int i = 1; i < cards.Count; i++)
            {
                if (firstSuit != cards[i].getSuit()) { return false; }
            }
            return true;
        }

        public bool isStraightFlush()
        {
            return isStraight() && isFlush();
        }

        public bool isThreeOfKind()
        {
            int count;
            for(int i=0;i<cards.Count;i++)
            {
                count = 0;
                for(int j = i + 1; j < cards.Count; j++)
                {
                    if (cards[i].getValue() == cards[j].getValue())
                    {
                        count++;
                    }
                    if (count == 3) { return true; }
                }
            }
            return false;
        }
        public bool isFourOfKind()
        {
            int count;
            for (int i = 0; i < cards.Count; i++)
            {
                count = 0;
                for (int j = i + 1; j < cards.Count; j++)
                {
                    if (cards[i].getValue() == cards[j].getValue())
                    {
                        count++;
                    }
                    if (count == 4) { return true; }
                }
            }
            return false;
        }

        public bool isFullHouse()
        {
            Dictionary<int, int> myMap = new Dictionary<int, int>() { { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 }, { 8, 0 }, { 9, 0 }, { 10, 0 }, { 11, 0 }, { 12, 0 }, { 13, 0 } };
            foreach (var item in cards) { myMap[item.getValue()]++; }
            for (int i = 0; i < myMap.Count; i++)
            {
                if (myMap[i] == 2 || myMap[i]==3)
                {
                    if (myMap[i] == 2)
                    {
                        for(int j = i + 1; j < myMap.Count; j++)
                        {
                            if (myMap[j] == 3) { return true; }
                        }
                    }
                    if (myMap[i] == 3)
                    {
                        for(int j = i + 1; i < myMap.Count; j++)
                        {
                            if (myMap[j] == 2) { return true; }
                        }
                    }

                }
            }
            return false;
        }

        public bool isTwoPairs()
        {
            Dictionary<int, int> myMap = new Dictionary<int, int>() { { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 }, { 8, 0 }, { 9, 0 }, { 10, 0 }, { 11, 0 }, { 12, 0 }, { 13, 0 } };
            foreach (var item in cards) { myMap[item.getValue()]++; }
            for(int i = 0; i < myMap.Count; i++)
            {
                if (myMap[i] == 2) {
                    for(int j = i + 1; j < myMap.Count; j++)
                    {
                        if (myMap[j] == 2) { return true; }
                    }
                }
            }
            return false;
        }

        public bool isOnePair()
        {
            Dictionary<int, int> myMap = new Dictionary<int, int>() { { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 }, { 8, 0 }, { 9, 0 }, { 10, 0 }, { 11, 0 }, { 12, 0 }, { 13, 0 } };
            foreach (var item in cards) { myMap[item.getValue()]++; }
            for(int i = 0; i < myMap.Count; i++)
            {
                if (myMap[i] == 2) {return true; } 
            
            }
            return false;

        }

        public bool isHighCard()
        {
            return (!isFlush() && !isFourOfKind() && !isFullHouse() && !isOnePair() && !isStraight() && !isTwoPairs() && !isThreeOfKind());
        }
    }
}
