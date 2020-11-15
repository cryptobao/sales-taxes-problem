using System;
using System.Collections.Generic;
using System.Linq;
using Kata.SalesTaxesProblem.Domain;

namespace Kata.SalesTaxesProblem
{
  public interface ICalculator
  {
    IEnumerable<PurchaseSummary> Calculate (IEnumerable<Purchase> purchases);
  }

  public class Calculator : ICalculator
  {
    private readonly ITaxCalculator TaxCalculator;

    public Calculator(ITaxCalculator taxCalculator)
    {
      this.TaxCalculator = taxCalculator;
    }

    public IEnumerable<PurchaseSummary> Calculate (IEnumerable<Purchase> purchases)
    {
      return purchases.Select(purchase => 
        ToPurchaseTaxed(purchase, TaxCalculator.Coefficient(purchase.Item)));
    }

    private PurchaseSummary ToPurchaseTaxed(Purchase purchase, double kTax)
    {
      var price = purchase.Amount * purchase.Price;
      var tax = purchase.Amount * Math.Ceiling(purchase.Price * kTax * 20) / 20;
      return new PurchaseSummary
      {
        Amount = purchase.Amount,
        Item = purchase.Item,
        Price = price + tax,
        Tax = tax
      };
    }

  }
}