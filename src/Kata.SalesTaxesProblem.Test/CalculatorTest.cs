using System;
using System.Linq;
using Kata.SalesTaxesProblem.Domain;
using Moq;
using NUnit.Framework;

namespace Kata.SalesTaxesProblem.Test
{
  public class CalculatorTest
  {
    Mock<ITaxCalculator> MockTaxCalculator { get; set; }
    Calculator Sut { get; set; }

    [SetUp]
    public void Setup()
    {
      MockTaxCalculator = new Mock<ITaxCalculator>(MockBehavior.Strict);
      Sut = new Calculator(MockTaxCalculator.Object);
    }

    [TestCase(1, 0, 1, 0)]
    [TestCase(5, 0.5, 7.5, 2.5)]
    [TestCase(15.29, 0.15, 17.59, 2.3)]
    public void Apply_AmountIsOneButTaxChanges(double price, double tax, double expectedPrice, double expectedTax) 
    {
      // Arrange
      MockTaxCalculator.Setup(x => x.Coefficient(It.IsNotNull<Item>())).Returns(tax);
      var input = new Purchase { Amount = 1, Price = price, Item = new Item() };

      // Act
      var actualList = Sut.Apply(new [] { input });

      // Assert
      Assert.AreEqual(1, actualList.Count());

      var actual = actualList.Single();
      AssertIs(input, expectedPrice, expectedTax, actual);
    }

    [TestCase(1, 1, 1)]
    [TestCase(10, 2, 20)]
    [TestCase(15, 3, 45)]
    public void Apply_TaxIsZeroButAmountChanges(double price, int amount, double expectedPrice)
    {
      // Arrange
      MockTaxCalculator.Setup(x => x.Coefficient(It.IsNotNull<Item>())).Returns(0);
      var input = new Purchase { Amount = amount, Price = price, Item = new Item() };

      // Act
      var actualList = Sut.Apply(new [] { input });

      // Assert
      Assert.AreEqual(1, actualList.Count());

      var actual = actualList.Single();
      AssertIs(input, expectedPrice, 0, actual);
    }

    [Test]
    public void Apply_WithMutipleElements()
    {
      // Arrange
      MockTaxCalculator.Setup(x => x.Coefficient(It.IsNotNull<Item>()))
        .Returns(1);
      
      var input = new [] 
      {
        new Purchase { Price = 5, Amount = 1, Item = new Item() },
        new Purchase { Price = 1.2, Amount = 2, Item = new Item() },
        new Purchase { Price = 2.3, Amount = 10, Item = new Item() },
      };

      // Act
      var actualList = Sut.Apply(input);

      // Assert
      Assert.AreEqual(3, actualList.Count());
      
      AssertIs(input[0], 10, 5, actualList.ElementAt(0));
      AssertIs(input[1], 4.8, 2.4, actualList.ElementAt(1));
      AssertIs(input[2], 46, 23, actualList.ElementAt(2));
    }


    private void AssertIs(Purchase expected, double expectedPrice, double expectedTax, PurchaseSummary actual)
    {
      Assert.AreEqual(expectedPrice, actual.Price, 0.001);
      Assert.AreEqual(expectedTax, actual.Tax, 0.001);
      Assert.AreEqual(actual.Amount, expected.Amount);
      Assert.AreSame(actual.Item, expected.Item);
    }


  }
}