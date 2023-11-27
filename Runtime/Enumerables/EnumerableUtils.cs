using System;
using System.Collections.Generic;
using System.Linq;

namespace Audune.Utils.Collections
{
  // Class that defines utilities for enumerables
  public static class EnumerableUtils
  {
    #region Ordering enumerables
    // Order an enumerable by the natural order of the items
    public static IOrderedEnumerable<T> Order<T>(this IEnumerable<T> enumerable) where T : IComparable<T>
    {
      return enumerable.OrderBy(t => t);
    }

    // Order an enumerable by the natural order of the items in descending order
    public static IOrderedEnumerable<T> OrderDescending<T>(this IEnumerable<T> enumerable) where T : IComparable<T>
    {
      return enumerable.OrderByDescending(t => t);
    }

    // Order an enumerable by the specified order of the items
    public static IOrderedEnumerable<T> OrderBy<T>(this IEnumerable<T> enumerable, IComparer<T> comparer)
    {
      return enumerable.OrderBy(t => t, comparer);
    }

    // Order an enumerable by the specified order of the items in descending order
    public static IOrderedEnumerable<T> OrderByDescending<T>(this IEnumerable<T> enumerable, IComparer<T> comparer)
    {
      return enumerable.OrderByDescending(t => t, comparer);
    }
    #endregion
  }
}