using NUnit.Framework;

namespace Kata.SalesTaxesProblem.Test
{
  public class TaxCalculatorTest
  {

    TaxCalculator Sut;

    [SetUp]
    public void Setup()
    {
      Sut = new TaxCalculator();
    }


    [TestCase("book", 0)]
    [TestCase("box of chocolates", 0)]
    [TestCase("chocolate", 0)]
    [TestCase("packet of headache pills", 0)]
    [TestCase("bottle of perfume", 0.1)]
    [TestCase("music CD", 0.1)]
    public void Calculate_ItemsNotImported(string goods, double expectedCoefficient)
    {
      // Arrange
      // Act
      var actual = Sut.Coefficient(goods, false);
      // Assert
      Assert.AreEqual(expectedCoefficient, actual, 0.001);
    }

    [TestCase("book", 0.05)]
    [TestCase("box of chocolates", 0.05)]
    [TestCase("chocolate", 0.05)]
    [TestCase("packet of headache pills", 0.05)]
    [TestCase("bottle of perfume", 0.15)]
    [TestCase("music CD", 0.15)]
    public void Calculate_ItemsImported(string goods, double expectedCoefficient)
    {
      // Arrange
      // Act
      var actual = Sut.Coefficient(goods, true);
      // Assert
      Assert.AreEqual(expectedCoefficient, actual, 0.001);
    }
  }
}