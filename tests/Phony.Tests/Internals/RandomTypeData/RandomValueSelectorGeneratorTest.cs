using NUnit.Framework;
using Phony.Internals.RandomTypeData;
using Shouldly;

namespace Phony.Tests.Internals.RandomTypeData
{
    [TestFixture]
    public class RandomValueSelectorGeneratorTest
    {
        [Test]
        public void SelectsValueFromList()
        {
            var values = new string[] { "123", "abc", "a1b2", "test" };
            var generator = new RandomValueSelectorGenerator<string>(values);
            for (int i = 0; i < 100; i++)
            {
                var value = (string)generator.GenerateValue();
                value.ShouldBeOneOf(values);
            }
        }

        [Test]
        public void WithOnlyOneValueItShouldAlwaysReturnIt()
        {
            var values = new string[] { "Phony" };
            var generator = new RandomValueSelectorGenerator<string>(values);
            for (int i = 0; i < 100; i++)
            {
                var value = (string)generator.GenerateValue();
                value.ShouldBe(values[0]);
            }
        }
    }
}