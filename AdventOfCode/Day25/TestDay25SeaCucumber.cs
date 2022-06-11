using NUnit.Framework;

namespace AdventOfCode.Day25
{
    [TestFixture]
    [Category("unit")]
    public class TestDay25SeaCucumber
    {
        [Test]
        [TestCase(@"..\..\..\Day25\ExampleForTest.txt", 58)]
        public void ShouldReturnCorrectValueIfMovementIsWithinLimits(string fileLocation, int expectedResult)
        {
            //Arrange
            var sut = new Day25SeaCucumber();

            //Act
            var actualResult = sut.GetStepsUntilNoMoreMovesCanBeMade(fileLocation);

            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
