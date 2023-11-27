using System;
using System.Collections.Generic;
using System.Linq;

namespace Audune.Utils.Collections
{
  // Class that defines utility methods for lists
  public static class ListUtils
  {
    #region Finding elements and indices
    // Try to find the first occurrence of an element in a list
    public static bool TryFind<T>(this List<T> list, Predicate<T> match, out T element)
    {
      if (list == null)
        throw new ArgumentNullException(nameof(list));

      element = list.Find(match);
      return element != null;
    }

    // Try to find the last occurrence of an element in a list
    public static bool TryFindLast<T>(this List<T> list, Predicate<T> match, out T element)
    {
      if (list == null)
        throw new ArgumentNullException(nameof(list));

      element = list.FindLast(match);
      return element != null;
    }

    // Try to find the index of the first occurrence of an element in a list
    public static bool TryFindIndex<T>(this List<T> list, Predicate<T> match, out int index)
    {
      if (list == null)
        throw new ArgumentNullException(nameof(list));

      index = list.FindIndex(match);
      return index > -1;
    }

    // Try to find the index of the last occurrence of an element in a list
    public static bool TryFindLastIndex<T>(this List<T> list, Predicate<T> match, out int index)
    {
      if (list == null)
        throw new ArgumentNullException(nameof(list));

      index = list.FindLastIndex(match);
      return index > -1;
    }
    #endregion

    #region Picking elements and indices
    // Pick the index of a random element from a list
    public static int PickIndex<T>(this List<T> list)
    {
      if (list == null)
        throw new ArgumentNullException(nameof(list));

      return list.Count == 0 ? -1 : (list.Count == 1 ? 0 : UnityEngine.Random.Range(0, list.Count));
    }

    // Pick a random element from a list
    public static T Pick<T>(this List<T> list)
    {
      if (list == null)
        throw new ArgumentNullException(nameof(list));

      var index = PickIndex(list);
      return index == -1 ? default : list[index];
    }

    // Pick multiple indices of random elements from a list
    public static IEnumerable<int> PickIndex<T>(this List<T> list, int amount)
    {
      if (list == null)
        throw new ArgumentNullException(nameof(list));
      if (amount < 1)
        throw new ArgumentException("amount must be bigger than zero", nameof(amount));

      var indexList = Enumerable.Range(0, list.Count - 1).ToList();
      Shuffle(indexList);
      return indexList.Take(amount);
    }

    // Pick multiple random elements from a list
    public static IEnumerable<T> Pick<T>(this List<T> list, int amount)
    {
      if (list == null)
        throw new ArgumentNullException(nameof(list));
      if (amount < 1)
        throw new ArgumentException("amount must be bigger than zero", nameof(amount));

      return PickIndex(list, amount).Select(index => list[index]);
    }
    #endregion

    #region Shuffling
    // Shuffle a list
    public static void Shuffle<T>(this List<T> list)
    {
      if (list == null)
        throw new ArgumentNullException(nameof(list));

      var n = list.Count;
      while (n > 1)
      {
        n--;
        var k = UnityEngine.Random.Range(0, n + 1);
        (list[n], list[k]) = (list[k], list[n]);
      }
    }
    #endregion
  }
}