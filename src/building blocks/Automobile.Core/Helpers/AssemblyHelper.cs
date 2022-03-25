using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

namespace Automobile.Core.Helpers
{
    public static class AssemblyHelper
    {
        private static Assembly[] _myAssemblies;

        public static void InitializeMyAssemblies(params string[] startWith)
        {
            _myAssemblies = GetAssemblies(startWith);
        }

        public static Assembly[] GetAssemblies(params string[] startWith)
        {
            LoadAllAssemblies(startWith);

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            return assemblies.Where(c =>
                    c.FullName != null &&
                    startWith.Any(s => c.FullName.StartsWith(s, StringComparison.InvariantCultureIgnoreCase)))
                .ToArray();
        }

        private static void LoadAllAssemblies(params string[] startWith)
        {
            var loaded = new ConcurrentDictionary<string, bool>();

            bool ShouldLoad(string assemblyName)
            {
                return MyAssemblies(assemblyName)
                       && !loaded.ContainsKey(assemblyName);
            }

            bool MyAssemblies(string assemblyName)
            {
                return startWith.Any(s => assemblyName.StartsWith(s, StringComparison.InvariantCultureIgnoreCase));
            }

            void LoadReferencedAssembly(Assembly assembly)
            {
                foreach (var an in assembly.GetReferencedAssemblies().Where(a => ShouldLoad(a.FullName)))
                {
                    LoadReferencedAssembly(Assembly.Load(an));
                    loaded.TryAdd(an.FullName, true);
                }
            }

            foreach (var a in AppDomain.CurrentDomain.GetAssemblies().Where(a => ShouldLoad(a.FullName)))
            {
                loaded.TryAdd(a.FullName, true);
            }

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies().Where(a => MyAssemblies(a.FullName)))
            {
                LoadReferencedAssembly(assembly);
            }
        }

        public static Assembly[] GetMyAssemblies()
        {
            return _myAssemblies ?? throw new NullReferenceException("Not Initialized My Assemblies");
        }
    }
}