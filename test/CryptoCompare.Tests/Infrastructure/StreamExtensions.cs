using System.IO;

using Newtonsoft.Json;

namespace CryptoCompare.Tests.Infrastructure
{
    public static class StreamExtensions
    {
        public static T DeserializeJson<T>(this Stream stream)
        {
            var serializer = new JsonSerializer();
            T data;
            using (var streamReader = new StreamReader(stream))
            {
                data = (T)serializer.Deserialize(streamReader, typeof(T));
            }
            return data;
        }
    }
}
