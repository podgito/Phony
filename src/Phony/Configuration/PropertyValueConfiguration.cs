﻿using System;

namespace Phony.Configuration
{
    internal class PropertyValueConfiguration
    {
        public Func<object> ValueFunction { get; set; }

        /// <summary>
        /// Percentage of nulls or defaults to be output
        /// </summary>
        public int NullPercentage { get; set; }

        public PropertyValueConfiguration(Func<Object> valueFunction, int nullPercentage)
        {
            ValueFunction = valueFunction;
            NullPercentage = nullPercentage;
        }

        public PropertyValueConfiguration(Func<Object> valueFunction) : this(valueFunction, 0)
        { }
    }
}