using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsMvp;

namespace WinFormsMvp.UnitTests
{
    /// <summary>
    /// This is a copy of the relevant TypeListComparerTests from the original WebFormsMVP project (thanks guys!)
    /// </summary>
    [TestClass]
    public class TypeListComparerTests
    {
        [TestMethod]
        public void TypeListComparer_Equals_ShouldReturnTrueForTwoEmptyLists()
        {
            // Arrange
            var x = new object[0];
            var y = new object[0];

            // Act
            var actual = new TypeListComparer<object>().Equals(x, y);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TypeListComparer_Equals_ShouldThrowExceptionWhenFirstArgumentIsNull()
        {
            // Arrange
            var x = null as object[];
            var y = new object[0];

            // Act
            var actual = new TypeListComparer<object>().Equals(x, y);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TypeListComparer_Equals_ShouldThrowExceptionWhenSecondArgumentIsNull()
        {
            // Arrange
            var x = new object[0];
            var y = null as object[];

            // Act
            var actual = new TypeListComparer<object>().Equals(x, y);

            // Assert
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TypeListComparer_GetHashCode_ShouldThrowExceptionWhenArgumentIsNull()
        {
            // Arrange
            var obj = null as object[];

            // Act
            var actual = new TypeListComparer<object>().GetHashCode(obj);

            // Assert
        }

        [TestMethod]
        public void TypeListComparer_GetHashCode_ShouldReturnZeroForEmptyList()
        {
            // Arrange
            var obj = new object[] { };

            // Act
            var actual = new TypeListComparer<object>().GetHashCode(obj);

            // Assert
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TypeListComparer_GetHashCode_ShouldReturnValueOfItemInSingleItemList()
        {
            // Arrange
            var obj = new object[] { 5 };

            // Act
            var actual = new TypeListComparer<object>().GetHashCode(obj);

            // Assert
            var expected = 5;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TypeListComparer_GetHashCode_ShouldReturnAggregateOrOfListItems()
        {
            // Arrange
            var obj = new object[] { 1, 2, 3 };

            // Act
            var actual = new TypeListComparer<object>().GetHashCode(obj);

            // Assert
            var expected = 1 | 2 | 3;
            Assert.AreEqual(expected, actual);
        }
    }
}
