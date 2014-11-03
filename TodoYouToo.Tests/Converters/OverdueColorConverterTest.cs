using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoYouToo.Converters;
using System.Windows.Media;
using TodoYouToo.Tests.Utilities;

namespace TodoYouToo.Tests
{
    [TestClass]
    public class OverdueColorConverterTest
    {
        private DateTime FirstOfJanuary = new DateTime(2010, 01, 01);
        private DateTime SecondOfJanuary = new DateTime(2010, 01, 02);
        private DateTime ThirdOfJanuary = new DateTime(2010, 01, 03);

        private OverdueColorConverter GetInstance(DateTime current)
        {
            return new MockableOverdueColorConverter(current);
        }

        [TestMethod]
        public void Convert_WhenCalledWithAnEmptyDate_ReturnsBlack()
        {
            // Arrange
            var converter = this.GetInstance(FirstOfJanuary);
            // Act
            var result = converter.Convert(null, null, null, null);
            // Assert
            Assert.AreEqual(Colors.Black.ToString(), result.ToString());
        }

        [TestMethod]
        public void Convert_WhenCalledWithGreaterDate_ReturnsBlack()
        {
            // Arrange
            var converter = this.GetInstance(SecondOfJanuary);
            // Act
            var result = converter.Convert(ThirdOfJanuary, null, null, null);
            // Assert
            Assert.AreEqual(Colors.Black.ToString(), result.ToString());
        }

        [TestMethod]
        public void Convert_WhenCalledWithSameDate_ReturnsBlack()
        {
            // Arrange
            var converter = this.GetInstance(SecondOfJanuary);
            // Act
            var result = converter.Convert(SecondOfJanuary, null, null, null);
            // Assert
            Assert.AreEqual(Colors.Black.ToString(), result.ToString());
        }

        [TestMethod]
        public void Convert_WhenCalledWithLesserDate_ReturnsRed()
        {
            // Arrange
            var converter = this.GetInstance(SecondOfJanuary);
            // Act
            var result = converter.Convert(FirstOfJanuary, null, null, null);
            // Assert
            Assert.AreEqual(Colors.Red.ToString(), result.ToString());
        }

    }
}
