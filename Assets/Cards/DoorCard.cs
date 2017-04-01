using System;

namespace Onirim.Cards
{
	public class DoorCard : Card
    {
        public CardColor Color { get; private set; }

        public DoorCard(CardColor color) : base(CardType.Door)
        {
            Color = color;
        }

		public override string ToString()
		{
            return string.Format("{0} {1}", Color, Type);
        }

        public override Action InterruptAction
        {
            get
            {
                return () =>
                {
                    GameStateManager.Limbo.Add(this);
                };
            }
        }
    }
}