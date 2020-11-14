using System.Linq;
using Kata.SalesTaxesProblem.Domain;
using NUnit.Framework;

namespace Kata.SalesTaxesProblem.Test
{
  public class BillGeneratorTest
  {
    private BillGenerator Sut;

    [SetUp]
    public void Setup()
    {
      this.Sut = new BillGenerator();
    }
    public void Generate_SingleElement()
    {
      // Arrange
      var price = 5;
      var tax = 6;
      var input = new PurchaseSummary { Price = price, Tax = tax };

      // Act
      var actual = Sut.Generate(new [] { input });
      
      // Assert
      Assert.AreEqual(1, actual.Purchases.Count());

      Assert.AreEqual(price, actual.TotalPrice);
      Assert.AreEqual(tax, actual.TotalTax);
    }

    [Test]
    public void Generate_MultipleElements()
    {
      // Arrange
      var input = new []
      {
        new PurchaseSummary { Price = 1, Tax = 4 },
        new PurchaseSummary { Price = 2, Tax = 5 },
        new PurchaseSummary { Price = 3, Tax = 6 },
      };

      // Act
      var actual = Sut.Generate(input);
      
      // Assert
      Assert.AreEqual(3, actual.Purchases.Count());

      Assert.AreEqual(6, actual.TotalPrice);
      Assert.AreEqual(15, actual.TotalTax);
    }
  }
}