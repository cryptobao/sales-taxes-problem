using System;

namespace Kata.SalesTaxesProblem
{

  public interface ITaxRoundUpStrategy
  {
    double RoundUp(double d);
  }

  public class TaxDefaultRoundUpStrategy : ITaxRoundUpStrategy
  {
    public double RoundUp(double d)
    {
      return Math.Ceiling(d * 20) / 20;
    }
  }
}