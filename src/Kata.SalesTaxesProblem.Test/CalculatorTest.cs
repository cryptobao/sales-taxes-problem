using System;
using System.Linq;
using Kata.SalesTaxesProblem.Domain;
using Moq;
using NUnit.Framework;

namespace Kata.SalesTaxesProblem.Test
{
  public class CalculatorTest
  {
    Mock<ITaxCalculator> mockTaxCalculator { get; set; }
    Mock<ITaxRoundUpStrategy> mockRoundUpStrategy { get; set; }
    Calculator Sut { get; set; }

    [SetUp]
    public void Setup()
    {
      mockTaxCalculator = new Mock<ITaxCalculator>(MockBehavior.Strict);
      mockRoundUpStrategy = new Mock<ITaxRoundUpStrategy>(MockBehavior.Strict);
      Sut = new Calculator(mockTaxCalculator.Object, mockRoundUpStrategy.Object);
    }

    [TestCase(10, 90, 60)]
    [TestCase(12.3, 110.7, 73.8)]
    [TestCase(7.42, 66.78, 44.52)]
    public void Apply_WithFixedAmountAndFixedTaxCoefficient(double price, double expectedPrice, double expectedTax)
    {
      // Arrange
      mockTaxCalculator.Setup(x => x.Coefficient(It.IsNotNull<Item>())).Returns(0.5);
      mockRoundUpStrategy.Setup(x => x.RoundUp(It.IsAny<double>())).Returns<double>(x => x * 4);
      var input = new Purchase { Amount = 3, Price = price, Item = new Item() };

      // Act
      var actualList = Sut.Calculate(new [] { input });

      // Assert
      Assert.AreEqual(1, actualList.Count());

      var actual = actualList.Single();
      AssertIs(input, expectedPrice, expectedTax, actual);
    }

    [Test]
    public void Apply_WithMutipleElements()
    {
      // Arrange
      mockTaxCalculator.Setup(x => x.Coefficient(It.IsNotNull<Item>())).Returns(1);
      mockRoundUpStrategy.Setup(x => x.RoundUp(It.IsAny<double>())).Returns<double>(x => x);
      
      var input = new [] 
      {
        new Purchase { Price = 5, Amount = 1, Item = new Item() },
        new Purchase { Price = 1.2, Amount = 2, Item = new Item() },
        new Purchase { Price = 2.3, Amount = 10, Item = new Item() },
      };

      // Act
      var actualList = Sut.Calculate(input);

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