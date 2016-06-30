using System;

namespace Phony.Internals.RandomTypeData
{
    internal abstract class RandomTypeValueGeneratorBase<T> : ITypeValueGenerator
    {
        public abstract object GenerateValue();

        public bool IsMatch(Type propertyType)
        {
            return propertyType == typeof(T);
        }
    }
}