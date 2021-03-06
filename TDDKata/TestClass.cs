// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace TDDKata
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void SumTwoPositiveDigitsWithDefaultSeparatorNShouldBeCorrectResult()
        {
            //Arrange
            StringCalc calc = new StringCalc();
            
            //Act
            int value = calc.Sum(@"2\n2");
            
            //Assert
            Assert.That(value, Is.EqualTo(4), "Wrong actual value");
        }

        [Test]
        public void SumTwoPositiveDigitsWithDefaultSeparatorCommaShouldBeCorrectResult()
        {
            //Arrange
            StringCalc calc = new StringCalc();

            //Act
            int value = calc.Sum("2,2");

            //Assert
            Assert.That(value, Is.EqualTo(4), "Wrong actual value");
        }

        [Test]
        public void SumManyPositiveDigitsWithDefaultSeparatorsCommaAndNShouldBeCorrectResult()
        {
            //Arrange
            StringCalc calc = new StringCalc();

            //Act
            int value = calc.Sum(@"2,2\n3");

            //Assert
            Assert.That(value, Is.EqualTo(7), "Wrong actual value");
        }

        [Test]
        public void SumManyPositiveDigitsWithCustomAndDefaultSeparatorsCommaAndNShouldBeCorrectResult()
        {
            //Arrange
            StringCalc calc = new StringCalc();

            //Act
            int value = calc.Sum(@"//;\n2,2\n3;4");

            //Assert
            Assert.That(value, Is.EqualTo(11), "Wrong actual value");
        }


        [Test]
        public void SumOnePositiveDigitsShouldBeCorrectResult()
        {
            //Arrange
            StringCalc calc = new StringCalc();

            //Act
            int value = calc.Sum("2");

            //Assert
            Assert.That(value, Is.EqualTo(2), "Wrong actual value");
        }

        [Test]
        public void SumEmptyShouldBeCorrectResult()
        {
            //Arrange
            StringCalc calc = new StringCalc();

            //Act
            int value = calc.Sum("");

            //Assert
            Assert.That(value, Is.EqualTo(0), "Wrong actual value");
        }

        [Test]
        public void SumManyPositiveDigitsShouldBeCorrectCode()
        {
            //Arrange
            StringCalc calc = new StringCalc();

            //Act
            int value = calc.Sum("2,2,2");

            //Assert
            Assert.That(value, Is.EqualTo(6), "Wrong actual value");
        }

        [Test]
        public void SumOneNegativeDigitsShouldBeErrorCode()
        {
            //Arrange
            StringCalc calc = new StringCalc();

            //Act
            int value = calc.Sum("-2");

            //Assert
            Assert.That(value, Is.EqualTo(-1), "Wrong actual value");
        }

        [Test]
        public void SumTwoNegativeDigitsShouldBeErrorCode()
        {
            //Arrange
            StringCalc calc = new StringCalc();

            //Act
            int value = calc.Sum("-2, -2");

            //Assert
            Assert.That(value, Is.EqualTo(-1), "Wrong actual value");
        }

        [Test]
        public void SumManyNegativeDigitsShouldBeErrorCode()
        {
            //Arrange
            StringCalc calc = new StringCalc();

            //Act
            int value = calc.Sum("-2, -2, -3");

            //Assert
            Assert.That(value, Is.EqualTo(-1), "Wrong actual value");
        }

        [Test]
        public void SumTwoPositiveDigitsWithBadSeparatorShouldBeErrorCode()
        {
            //Arrange
            StringCalc calc = new StringCalc();

            //Act
            int value = calc.Sum("2;2");

            //Assert
            Assert.That(value, Is.EqualTo(-1), "Wrong actual value");
        }
    }
}
