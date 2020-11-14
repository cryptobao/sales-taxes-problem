using System.Linq;
using Kata.SalesTaxesProblem.Domain;
using NUnit.Framework;

namespace Kata.SalesTaxesProblem.Test
{
  public class BillPrinterTest
  {
    private BillPrinter Sut;

    [SetUp]
    public void Setup()
    {
      this.Sut = new BillPrinter();
    }

    [Test]   
    public void Print()
    {
      // Arrange
      var input = new Bill
      {
        TotalPrice = 5.936,
        TotalTax = 8.749,
        Purchases = new [] 
        {
          new PurchaseTaxed { Amount = 5, Price = 0.222, Item = new Item { Name = "item n°1" } },
          new PurchaseTaxed { Amount = 7, Price = 888.115, Item = new Item { Name = "item n°2", IsImported = true } },
          new PurchaseTaxed { Amount = 1, Price = 12345689.995, Item = new Item { Name = "item n°3" } }
        }
      };

      // Act
      var actual = Sut.Print(input);

      // Assert
      Assert.AreEqual(5, actual.Count());

      Assert.AreEqual("5 item n°1: 0.22", actual.ElementAt(0));
      Assert.AreEqual("7 imported item n°2: 888.12", actual.ElementAt(1));
      Assert.AreEqual("1 item n°3: 12345690.00", actual.ElementAt(2));
      Assert.AreEqual("Sales Taxes: 8.75", actual.ElementAt(3));
      Assert.AreEqual("Total: 5.94", actual.ElementAt(4));

    }
  }
}