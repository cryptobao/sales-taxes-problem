using System.Collections.Generic;
using Kata.SalesTaxesProblem.Domain;
using NUnit.Framework;

namespace Kata.SalesTaxesProblem.Test
{
  public class TaxCalculatorTest
  {

    TaxCalculator Sut;
    List<string> taxFreelist;

    [SetUp]
    public void Setup()
    {
      taxFreelist = new List<string>
      {
        "book",
        "box of chocolates",
        "chocolate",
        "packet of headache pills"
      };
      Sut = new TaxCalculator(taxFreelist);
    }

    [TestCase("book", 0)]
    [TestCase("box of chocolates", 0)]
    [TestCase("chocolate", 0)]
    [TestCase("packet of headache pills", 0)]
    [TestCase("bottle of perfume", 0.1)]
    [TestCase("music CD", 0.1)]
    public void Coefficient_ItemsNotImported(string name, double expectedCoefficient)
    {
      // Arrange
      // Act
      var actual = Sut.Coefficient(new Item { Name = name, IsImported = false });
      // Assert
      AssertHelp.AreEqual(expectedCoefficient, actual);
    }

    [TestCase("book", 0.05)]
    [TestCase("box of chocolates", 0.05)]
    [TestCase("chocolate", 0.05)]
    [TestCase("packet of headache pills", 0.05)]
    [TestCase("bottle of perfume", 0.15)]
    [TestCase("music CD", 0.15)]
    public void Coefficient_ItemsImported(string name, double expectedCoefficient)
    {
      // Arrange
      // Act
      var actual = Sut.Coefficient(new Item { Name = name, IsImported = true });
      // Assert
      AssertHelp.AreEqual(expectedCoefficient, actual);
    }
  }
}