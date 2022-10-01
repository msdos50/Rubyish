using System;
using System.Collections.Generic;
using System.Reflection;

namespace Rubyish
{
    public static class InterrogationMethods
    {
        /// <summary>
        /// Check if this object has a property
        /// </summary>
        /// <param name="objectToCheck">The object we are checking</param>
        /// <param name="propName">The name of the property</param>
        public static bool HasProperty(this object objectToCheck, string propName)
        {
            if (objectToCheck == null)
                return false;

            var type = objectToCheck.GetType();
            return type.GetProperty(propName) != null;
        }
        
        /// <summary>
        /// Get an array of all the methods on this object
        /// </summary>
        /// <param name="objectToCheck">The object we are checking</param>
        /// <param name="flag">Binding flag used to control if we show public/private/static etc methods</param>
        public static MethodInfo[] Methods(this object objectToCheck, BindingFlags flag = (BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy))
        {
            if (objectToCheck == null)
                return new MethodInfo[]{};

            return objectToCheck.GetType().GetMethods(flag);
        }
        
        /// <summary>
        /// Get an array of all the properties on this object
        /// </summary>
        /// <param name="objectToCheck">The object we are checking</param>
        public static PropertyInfo[] Properties(this object objectToCheck)
        {
            if (objectToCheck == null)
                return new PropertyInfo[]{};

            return objectToCheck.GetType().GetProperties();
        }
     
        /// <summary>
        /// Does this object have the given method.  Because of the way method
        /// overloading works you have to pass the arguments you are going to use as well
        /// </summary>
        /// <param name="objectToCheck">The object we are checking</param>
        /// <param name="methodName">The name of the method we are looking for</param>
        /// <param name="args">The parameters to said method</param>
        public static bool RespondsTo(this object objectToCheck, string methodName, params object[] args)
        {
            if (objectToCheck == null)
                return false;

            var types = new List<Type>();
            foreach (object o in args)
            {
                types.Add(o.GetType());
            }
            var type = objectToCheck.GetType();
            return type.GetMethod(methodName, types.ToArray()) != null;
        }
    }
}