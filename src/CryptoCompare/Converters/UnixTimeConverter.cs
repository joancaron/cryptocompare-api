using System;

using Newtonsoft.Json;

namespace CryptoCompare
{
    internal class UnixTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?)
                                                  || objectType == typeof(DateTimeOffset)
                                                  || objectType == typeof(DateTimeOffset?);
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            if (string.IsNullOrWhiteSpace(reader.Value?.ToString()))
            {
                return null;
            }

            return Convert.ToInt64(reader.Value).FromUnixTime();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
