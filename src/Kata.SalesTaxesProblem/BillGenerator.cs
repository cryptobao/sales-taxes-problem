using System.Collections.Generic;
using System.Linq;
using Kata.SalesTaxesProblem.Domain;

namespace Kata.SalesTaxesProblem
{
  public interface IBillGenerator
  {
    Bill Generate(IEnumerable<PurchaseTaxed> purchases);
  }

  public class BillGenerator : IBillGenerator
  {
    public Bill Generate(IEnumerable<PurchaseTaxed> purchases)
    {
      return new Bill
      {
        TotalPrice = purchases.Sum(x => x.Price),
        TotalTax = purchases.Sum(x => x.Tax),
        Purchases = purchases
      };
    }
  }
}