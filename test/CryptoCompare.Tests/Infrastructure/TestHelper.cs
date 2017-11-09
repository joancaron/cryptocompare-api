using System.IO;
using System.Reflection;

namespace CryptoCompare.Tests.Infrastructure
{
    public class TestHelper
    {
        public static Stream ReadFixture(string resourcePath)
        {
            var assembly = typeof(TestHelper).GetTypeInfo().Assembly;
            return assembly.GetManifestResourceStream($"{assembly.GetName().Name}.Fixtures.{resourcePath}.json");
        }
    }
}
