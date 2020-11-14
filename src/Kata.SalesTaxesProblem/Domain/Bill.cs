using System.Collections.Generic;

namespace Kata.SalesTaxesProblem.Domain
{
  public class Bill
  {
    public IEnumerable<PurchaseSummary> Purchases { get; init; }
    public double TotalPrice { get; init; }
    public double TotalTax { get; init; }
  }
}