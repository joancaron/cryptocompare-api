using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CryptoCompare
{
    internal class StringToSubConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise,
        /// <c>false</c>.
        /// </returns>
        /// <seealso cref="M:Newtonsoft.Json.JsonConverter.CanConvert(Type)"/>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IEnumerable<Sub>);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        /// <seealso cref="M:Newtonsoft.Json.JsonConverter.ReadJson(JsonReader,Type,object,JsonSerializer)"/>
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            JArray tokens = JArray.Load(reader);

            if (tokens?.HasValues ?? false)
            {
                return tokens.Values().Select(
                    token =>
                    {
                        var values = token.ToString().Split('~');
                        if (values.Length == 4)
                        {
                            Enum.TryParse(values.ElementAtOrDefault(0), out SubId subId);
                            return new Sub()
                                   {
                                       SubId = subId,
                                       Exchange = values.ElementAtOrDefault(1),
                                       FromSymbol = values.ElementAtOrDefault(2),
                                       ToSymbol = values.ElementAtOrDefault(3)
                                   };
                        }
                        return null;
                    });
            }
            return null;
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <seealso cref="M:Newtonsoft.Json.JsonConverter.WriteJson(JsonWriter,object,JsonSerializer)"/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
