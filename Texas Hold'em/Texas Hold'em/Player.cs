using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Texas_Hold_em
{
    internal class Player
    {
        //Take Holdem Hands(Cards of two), Add function fold, Bet and Call
        private HoldemCards holdemCards { get; }
        private bool isPlayerOnFold=false;
        private bool isPlayerOnBet = false;
        private bool isPlayerOnCall = false;
        private PokerHand sharedCards { get; }
        public int init_Money { get; private set; }
        public Player(int money)
        {
            holdemCards = new HoldemCards();
            this.init_Money= money;
        }


        static IEnumerable<IEnumerable<T>>
        GetKCombs<T>(IEnumerable<T> list, int length) where T : IComparable
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetKCombs(list, length - 1)
                .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) > 0),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        //ALternative approach
        



        public void Bet(int money)
        {
            init_Money-=money;
            isPlayerOnBet=true;
        }

        public void Call(int money)
        {
            init_Money-=money;
            isPlayerOnCall=true;
        }

        public void Fold()
        {
            isPlayerOnFold=true;
        }



    }
}
