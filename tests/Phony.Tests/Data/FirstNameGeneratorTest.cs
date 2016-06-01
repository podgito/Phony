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

    }
}
