using Phony;
using Phony.Internals.RandomTypeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phony
{
    /// <summary>
    /// Extension methods for phony generator
    /// </summary>
    public static class RandomDataExtensions
    {


        /// <summary>
        /// Set all Integer properties to be random numbers
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        public static void RandomiseIntegerProperties<T>(this PhonyGenerator<T> generator, int min, int max) where T : new()
        {
            var valueGenerator = new RandomIntegerValueGenerator(min, max);

            generator.AddGlobalValueGenerator(valueGenerator);
        }

        /// <summary>
        /// Set all string properties to be random strings
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="generator"></param>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        public static void RandomiseStringProperties<T>(this PhonyGenerator<T> generator, int minLength, int maxLength) where T : new()
        {
            throw new NotImplementedException();
        }

    }
}
