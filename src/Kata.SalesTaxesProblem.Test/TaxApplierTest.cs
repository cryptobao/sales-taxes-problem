using System.Linq;
using Kata.SalesTaxesProblem.Domain;
using Moq;
using NUnit.Framework;

namespace Kata.SalesTaxesProblem.Test
{
  public class TaxApplierTest
  {
    Mock<ITaxCalculator> MockTaxCalculator { get; set; }
    TaxApplier Sut { get; set; }

    [SetUp]
    public void Setup()
    {
      MockTaxCalculator = new Mock<ITaxCalculator>(MockBehavior.Strict);
      Sut = new TaxApplier(MockTaxCalculator.Object);
    }

    [TestCase(1, 0, 1, 0)]
    [TestCase(5, 0.5, 7.5, 2.5)]
    [TestCase(15.29, 0.15, 17.583, 2.293)]
    public void Apply_SingleGoods(double price, double tax, double expectedPrice, double expectedTax) 
    {
      // Arrange
      MockTaxCalculator.Setup(x => x.Coefficient(It.IsNotNull<string>(), It.IsAny<bool>()))
        .Returns(tax);

      var input = new Goods
      {
        Amount = 5,
        Name = "some name",
        Price = price
      };

      // Act
      var actualList = Sut.Apply(new [] { input });

      // Assert
      Assert.AreEqual(1, actualList.Count());

      var actual = actualList.Single();
      AssertIs(input, expectedPrice, expectedTax, actual);
    }

    [Test]
    public void Apply_MutipleGoods()
    {
      // Arrange
      MockTaxCalculator.Setup(x => x.Coefficient(It.IsNotNull<string>(), It.IsAny<bool>()))
        .Returns(1);
      
      var input = new [] 
      {
        new Goods { Name = "name1", Price = 5 },
        new Goods { Name = "name2", Price = 1.2 },
        new Goods { Name = "name3", Price = 2.3 },
      };

      // Act
      var actualList = Sut.Apply(input);

      // Assert
      Assert.AreEqual(3, actualList.Count());
      
      AssertIs(input[0], 10, 5, actualList.ElementAt(0));
      AssertIs(input[1], 2.4, 1.2, actualList.ElementAt(1));
      AssertIs(input[2], 4.6, 2.3, actualList.ElementAt(2));
    }


    private void AssertIs(Goods expected, double expectedPrice, double expectedTax, GoodsTaxed actual)
    {
      Assert.AreEqual(expected.Amount, actual.Amount);
      Assert.AreEqual(expected.IsImported, actual.IsImported);
      Assert.AreEqual(expected.Name, actual.Name);
      Assert.AreEqual(expectedPrice, actual.Price, 0.001);
      Assert.AreEqual(expectedTax, actual.Tax, 0.001);
    }
  }
}