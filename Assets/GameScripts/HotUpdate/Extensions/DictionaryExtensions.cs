using System.Collections.Generic;

namespace GameScripts.HotUpdate.Extensions
{
    public static class DictionaryExtensions
    {
        public static bool NotContainsKey<TKey, TValue>(this Dictionary<TKey, TValue> source, TKey key)
        {
            return !source.ContainsKey(key);
        }
    }
}