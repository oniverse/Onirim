using Onirim.Cards;
using Onirim.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Onirim.Deck
{
    public class OnirimDeck : IDeck<Card>
    {
        private object _lock = new object();
        private List<Card> Cards;

        public OnirimDeck()
        {
            Cards = new List<Card>()
            {
                new LabyrinthCard(CardColor.Brown, CardType.Sun),
                new LabyrinthCard(CardColor.Brown, CardType.Sun),
                new LabyrinthCard(CardColor.Brown, CardType.Sun),
                new LabyrinthCard(CardColor.Brown, CardType.Sun),
                new LabyrinthCard(CardColor.Brown, CardType.Sun),
                new LabyrinthCard(CardColor.Brown, CardType.Sun),
                new LabyrinthCard(CardColor.Brown, CardType.Moon),
                new LabyrinthCard(CardColor.Brown, CardType.Moon),
                new LabyrinthCard(CardColor.Brown, CardType.Moon),
                new LabyrinthCard(CardColor.Brown, CardType.Moon),
                new LabyrinthCard(CardColor.Brown, CardType.Key),
                new LabyrinthCard(CardColor.Brown, CardType.Key),
                new LabyrinthCard(CardColor.Brown, CardType.Key),

                new LabyrinthCard(CardColor.Green, CardType.Sun),
                new LabyrinthCard(CardColor.Green, CardType.Sun),
                new LabyrinthCard(CardColor.Green, CardType.Sun),
                new LabyrinthCard(CardColor.Green, CardType.Sun),
                new LabyrinthCard(CardColor.Green, CardType.Sun),
                new LabyrinthCard(CardColor.Green, CardType.Sun),
                new LabyrinthCard(CardColor.Green, CardType.Sun),
                new LabyrinthCard(CardColor.Green, CardType.Moon),
                new LabyrinthCard(CardColor.Green, CardType.Moon),
                new LabyrinthCard(CardColor.Green, CardType.Moon),
                new LabyrinthCard(CardColor.Green, CardType.Moon),
                new LabyrinthCard(CardColor.Green, CardType.Key),
                new LabyrinthCard(CardColor.Green, CardType.Key),
                new LabyrinthCard(CardColor.Green, CardType.Key),

                new LabyrinthCard(CardColor.Blue, CardType.Sun),
                new LabyrinthCard(CardColor.Blue, CardType.Sun),
                new LabyrinthCard(CardColor.Blue, CardType.Sun),
                new LabyrinthCard(CardColor.Blue, CardType.Sun),
                new LabyrinthCard(CardColor.Blue, CardType.Sun),
                new LabyrinthCard(CardColor.Blue, CardType.Sun),
                new LabyrinthCard(CardColor.Blue, CardType.Sun),
                new LabyrinthCard(CardColor.Blue, CardType.Sun),
                new LabyrinthCard(CardColor.Blue, CardType.Moon),
                new LabyrinthCard(CardColor.Blue, CardType.Moon),
                new LabyrinthCard(CardColor.Blue, CardType.Moon),
                new LabyrinthCard(CardColor.Blue, CardType.Moon),
                new LabyrinthCard(CardColor.Blue, CardType.Key),
                new LabyrinthCard(CardColor.Blue, CardType.Key),
                new LabyrinthCard(CardColor.Blue, CardType.Key),

                new LabyrinthCard(CardColor.Red, CardType.Sun),
                new LabyrinthCard(CardColor.Red, CardType.Sun),
                new LabyrinthCard(CardColor.Red, CardType.Sun),
                new LabyrinthCard(CardColor.Red, CardType.Sun),
                new LabyrinthCard(CardColor.Red, CardType.Sun),
                new LabyrinthCard(CardColor.Red, CardType.Sun),
                new LabyrinthCard(CardColor.Red, CardType.Sun),
                new LabyrinthCard(CardColor.Red, CardType.Sun),
                new LabyrinthCard(CardColor.Red, CardType.Sun),
                new LabyrinthCard(CardColor.Red, CardType.Moon),
                new LabyrinthCard(CardColor.Red, CardType.Moon),
                new LabyrinthCard(CardColor.Red, CardType.Moon),
                new LabyrinthCard(CardColor.Red, CardType.Moon),
                new LabyrinthCard(CardColor.Red, CardType.Key),
                new LabyrinthCard(CardColor.Red, CardType.Key),
                new LabyrinthCard(CardColor.Red, CardType.Key),

                new NightmareCard(),
                new NightmareCard(),
                new NightmareCard(),
                new NightmareCard(),
                new NightmareCard(),
                new NightmareCard(),
                new NightmareCard(),
                new NightmareCard(),
                new NightmareCard(),
                new NightmareCard(),

                new DoorCard(CardColor.Red),
                new DoorCard(CardColor.Red),
                new DoorCard(CardColor.Blue),
                new DoorCard(CardColor.Blue),
                new DoorCard(CardColor.Brown),
                new DoorCard(CardColor.Brown),
                new DoorCard(CardColor.Green),
                new DoorCard(CardColor.Green),
            };

            Shuffle();
            Shuffle();
        }

        #region IDeck Members

        public Card GetFirst(Func<Card, bool> predicate)
        {
            lock(_lock)
            {
                return Cards.First(predicate.Invoke);
            }
        }

        public void Shuffle()
        {
            lock (_lock)
            {
                Cards.Shuffle();
            }
        }

        public int Count()
        {
            lock (_lock)
            {
                return Cards.Count;
            }
        }

        public int Count(Func<Card, bool> predicate)
        {
            lock (_lock)
            {
                return Cards.Count(predicate.Invoke);
            }
        }

        public Card At(int i)
        {
            lock(_lock)
            {
                return Cards[i];
            }
        }

        public void Remove(Card item)
        {
            lock (_lock)
            {
                Cards.Remove(item);
            }
        }

        public void Add(IEnumerable<Card> items)
        {
            lock (_lock)
            {
                Cards.AddRange(items);
            }
        }

        #endregion
    }
}
