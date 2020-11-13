using System.Collections.Generic;
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
      throw new System.NotImplementedException();
    }

  }
}