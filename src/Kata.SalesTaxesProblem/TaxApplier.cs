using System;
using System.Collections.Generic;
using System.Linq;
using Kata.SalesTaxesProblem.Domain;

namespace Kata.SalesTaxesProblem
{
  public interface ITaxApplier
  {
    IEnumerable<GoodsTaxed> Apply (IEnumerable<Goods> goods);
  }

  public class TaxApplier : ITaxApplier
  {
    private readonly ITaxCalculator Calculator;

    public TaxApplier(ITaxCalculator calculator)
    {
      this.Calculator = calculator;
    }

    public IEnumerable<GoodsTaxed> Apply (IEnumerable<Goods> goods)
    {
      return goods.Select(goods => 
        ToGoodsTaxed(goods, Calculator.Coefficient(goods.Name, goods.IsImported)));
    }


    private GoodsTaxed ToGoodsTaxed(Goods goods, double kTax)
    {
      var tax = goods.Price * kTax;
      return new GoodsTaxed
      {
        Amount = goods.Amount,
        Name = goods.Name,
        IsImported = goods.IsImported,
        Price = goods.Price + tax,
        Tax = tax
      };
    }

  }
}