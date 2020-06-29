using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Social
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> ConvertEnumerableToEnumEnumerable<T,T1>(this IEnumerable<T1> enumerable,Converter<T1,T> converter)
            where T : struct, IConvertible
        {
            return enumerable != null ? Array.ConvertAll(enumerable.ToArray(), converter) : new T[]{};
        }

    }
}
