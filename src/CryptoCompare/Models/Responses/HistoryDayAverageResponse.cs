using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CryptoCompare.Models.Responses
{
    /// <summary>
    /// A history day average response.
    /// TODO: replace ReadOnlyDictionary&lt;string, object&gt; by ReadOnlyDictionary&lt;string, decimal&gt;
    /// </summary>
    /// <seealso cref="T:System.Collections.ObjectModel.ReadOnlyDictionary{System.String, System.Object}"/>
    public class HistoryDayAverageResponse : ReadOnlyDictionary<string, object>
    {
        public HistoryDayAverageResponse(IDictionary<string, object> dictionary)
            : base(dictionary)
        {
        }
    }
}
