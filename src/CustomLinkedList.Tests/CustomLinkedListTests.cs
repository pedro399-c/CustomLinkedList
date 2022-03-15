using CustomLinkedList.Tests.Collections;
using Xunit;
using System.Linq;
using System;

namespace CustomLinkedList.Tests
{
    /// <summary>
    /// Tests for CutomLinkedList.
    /// </summary>
    public class CustomLinkedListTests
    {
        /// <summary>
        /// CustomLinkedList test AddFirst method in empty list.
        /// </summary>
        [Fact]
        public void CustomLinkedList_AddFirst_EmptyLinkedList_ReturnsInsertedNode()
        {
            // Arrange
            CustomLinkedList<int> list = new CustomLinkedList<int>();

            // Act
            var nodeToValidate = list.AddFirst(1);

            // Assert
            Assert.NotNull(nodeToValidate);
            Assert.Null(nodeToValidate.Previous);
            Assert.Null(nodeToValidate.Next);
            Assert.Equal(1, nodeToValidate.NodeValue);
            Assert.Equal(1, list.Count);
        }

        /// <summary>
        /// CustomLinkedList test AddFirst method in already populated list.
        /// </summary>
        [Fact]
        public void CustomLinkedList_AddFirst_AlreadyPopulatedLinkedList_ReturnsInsertedNode()
        {
            // Arrange
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddFirst(1);
            var numberFiveNode = list.AddFirst(5);

            // Act
            var nodeToValidate = list.AddFirst(9);

            // Assert
            Assert.NotNull(nodeToValidate);
            Assert.Null(nodeToValidate.Previous);
            Assert.Equal(numberFiveNode, nodeToValidate.Next);
            Assert.Equal(3, list.Count);
        }

        /// <summary>
        /// CustomLinkedList test Remove method in empty list.
        /// </summary>
        [Fact]
        public void CustomLinkedList_Remove_EmptyLinkedList_ReturnsFalse()
        {
            // Arrange
            CustomLinkedList<int> list = new CustomLinkedList<int>();

            // Act
            var result = list.Remove(8);

            // Assert
            Assert.False(result);
            Assert.Equal(0, list.Count);
        }

        /// <summary>
        /// CustomLinkedList test Remove non-existing value.
        /// </summary>
        [Fact]
        public void CustomLinkedList_Remove_NonExistingValue_ReturnsFalse()
        {
            // Arrange
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            // Act
            var result = list.Remove(8);

            // Assert
            Assert.False(result);
            Assert.Equal(3, list.Count);
        }

        /// <summary>
        /// CustomLinkedList test Remove first element in already populated list.
        /// </summary>
        [Fact]
        public void CustomLinkedList_RemoveFirstElement_AlreadyPopulatedLinkedList_ReturnsTrue()
        {
            // Arrange
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            // Act
            var result = list.Remove(3);

            // Assert
            Assert.True(result);
            Assert.Equal(2, list.Count);
            Assert.Equal(2, list.ElementAt(0));
        }

        /// <summary>
        /// CustomLinkedList test Remove middle element in already populated list.
        /// </summary>
        [Fact]
        public void CustomLinkedList_RemoveMiddleElement_AlreadyPopulatedLinkedList_ReturnsTrue()
        {
            // Arrange
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            // Act
            var result = list.Remove(2);

            // Assert
            Assert.True(result);
            Assert.Equal(2, list.Count);
            Assert.Equal(3, list.ElementAt(0));
            Assert.Equal(1, list.ElementAt(1));
        }

        /// <summary>
        /// CustomLinkedList test AddAfter method with non-existing value in already populated list.
        /// </summary>
        [Fact]
        public void CustomLinkedList_AddAfter_NonExistingNode_ThrowsExeception()
        {
            // Arrange
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            // Act
            // Assert
            Assert.Throws<Exception>(() => list.AddAfter(new CustomLinkedListNode<int>(10), 8));
        }

        /// <summary>
        /// CustomLinkedList test AddAfter method in already populated list.
        /// </summary>
        [Fact]
        public void CustomLinkedList_AddAfter_AlreadyExistingNode_ReturnsInsertedNode()
        {
            // Arrange
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddFirst(1);
            var nodeToInsertAfter = list.AddFirst(2);
            list.AddFirst(3);

            // Act
            var result = list.AddAfter(nodeToInsertAfter, 8);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, list.Count);
            Assert.Equal(8, list.ElementAt(2));
            Assert.Equal(2, list.ElementAt(1));
        }

