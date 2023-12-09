using CSharpStarterPack.Days_2023;
using CSharpStarterPack.PuzzleInputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests_2023
{
    [TestClass]
    public class Day01Tests
    {
        private readonly int day = 3;
        [TestMethod]
        public void Puzzle_A()
        {
            // Arrenge
            string expected = "";

            // Act
            var actual = Day01.PuzzleA();

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
