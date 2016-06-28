using NUnit.Framework;
using Phony.Tests.Utility;
using Shouldly;
using System;
using System.Linq;
using Phony.Data;

namespace Phony.Tests
{
    [TestFixture]
    public class PhonyGeneratorTest
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(1)]
        public void Generate_Returns_Correct_Number_Of_Items(int count)
        {
            var generator = new PhonyGenerator<SampleTestClass>(cfg => { });

            //Act
            var items = generator.Generate(count);

            //Assert
            items.Count().ShouldBe(count);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void Generate_Throws_ArgumentException_For_Invalid_Counts(int count)
        {
            var generator = new PhonyGenerator<SampleTestClass>(cfg => { });

            Assert.Throws<ArgumentException>(() => generator.Generate(count).ToList());
        }

        [Test]
        public void Generate_Sets_Constants()
        {
            //Arrange
            var integerValue = 10;
            var stringValue = "hello test data";
            var complexValue = new SampleTestClass();

            var generator = new PhonyGenerator<SampleTestClass>(cfg =>
            {
                cfg.Setup(x => x.IntegerProp, integerValue);
                cfg.Setup(x => x.StringProp, stringValue);
                cfg.Setup(x => x.ComplexProp, complexValue);
            });

            //Act
            var items = generator.Generate(100).ToList();

            //Assert
            items.ShouldAllBe(x => x.IntegerProp == integerValue);
            items.ShouldAllBe(x => x.StringProp == stringValue);
            items.ShouldAllBe(x => x.ComplexProp == complexValue);
        }

        [Test]
        public void Generate_Sets_Function_Results()
        {
            //Arrange
            Func<int> intFunc = () => 1 + 2;

            var generator = new PhonyGenerator<SampleTestClass>(cfg =>
            {
                cfg.Setup(x => x.IntegerProp, intFunc);
            });

            //Act
            var items = generator.Generate(1);

            //Assert
            items.ShouldAllBe(x => x.IntegerProp == 3);
        }

        [Test]
        public void Generate_Sets_Extension_Function_Results()
        {
            var generator = new PhonyGenerator<SampleTestClass>(cfg =>
            {
                cfg.Setup(x => x.StringProp, cfg.FirstName);
            });

            //Act
            var items = generator.Generate(2).ToList();

            //Assert
            items.ShouldAllBe(x => !string.IsNullOrEmpty(x.StringProp));
            items.First().StringProp.ShouldNotBeSameAs(items.Skip(1).First().StringProp);

        }

        [Test]
        public void Generate_Sets_All_Properties_To_Null_When_NullPercentage_Set_To_100()
        {
            //Arrange
            var generator = new PhonyGenerator<SampleTestClass>(cfg =>
            {
                cfg.Setup(x => x.StringProp, DataSources.FirstNames, 100);
            });

            //Act
            var items = generator.Generate(10).ToList();

            //Assert
            items.ShouldAllBe(x => x.StringProp == null);

            foreach (var item in items)
            {
                Console.WriteLine(item.StringProp);
            }

        }

        [Test]
        public void Generate_Sets_Half_Of_Properties_To_Null_When_NullPercentage_Set_To_50()
        {
            //Arrange
            var generator = new PhonyGenerator<SampleTestClass>(cfg =>
            {
                cfg.Setup(x => x.StringProp, DataSources.FirstNames, 50);
            });

            //Act
            var items = generator.Generate(10).ToList();

            //Assert
            items.Where(i => i.StringProp == null).Count().ShouldBe(5);
            items.Where(i => !string.IsNullOrEmpty(i.StringProp)).Count().ShouldBe(5);

            foreach (var item in items)
            {
                Console.WriteLine(item.StringProp);
            }
        }
    }
}