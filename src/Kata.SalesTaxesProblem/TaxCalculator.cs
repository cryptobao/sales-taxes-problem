using System;
using System.Collections.Generic;
using Kata.SalesTaxesProblem.Domain;

namespace Kata.SalesTaxesProblem
{
  public interface ITaxCalculator
  {
    double Coefficient(Item item);
  }
  
  public class TaxCalculator : ITaxCalculator
  {
    private readonly IList<string> taxFreeList;

    public TaxCalculator(IList<string> taxFreelist)
    {
      this.taxFreeList = taxFreelist;
    }

    public double Coefficient(Item item)
    {
      var basic = taxFreeList.Contains(item.Name) ? TaxType.Free : TaxType.Basic;
      var imported = item.IsImported ? TaxType.Import : TaxType.Free;

      return basic + imported;
    }


    private static class TaxType
    {
      public static double Import = 0.05;
      public static double Basic = 0.1;
      public static double Free = 0;
    }
  }

}