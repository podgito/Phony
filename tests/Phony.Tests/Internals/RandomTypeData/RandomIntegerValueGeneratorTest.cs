using NUnit.Framework;
using Phony.Internals.RandomTypeData;
using Shouldly;

namespace Phony.Tests.Internals.RandomTypeData
{
    [TestFixture]
    public class RandomIntegerValueGeneratorTest
    {
        private RandomIntegerValueGenerator intGenerator;

        [SetUp]
        public void Setup()
        {
            intGenerator = new RandomIntegerValueGenerator(0, 10);
        }

        [Test]
        public void All_Values_Within_Range()
        {
            //Act
            for (int i = 0; i < 1000; i++)
            {
                var value = (int)intGenerator.GenerateValue();
                value.ShouldBeInRange(0, 10);
            }
        }
    }
}