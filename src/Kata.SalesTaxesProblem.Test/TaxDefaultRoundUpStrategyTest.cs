using NUnit.Framework;

namespace Kata.SalesTaxesProblem.Test
{
  public class TaxDefaultRoundUpStrategyTest
  {
    [TestCase(0.01d, 0.05d)]
    [TestCase(0.02d, 0.05d)]
    [TestCase(0.03d, 0.05d)]
    [TestCase(0.04d, 0.05d)]
    [TestCase(0.05d, 0.05d)]
    [TestCase(0.06d, 0.1d)]
    [TestCase(0.07d, 0.1d)]
    [TestCase(0.08d, 0.1d)]
    [TestCase(0.09d, 0.1d)]
    [TestCase(0.16d, 0.2d)]
    public void RoundUp(double input, double expected)
    {
      // Arrange
      var sut = new TaxDefaultRoundUpStrategy();
      // Act
      var actual = sut.RoundUp(input);
      // Arrange
      Assert.AreEqual(expected, actual, 0.001d);
    }
  }
}