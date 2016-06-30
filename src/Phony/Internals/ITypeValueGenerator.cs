using System;

namespace Phony.Internals
{
    internal interface ITypeValueGenerator
    {
        bool IsMatch(Type propertyType);

        object GenerateValue();
    }
}