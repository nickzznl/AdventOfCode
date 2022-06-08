using NUnit.Framework;

namespace AdventOfCode
{
    [TestFixture]
    [Category("Unit")]
    public class TestDayOneSonarSweep
    {
        [Test]
        [TestCase ("199,200,208,210,200,207,240,269,260,263", 7)]
        public void TestDayOneSonarSweep_WithCorrectValues_ShouldGetCorrectReturnAmount(string sonarSweeps, int expectedResult)
        {
            //arrange
            var sut = new DayOneSonarSweep();

            //act
            var actualResult = sut.CountIncreasesForSonarSweep(sonarSweeps);

            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
