using System.Collections.Generic;
using System.Linq;
using Kata.SalesTaxesProblem.Domain;

namespace Kata.SalesTaxesProblem
{

  public interface IBillPrinter
  {
    IEnumerable<string> Print(Bill bill);
  }

  public class BillPrinter : IBillPrinter
  {
    public IEnumerable<string> Print(Bill bill)
    {
      return bill.Purchases
        .Select(ToString)
        .Append($"Sales Taxes: {Round(bill.TotalTax)}")
        .Append($"Total: {Round(bill.TotalPrice)}")
      ;
    }

    private string ToString(PurchaseSummary purchase)
    {
      var item = purchase.Item;
      var name = item.IsImported ? $"imported {item.Name}" : item.Name;
      return $"{purchase.Amount} {name}: {Round(purchase.Price)}";
    }

    private string Round(double d) => string.Format("{0:0.00}", d).Replace(',','.');
    
  }
}