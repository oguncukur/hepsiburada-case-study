using Newtonsoft.Json;

namespace CaseStudy.Application.Extensions
{
    public static class CacheExtensions
    {
        public static string ToJson(this object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public static T ToObject<T>(this string value) where T : class
        {
            return string.IsNullOrEmpty(value) ? null : JsonConvert.DeserializeObject<T>(value);
        }
    }
}