using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Rubyish
{
    public static class Types
    {
        /// <summary>
        /// Find the first type that match the name passed in inside of the current executing assembly
        /// </summary>
        /// <param name="assembly">The assembly we are searching</param>
        /// <param name="typeWeWant">The name of the type we are looking for</param>
        public static Type First(string typeWeWant)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return First(assembly, typeWeWant);
        }
        
        /// <summary>
        /// Find the first type that match the name passed in inside of the passed in assembly
        /// </summary>
        /// <param name="assembly">The assembly we are searching</param>
        /// <param name="typeWeWant">The name of the type we are looking for</param>
        public static Type First(Assembly assembly, string typeWeWant)
        {
            
            return Find(assembly, typeWeWant).First();
        }
        
        /// <summary>
        /// Find all the types that match the name passed in
        /// </summary>
        /// <param name="assembly">The assembly we are searching</param>
        /// <param name="typeWeWant">The name of the type we are looking for</param>
        public static List<Type> Find(Assembly assembly, string typeWeWant)
        {
            return assembly.GetTypes().Where(t => t.Name == typeWeWant).ToList();
        }
        
        /// <summary>
        /// Search the current executing assembly for a type with the given name
        /// </summary>
        /// <param name="typeWeWant">Name of the type we are looking for</param>
        public static bool Exists(string typeWeWant)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetTypes().Any(t => t.Name == typeWeWant);
        }
        
        /// <summary>
        /// Search an assembly for a type with the given name
        /// </summary>
        /// <param name="assembly">What assembly we are searching</param>
        /// <param name="typeWeWant">Name of the type we are looking for</param>
        public static bool Exists(Assembly assembly, string typeWeWant)
        {
            return assembly.GetTypes().Any(t => t.Name == typeWeWant);
        }
    }
}