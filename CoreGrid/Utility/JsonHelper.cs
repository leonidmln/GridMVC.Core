using Newtonsoft.Json;

namespace GridMvc.Utility
{
    internal static class JsonHelper
    {
        /// <summary>
        ///     JSON Serialization
        /// </summary>
        public static string JsonSerializer<T>(T t)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(t);
        }

        /// <summary>
        ///     JSON Deserialization
        /// </summary>
        public static T JsonDeserialize<T>(string jsonString)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}