using DataGenerator.Tests.Utility;
using NUnit.Framework;
using Shouldly;
using System;
using System.Linq;

namespace DataGenerator.Tests
{
    [TestFixture]
    public class DataGeneratorTest
    {

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(1)]
        public void Generate_Returns_Correct_Number_Of_Items(int count)
        {
            var generator = new DataGenerator<SampleTestClass>(cfg=> { });

            //Act
            var items = generator.Generate(count);

            //Assert
            items.Count().ShouldBe(count);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void Generate_Throws_ArgumentException_For_Invalid_Counts(int count)
        {
            var generator = new DataGenerator<SampleTestClass>(cfg => { });

            Assert.Throws<ArgumentException>(() => generator.Generate(count).ToList());
        }

        [Test]
        public void Generate_Sets_Constants()
        {
            //Arrange
            var integerValue = 10;
            var stringValue = "hello test data";
            var complexValue = new SampleTestClass();

            var generator = new DataGenerator<SampleTestClass>(cfg =>
            {
                cfg.Setup(x => x.IntegerProp, integerValue);
                cfg.Setup(x => x.StringProp, stringValue);
                cfg.Setup(x => x.ComplexProp, complexValue);
            });

            //Act
            var items = generator.Generate(100);


            //Assert
            items.ShouldAllBe(x => x.IntegerProp == integerValue);
            items.ShouldAllBe(x => x.StringProp == stringValue);
            items.ShouldAllBe(x => x.ComplexProp == complexValue);
        }

        [Test]
        public void Generate_Sets_Function_Results()
        {
            var generator = new DataGenerator<SampleTestClass>(cfg => { });

        }


    }
}