using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeHelper
{
    public static class Extensions
    {
        public static TValue ValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue defaultValue)
        {
            TValue value;
            if (!dict.TryGetValue(key, out value))
                value = defaultValue;
            return value;
        }
    }
}
