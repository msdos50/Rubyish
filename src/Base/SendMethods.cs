using System;
using System.Collections.Generic;
using System.Linq;

namespace Rubyish
{
    public static class SendMethods
    {
        /// <summary>
        /// Send a message to the given object.  If that object has a method or property that can respond
        /// then we will call that method / property
        /// </summary>
        /// <param name="objectToCheck">The object we are sending a message to</param>
        /// <param name="methodName">The method or property name</param>
        /// <param name="args">The arguments to pass to said method</param>
        /// <returns></returns>
        /// <exception cref="MethodAccessException">Throws an exception if we can't call the method asked for</exception>
        public static object Send(this object objectToCheck, string methodName, params object[] args)
        {
            return Send(objectToCheck, methodName, true, args);
        }
        
        /// <summary>
        /// Send a message to the given object.  If that object has a method or property that can respond
        /// then we will call that method / property
        /// </summary>
        /// <param name="objectToCheck">The object we are sending a message to</param>
        /// <param name="methodName">The method or property name</param>
        /// <param name="throwOnMissing">Should we throw an exception if the object cannot respond</param>
        /// <param name="args">The arguments to pass to said method</param>
        /// <returns></returns>
        /// <exception cref="MethodAccessException">Throws an exception if we can't call the method asked for</exception>
        public static object Send(this object objectToCheck, string methodName, bool throwOnMissing, params object[] args)
        {
            return Send<object>(objectToCheck, methodName, throwOnMissing, args);
        }
        
        /// <summary>
        /// Send a message to the given object.  If that object has a method or property that can respond
        /// then we will call that method / property
        /// </summary>
        /// <param name="objectToCheck">The object we are sending a message to</param>
        /// <param name="methodName">The method or property name</param>
        /// <param name="args">The arguments to pass to said method</param>
        /// <typeparam name="T">The type of the return value</typeparam>
        /// <returns></returns>
        /// <exception cref="MethodAccessException">Throws an exception if we can't call the method asked for</exception>
        public static T Send<T>(this object objectToCheck, string methodName, params object[] args)
        {
            return Send<T>(objectToCheck, methodName, true, args);
        }
        
        /// <summary>
        /// Send a message to the given object.  If that object has a method or property that can respond
        /// then we will call that method / property
        /// </summary>
        /// <param name="objectToCheck">The object we are sending a message to</param>
        /// <param name="methodName">The method or property name</param>
        /// <param name="throwOnMissing">Should we throw an exception if this object does not respond</param>
        /// <param name="args">The arguments to pass to said method</param>
        /// <typeparam name="T">The type of the return value</typeparam>
        /// <returns></returns>
        /// <exception cref="MethodAccessException">Throws an exception if we can't call the method asked for</exception>
        public static T Send<T>(this object objectToCheck, string methodName, bool throwOnMissing, params object[] args)
        {
            var errorString = $"Could not find the method {methodName} on {objectToCheck.GetType().FullName}";
            var types = new List<Type>();
            foreach (object o in args)
            {
                types.Add(o.GetType());
            }
        
            if (objectToCheck.RespondsTo(methodName, args))
            {
                var method = objectToCheck.GetType().GetMethod(methodName, types.ToArray());
                return (T)method.Invoke(objectToCheck, args);
            }
        
            if (objectToCheck.HasProperty(methodName))
            {
                var prop = objectToCheck.GetType().GetProperty(methodName);
                if (args.Any() && prop != null)
                {
                    prop.SetValue(objectToCheck, args[0], null);
                    return (T) args[0];
                }
                else
                {
                    return (T)prop.GetValue(objectToCheck);
                }
            }

            try
            {
                if (objectToCheck is IMethodMissing)
                {
                    return (T)((objectToCheck as IMethodMissing).MethodMissing(methodName, args));
                }
            }
            catch (Exception ex)
            {
                throw new MethodMissingException(errorString, ex);
            }
            
            if(throwOnMissing)
                throw new MethodMissingException(errorString);
            
            return default(T);
        }
    }
}