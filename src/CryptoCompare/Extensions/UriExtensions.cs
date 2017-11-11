using System;
using System.Collections.Generic;
using System.Linq;

using JetBrains.Annotations;

namespace CryptoCompare
{
    /// <summary>
    /// Extensions for uris.
    /// </summary>
    internal static class UriExtensions
    {
        /// <summary>
        /// Merge a dictionary of values with an existing <see cref="Uri"/>
        /// </summary>
        /// <param name="uri">Original request Uri</param>
        /// <param name="parameters">Collection of key-value pairs</param>
        /// <returns>Updated request Uri</returns>
        public static Uri ApplyParameters([NotNull] this Uri uri, IDictionary<string, string> parameters)
        {
            Check.NotNull(uri, nameof(uri));

            if (parameters == null || !parameters.Any())
            {
                return uri;
            }

            // to prevent values being persisted across requests
            // use a temporary dictionary which combines new and existing parameters
            IDictionary<string, string> p = new Dictionary<string, string>(parameters);

            var hasQueryString = uri.OriginalString.IndexOf("?", StringComparison.Ordinal);

            var uriWithoutQuery =
                hasQueryString == -1 ? uri.ToString() : uri.OriginalString.Substring(0, hasQueryString);

            string queryString;
            if (uri.IsAbsoluteUri)
            {
                queryString = uri.Query;
            }
            else
            {
                queryString = hasQueryString == -1 ? "" : uri.OriginalString.Substring(hasQueryString);
            }

            var values = queryString.Replace("?", "").Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            var existingParameters = values.ToDictionary(
                key => key.Substring(0, key.IndexOf('=')),
                value => value.Substring(value.IndexOf('=') + 1));

            foreach (var existing in existingParameters)
            {
                if (!p.ContainsKey(existing.Key))
                {
                    p.Add(existing);
                }
            }

            var query = string.Join(
                "&",
                p.Where(param => !string.IsNullOrWhiteSpace(param.Value))
                    .Select(kvp => kvp.Key + "=" + Uri.EscapeDataString(kvp.Value)));
            if (uri.IsAbsoluteUri)
            {
                var uriBuilder = new UriBuilder(uri)
                                 {
                                     Query = query
                                 };
                return uriBuilder.Uri;
            }

            return new Uri(uriWithoutQuery + "?" + query, UriKind.Relative);
        }
    }
}
