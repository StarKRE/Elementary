using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementaryFramework.Util
{
    public sealed class RandomWeightSet<T>
    {
        private readonly Random random;

        private readonly SortedSet<T> elements;

        private int sum;

        private readonly Func<T, int> getWeightFunc;

        public RandomWeightSet(IEnumerable<T> elements, Func<T, int> getWeightFunc)
        {
            this.getWeightFunc = getWeightFunc;
            this.random = new Random();
            this.elements = new SortedSet<T>(elements, new Comparer(getWeightFunc));
            this.sum = elements.Sum(getWeightFunc);
        }

        public T GetRandom()
        {
            var randomValue = this.random.Next(this.sum + Int.ONE);
            var totalValue = Int.ZERO;
            foreach (var element in this.elements)
            {
                var weight = this.getWeightFunc.Invoke(element);
                totalValue += weight;
                if (totalValue >= randomValue)
                {
                    return element;
                }
            }

            throw new Exception();
        }

        public void Add(T element)
        {
            if (this.elements.Add(element))
            {
                this.sum += this.getWeightFunc.Invoke(element);
            }
        }

        public void Remove(T element)
        {
            if (this.elements.Remove(element))
            {
                this.sum -= this.getWeightFunc.Invoke(element);
            }
        }

        private sealed class Comparer : IComparer<T>
        {
            private readonly Func<T, int> getWeightFunc;

            public Comparer(Func<T, int> getWeightFunc)
            {
                this.getWeightFunc = getWeightFunc;
            }

            public int Compare(T x, T y)
            {
                return this.getWeightFunc.Invoke(x) - this.getWeightFunc.Invoke(y);
            }
        }
    }
}