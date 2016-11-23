using Phony.Internals.RandomTypeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phony.Data
{
    /// <summary>
    /// Class containing preset random value generators
    /// </summary>
    public static class RandomValueSources
    {

        /// <summary>
        /// Choose a  random integer between 0 and 100
        /// </summary>
        public static Func<int> RandomInt100
        {
            get
            {
                return RandomInt(0, 100);
            }
        }

        /// <summary>
        /// Choose a random integer between min and max values
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static Func<int> RandomInt(int minValue, int maxValue)
        {
            Func<object> func = new RandomIntegerValueGenerator(0, 100).GenerateValue;
            return () => (int)func();
        }

        /// <summary>
        /// Choose a random value from selection of possibilities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Func<T> RandomValueSelector<T>(params T[] values)
        {
            Func<object> func = new RandomValueSelectorGenerator<T>(values).GenerateValue;
            return () => (T)func();
        }



    }
}
