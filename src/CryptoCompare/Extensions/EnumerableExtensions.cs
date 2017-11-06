using System.Collections.Generic;

using JetBrains.Annotations;

namespace CryptoCompare
{
    internal static class EnumerableExtensions
    {
        public static string ToJoinedList([NotNull] this IEnumerable<string> list)
        {
            Check.NotEmpty(list, nameof(list));
            return string.Join(",", list);
        }
    }
}
