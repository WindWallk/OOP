using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CustomLINQExtensionMethods
{
    public static class Extensions
    {
        public static IEnumerable<T> WhereNot<T>(
            this IEnumerable<T> collection,
            Func<T, bool> predicate)
        {
            var list = new List<T>();
            foreach (var item in collection)
            {
                T currentItem = item;
                if (!predicate(currentItem))
                {
                    list.Add(currentItem);
                }
            }

            return list;
        }

        public static TSelector Max<TSource, TSelector>(
            this IEnumerable<TSource> collection,
            Func<TSource, TSelector> predicate)
             where TSelector : IComparable
        {
            if (collection == null)
            {
                throw new InvalidOperationException("Collection is empty!");
            }

            TSelector max = predicate(collection.First());

            foreach (var item in collection)
            {
                if (max.CompareTo(predicate(item)) < 0)
                {
                    max = predicate(item);
                }
            }

            return max;
        }
    }
}
