using FluentAssertions;
using NUnit.Framework;

namespace LinkedList.UnitTests
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void Add_Always_AddsNewElement()
        {
            //Arrange
            LinkedList list = new LinkedList();

            //Act
            list.Add(1);

            //Assert
            list.Contains(1).Should().BeTrue();
        }

        [Test]
        public void Remove_Always_RemovesElement()
        {
            //Arrange
            LinkedList list = new LinkedList();
            list.Add(1);
            list.Add(2);
            list.Add(1);

            //Act
            list.Remove(1);

            //Assert
            list.Contains(1).Should().BeFalse();
        }

        [TestCase(1, ExpectedResult = true)]
        [TestCase(2, ExpectedResult = false)]
        public bool Contains_Always_ReturnsExpectedResult(int listItem)
        {
            //Arrange
            LinkedList list = new LinkedList();

            list.Add(1);
            //Act
            var result = list.Contains(listItem);

            //Assert
            list.Count.Should().Be(1);
            return result;
        }

        [Test]
        public void GetByIndex_Always_ReturnsByIndex()
        {
            //Arrange
            LinkedList list = new LinkedList();
            list.Add(32);
            list.Add(228);
            list.Add(5);

            //Act
            int result = list.GetByIndex(1);

            //Assert
            result.Should().Be(228);
        }
    }
}
