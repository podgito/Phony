using NUnit.Framework;
using Phony.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace Phony.Tests.Data
{
    [TestFixture]
    public class FirstNameGeneratorTest
    {
        FirstNameGenerator generator = new FirstNameGenerator();
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Generates_Random_First_Name_Should_Not_Be_Null_Or_Empty()
        {
            generator.Generate().ShouldNotBeNullOrEmpty();
        }

        [Test]
        public void Generate_Different_Name_With_Each_Call()
        {
            //act
            var name1 = generator.Generate();
            var name2 = generator.Generate();

            //Assert
            name1.ShouldNotBeSameAs(name2);

            Console.WriteLine(name1);
            Console.WriteLine(name2);
        }

    }
}
