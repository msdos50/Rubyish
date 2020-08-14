using Newtonsoft.Json;

namespace Rubyish
{
    public static class JsonMethods
    {
        /// <summary>
        /// Serialize an object into JSON
        /// </summary>
        /// <param name="obj">The object we are trying to serialize</param>
        /// <returns>A string in JSON format</returns>
        public static string ToJson(this object obj)
        {
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore, 
                ContractResolver = null
            };
                
            return obj.ToJson(settings);
        }
        
        /// <summary>
        /// Serialize an object into JSON
        /// </summary>
        /// <param name="obj">The object we are trying to serialize</param>
        /// <param name="settings">JSON serialization options</param>
        /// <returns>A string in JSON format</returns>
        public static string ToJson(this object obj, JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(obj, settings);
        }
        
        /// <summary>
        /// Creates and object from a json string
        /// </summary>
        /// <param name="obj">An incoming string in json format</param>
        /// <typeparam name="T">The type of the object we are trying to deserialize into</typeparam>
        public static T FromJson<T>(this string obj)
        {
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore, 
                ContractResolver = null,
                Formatting = Formatting.Indented
            };
            
            return obj.FromJson<T>(settings);
        }
        
        /// <summary>
        /// Creates and object from a json string
        /// </summary>
        /// <param name="obj">An incoming string in json format</param>
        /// <param name="settings">JSON serialization options</param>
        /// <typeparam name="T">The type of the object we are trying to deserialize into</typeparam>
        public static T FromJson<T>(this string obj, JsonSerializerSettings settings)
        {
            return JsonConvert.DeserializeObject<T>(obj, settings);
        }
    }
}