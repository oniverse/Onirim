using Onirim.Cards;
using Onirim.Deck;
using System;
using System.Collections.Generic;

namespace Onirim.Extensions
{
	public static class DeckExtensions
	{
        private static Random random = new Random();

        public static void Shuffle<T>(this List<T> list)
		{
            for (int i = list.Count - 1; i > 0; i--)
			{
				var r = random.Next(i);
				var tmp = list[r];
				list[r] = list[i];
				list[i] = tmp;
			}
		}

        public static void DrawUpTo<T>(this List<T> destination, int upto, IDeck<Card> source, bool ignoreInterrupt)
            where T:Card
        {
            var drawIndex = 0;
            while (destination.Count < upto && source.Count() > 0)
			{
                var drawn = source.At(drawIndex);
                if (drawn.IsInterrupt)
                {
                    if (ignoreInterrupt)
                    {
                        drawIndex++;
                    }
                    else
                    {
                        drawn.InterruptAction.Invoke();
                        source.Remove(drawn);
                    }
                }
                else
                {
                    destination.Add(drawn as T);
                    source.Remove(drawn);
                }
			}
		}
		
		public static T Draw<T>(this IDeck<Card> source)
            where T : Card
        {
            Card drawn = source.At(0);
            while (source.Count() > 0)
            {
                source.Remove(drawn);
                if (drawn.IsInterrupt)
                {
                    drawn.InterruptAction.Invoke();
                }
                else
                {
                    break;
                }
                drawn = source.At(0);
            }
			return drawn as T;
        }

        public static bool TryGetLast<T>(this List<T> source, int count, out T[] last)
        {
            if (source.Count < count)
            {
                last = new T[] { };
                return false;
            }
            last = source.GetRange(source.Count - count, count).ToArray();
            return true;
        }
    }
}

