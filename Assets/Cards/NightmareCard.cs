using System;
using UnityEngine;

namespace Onirim.Cards
{
	public class NightmareCard : Card
	{
		public NightmareCard() : base(CardType.Nightmare)
		{
		}

		public override string ToString()
		{
			return "NIGHTMARE!!";
        }

        public override Action InterruptAction
        {
            get
            {
                return () =>
                {
                    Debug.Log("Nightmare encountered");
                };
            }
        }
    }
}