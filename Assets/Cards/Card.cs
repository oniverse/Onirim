using System;

namespace Onirim.Cards
{
	public class Card
	{
		public CardType Type { get; private set; }
        public bool IsInterrupt { get; private set; }

		public Card(CardType type)
		{
			Type = type;
            switch (type)
            {
                case CardType.Moon:
                case CardType.Sun:
                case CardType.Key:
                    IsInterrupt = false;
                    break;
                case CardType.Nightmare:
                case CardType.Door:
                    IsInterrupt = true;
                    break;
            }
        }

        public virtual Action InterruptAction
        {
            get { throw new NotImplementedException(); }
        }
	}
	
	public enum CardType
	{
		Moon,
		Sun,
		Key,
		Nightmare,
        Door,
    }

    public enum CardColor
    {
        Red,
        Blue,
        Green,
        Brown,
    }
}