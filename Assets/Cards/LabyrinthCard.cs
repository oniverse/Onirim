namespace Onirim.Cards
{
	public class LabyrinthCard : Card
	{
		public CardColor Color { get; private set; }
		
		public LabyrinthCard(CardColor color, CardType type) : base(type)
		{
			Color = color;
		}
		
		public override string ToString ()
		{
            return string.Format("{0} {1}", Color, Type);
        }
	}
}