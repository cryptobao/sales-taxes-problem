using System.Collections.Generic;
using System.Linq;
using Kata.SalesTaxesProblem.Domain;

namespace Kata.SalesTaxesProblem
{
  public interface IParser
  {
    IEnumerable<Purchase> Parse(IEnumerable<string> purchaseStrings);
  }


  public class Parser : IParser
  {

    public IEnumerable<Purchase> Parse(IEnumerable<string> purchaseStrings)
    {
      return purchaseStrings.Select(Parse);
    }

    public Purchase Parse(string purchaseString)
    {
      var words = purchaseString.Split(' ');
      var amount = int.Parse(words.First());
      var price = double.Parse(words.Last());
      var isImported = words.Contains("imported");
      var name = string.Join(' ',
        words.Skip(1)
          .SkipLast(1)
          .Where(x => x != "at")
          .Where(x => x != "imported")
      );

      return new Purchase
      {
        Amount = amount,
        Price = price,
        Item = new Item { Name = name, IsImported = isImported }
      };
    }
    
  }
}