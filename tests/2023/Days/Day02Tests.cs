using CSharpStarterPack.Days_2023;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests_2023
{
    // Uncomment to enable testing for this file
    // [TestClass]
    public class Day02Tests
    {
        private readonly int day = 2;
        private readonly int year = 2022;

        [TestMethod]
        public void Puzzle_A()
        {
            // Arrenge
            string expected = "";

            // Act
            var actual = Day02.PuzzleA();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Puzzle_B()
        {
            // Arrenge
            // Act
            // Assert
            Assert.AreEqual(1, 1);
        }
    }
}
