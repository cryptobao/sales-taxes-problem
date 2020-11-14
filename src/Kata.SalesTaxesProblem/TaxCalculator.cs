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
    private readonly List<string> TaxFreeList;

    public TaxCalculator()
    {
      TaxFreeList = new List<string>
      {
        "book",
        "box of chocolates",
        "chocolate",
        "packet of headache pills",
      };
    }

    public double Coefficient(Item item)
    {
      var basic = TaxFreeList.Contains(item.Name) ? TaxType.Free : TaxType.Basic;
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