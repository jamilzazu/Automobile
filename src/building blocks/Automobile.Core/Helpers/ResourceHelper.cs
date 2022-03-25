using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Automobile.Core.Helpers
{
    public static class ResourceHelper
    {
        public static string GetScript(string name)
        {
            var assembly = Assembly.GetEntryAssembly();
            return assembly.GetScript(name);
        }

        public static string GetScript(this Assembly assembly, string name)
        {
            var resources = assembly.GetManifestResourceNames();
            var resourcePath = resources.Single(str => str.EndsWith(name));

            using var stream = assembly.GetManifestResourceStream(resourcePath);

            if (stream == null)
            {
                throw new ApplicationException($"File {name} not found.");
            }

            using var reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }
    }
}