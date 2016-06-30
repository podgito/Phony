using System;

namespace Phony.Internals.RandomTypeData
{
    internal class RandomIntegerValueGenerator : RandomTypeValueGeneratorBase<int>
    {
        private readonly int maxValue;
        private readonly int minValue;

        public RandomIntegerValueGenerator(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override object GenerateValue()
        {
            var rand = new Random();
            return rand.Next(minValue, maxValue);
        }
    }
}