        /// <summary>
        /// CustomLinkedList test AddLast method in empty list.
        /// </summary>
        [Fact]
        public void CustomLinkedList_AddLast_EmptyLinkedList_ReturnsInsertedNode()
        {
            // Arrange
            CustomLinkedList<int> list = new CustomLinkedList<int>();

            // Act
            var result = list.AddLast(8);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, list.Count);
            Assert.Equal(8, list.ElementAt(0));
        }

        /// <summary>
        /// CustomLinkedList test AddLast method in already populated list.
        /// </summary>
        [Fact]
        public void CustomLinkedList_AddLast_AlreadyPopulatedLinkedList_ReturnsInsertedNode()
        {
            // Arrange
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            // Act
            var result = list.AddLast(8);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, list.Count);
            Assert.Equal(8, list.ElementAt(3));
            Assert.Equal(1, list.ElementAt(2));
        }

        /// <summary>
        /// CustomLinkedList test Find method with value in empty list.
        /// </summary>
        [Fact]
        public void CustomLinkedList_Find_Value_EmptyLinkedList_ThrowsException()
        {
            // Arrange
            CustomLinkedList<int> list = new CustomLinkedList<int>();

            // Act
            // Assert
            Assert.Throws<Exception>(() => list.Find(8));
        }

        /// <summary>
        /// CustomLinkedList test Find method with value in already populated list.
        /// </summary>
        [Fact]
        public void CustomLinkedList_Find_Value_AlreadyPopulatedLinkedList_ThrowsException()
        {
            // Arrange
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddFirst(1);
            // Act
            // Assert
            Assert.Throws<Exception>(() => list.Find(8));
        }

        /// <summary>
        /// CustomLinkedList test Find method with value in already populated list.
        /// </summary>
        [Fact]
        public void CustomLinkedList_Find_Value_AlreadyPopulatedLinkedList_ReturnsNode()
        {
            // Arrange
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            var firstElement = list.AddFirst(1);
            var secondElement = list.AddFirst(2);
            var thirdElement = list.AddFirst(3);

            // Act
            var result = list.Find(2);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(secondElement, result);
            Assert.Equal(thirdElement, result.Previous);
            Assert.Equal(firstElement, result.Next);
        }

        [Fact]
        public void CustomLinkedList_Find_DuplicatedValue_AlreadyPopulatedLinkedList_ReturnsFirstNode()
        {
            // Arrange
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddFirst(1);
            var secondElement = list.AddFirst(2);
            var thirdElement = list.AddFirst(3);
            list.AddLast(3);

            // Act
            var result = list.Find(3);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(thirdElement, result);
            Assert.Null(result.Previous);
            Assert.Equal(secondElement, result.Next);
        }

        /// <summary>
        /// CustomLinkedList test Find method with node in already populated list.
        /// </summary>
        [Fact]
        public void CustomLinkedList_Find_Node_EmptyLinkedList_ThrowsException()
        {
            // Arrange
            CustomLinkedList<int> list = new CustomLinkedList<int>();

            // Act
            // Assert
            Assert.Throws<Exception>(() => list.Find(new CustomLinkedListNode<int>(1)));
        }

        /// <summary>
        /// CustomLinkedList test Find method with node in already populated list.
        /// </summary>
        [Fact]
        public void CustomLinkedList_Find_Node_AlreadyPopulatedLinkedList_ThrowsException()
        {
            // Arrange
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            // Act
            // Assert
            Assert.Throws<Exception>(() => list.Find(new CustomLinkedListNode<int>(2)));
        }

        /// <summary>
        /// CustomLinkedList test Find method with node in already populated list.
        /// </summary>
        [Fact]
        public void CustomLinkedList_Find_Node_AlreadyPopulatedLinkedList_ReturnsNode()
        {
            // Arrange
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddFirst(1);
            var second = list.AddFirst(2);
            list.AddFirst(3);

            // Act
            var result = list.Find(second);

            // Assert
            Assert.NotNull(result);
        }
    }
}