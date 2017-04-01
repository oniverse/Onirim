using System;
using System.Collections.Generic;

namespace Onirim.Deck
{
    public interface IDeck<T>
    {
        T GetFirst(Func<T, bool> predicate);

        void Shuffle();

        int Count();

        int Count(Func<T, bool> predicate);

        T At(int i);

        void Remove(T item);

        void Add(IEnumerable<T> item);
    }
}