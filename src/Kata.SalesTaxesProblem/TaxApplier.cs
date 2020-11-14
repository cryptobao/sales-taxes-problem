using System;
using System.Collections.Generic;
using System.Linq;
using Kata.SalesTaxesProblem.Domain;

namespace Kata.SalesTaxesProblem
{
  public interface ITaxApplier
  {
    IEnumerable<PurchaseTaxed> Apply (IEnumerable<Purchase> purchases);
  }

  public class TaxApplier : ITaxApplier
  {
    private readonly ITaxCalculator Calculator;

    public TaxApplier(ITaxCalculator calculator)
    {
      this.Calculator = calculator;
    }

    public IEnumerable<PurchaseTaxed> Apply (IEnumerable<Purchase> purchases)
    {
      return purchases.Select(purchase => 
        ToPurchaseTaxed(purchase, Calculator.Coefficient(purchase.Item)));
    }

    private PurchaseTaxed ToPurchaseTaxed(Purchase purchase, double kTax)
    {
      var tax = purchase.Price * kTax;
      return new PurchaseTaxed
      {
        Amount = purchase.Amount,
        Item = purchase.Item,
        Price = purchase.Price + tax,
        Tax = tax
      };
    }

  }
}