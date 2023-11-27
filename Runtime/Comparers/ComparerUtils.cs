using System;
using System.Collections.Generic;

namespace Audune.Utils.Collections
{
  // Class that defines utilities for comparers
  public static class ComparerUtils
  {
    #region Creating comparers from functions
    // Create a comparer by extracting and comparing a key from an object
    public static IComparer<T> Comparing<T, U>(Func<T, U> keyExtractor, IComparer<U> keyComparer)
    {
      return Comparer<T>.Create((a, b) => keyComparer.Compare(keyExtractor(a), keyExtractor(b)));
    }
    public static IComparer<T> Comparing<T, U>(Func<T, U> keyExtractor)
    {
      return Comparing(keyExtractor, Comparer<U>.Default);
    }

    // Create a comparer that compares using the second comparer if the first comparer compares equal
    public static IComparer<T> ThenComparing<T>(this IComparer<T> first, IComparer<T> second)
    {
      return Comparer<T>.Create((a, b) => {
        var result = first.Compare(a, b);
        return result != 0 ? result : second.Compare(a, b);
      });
    }

    // Create a comparer that compares using the second comparer by extracting and comparing a key from an object if the first comparer compares equal
    public static IComparer<T> ThenComparing<T, U>(this IComparer<T> first, Func<T, U> keyExtractor, IComparer<U> keyComparer)
    {
      return ThenComparing(first, Comparing(keyExtractor, keyComparer));
    }
    public static IComparer<T> ThenComparing<T, U>(this IComparer<T> first, Func<T, U> keyExtractor)
    {
      return ThenComparing(first, Comparing(keyExtractor));
    }
    #endregion
  }
}