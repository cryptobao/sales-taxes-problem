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
    private readonly ITaxCalculator taxCalculator;
    private readonly ITaxRoundUpStrategy roundUpStrategy;

    public Calculator(ITaxCalculator taxCalculator, ITaxRoundUpStrategy roundUpStrategy)
    {
      this.taxCalculator = taxCalculator;
      this.roundUpStrategy = roundUpStrategy;
    }

    public IEnumerable<PurchaseSummary> Calculate (IEnumerable<Purchase> purchases)
    {
      return purchases.Select(purchase => 
        ToPurchaseTaxed(purchase, taxCalculator.Coefficient(purchase.Item)));
    }

    private PurchaseSummary ToPurchaseTaxed(Purchase purchase, double kTax)
    {
      var price = purchase.Amount * purchase.Price;
      var tax = purchase.Amount * roundUpStrategy.RoundUp(purchase.Price * kTax);
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