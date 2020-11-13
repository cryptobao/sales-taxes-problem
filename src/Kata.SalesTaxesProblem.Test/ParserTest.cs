using System.Linq;
using Kata.SalesTaxesProblem.Domain;
using NUnit.Framework;

namespace Kata.SalesTaxesProblem.Test
{
  public class ParserTest
  {
    Parser Sut { get; set; }

    [SetUp]
    public void Setup()
    {
      Sut = new Parser();
    }

    [TestCase("2 book at 12.49", 2, "book", 12.49, false)]
    [TestCase("100 papers at 5.99", 100, "papers", 5.99, false)]
    [TestCase("0 chocolate at 0.00", 0, "zero", 0, false)]
    [TestCase("3 box of imported chocolates at 11.25", 3, "box of imported chocolates", 11.25, true)]
    [TestCase("1 imported bottle of perfume at 27.99", 1, "imported bottle of perfume", 27.99, true)]
    public void Parse_SingleGoods(string input, int expectedAmout, string expectedName, double expectedPrice, bool expectedIsImported)
    {
      // Arrange
      // Act
      var actualList = Sut.Parse(new[] { input });

      // Assert
      Assert.AreEqual(1, actualList.Count());
      AssertGoods(actualList.Single(), expectedAmout, expectedName, expectedPrice, expectedIsImported);
    }

    [Test]
    public void Parse_MultipleGoods()
    {
      // Arrange
      var inputs = new []
      {
        "1 soup 13.75",
        "8 imported banana 2.82",
        "4 box of monkeys 1000.05"
      };
      
      // Act
      var actualList = Sut.Parse(inputs);

      // Assert
      Assert.AreEqual(3, actualList.Count());

      AssertGoods(actualList.ElementAt(0), 1, "soup", 13.75, false);
      AssertGoods(actualList.ElementAt(1), 8, "imported bana", 2.82, true);
      AssertGoods(actualList.ElementAt(2), 4, "box of monkeys", 1000.05, false);
    }


    private void AssertGoods(Goods actual, int expectedAmout, string expectedName, double expectedPrice, bool expectedIsImported)
    {
      Assert.AreEqual(expectedAmout, actual.Amout);
      Assert.AreEqual(expectedName, actual.Name);
      Assert.AreEqual(expectedPrice, actual.Price);
      Assert.AreEqual(expectedIsImported, actual.IsImported);
    }

  }
}