using System.Collections.Generic;
using System.Linq;
using Kata.SalesTaxesProblem.Domain;

namespace Kata.SalesTaxesProblem
{
  public interface IParser
  {
    IEnumerable<Goods> Parse(IEnumerable<string> goodsStrings);
  }


  public class Parser : IParser
  {

    public IEnumerable<Goods> Parse(IEnumerable<string> goodsStrings)
    {
      return goodsStrings.Select(Parse);
    }

    public Goods Parse(string goodString)
    {
      var words = goodString.Split(' ');
      var amount = int.Parse(words.First());
      var price = double.Parse(words.Last());
      var isImported = words.Contains("imported");
      var name = string.Join(' ',
        words.Skip(1)
          .SkipLast(1)
          .Where(x => x != "at")
          .Where(x => x != "imported")
      );

      return new Goods
      {
        Amount = amount,
        Name = name,
        Price = price,
        IsImported = isImported
      };

    }

  }
}