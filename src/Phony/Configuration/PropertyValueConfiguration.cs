using Phony.Internals;
using System;

namespace Phony.Configuration
{
    internal class PropertyValueConfiguration
    {
        public Func<GeneratorState, object> ValueFunction { get; set; }

        /// <summary>
        /// Percentage of nulls or defaults to be output
        /// </summary>
        public int NullPercentage { get; set; }

        public PropertyValueConfiguration(Func<Object> valueFunction, int nullPercentage)
        {
            ValueFunction = g => valueFunction;
            NullPercentage = nullPercentage;
        }

        public PropertyValueConfiguration(Func<GeneratorState, object> valueFunction, int nullPercentage)
        {
            ValueFunction = valueFunction;
            NullPercentage = nullPercentage;
        }

        public PropertyValueConfiguration(Func<Object> valueFunction) : this(valueFunction, 0)
        { }
    }
}