using NUnit.Framework;
using Phony.Tests.Utility;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Phony.Tests
{
    [TestFixture]
    public class PhonyGeneratorSetupRandomDataTest
    {

        [Test]
        public void RandomIntegerProperties()
        {
            //Arrange
            int min = 0;
            int max = 10;
            var generator = new PhonyGenerator<SampleTestClass>(cfg => cfg.RandomiseIntegerProperties(min,max));

            //Act
            var testData = generator.Generate(3);

            //Assert
            foreach(var record in testData)
            {
                record.IntegerProp.ShouldBeInRange(min, max);
            }

        }

    }
}
