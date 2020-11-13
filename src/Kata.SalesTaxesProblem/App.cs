using System.Collections.Generic;

namespace Kata.SalesTaxesProblem
{
  public interface IApp
  {
    IEnumerable<string> Start(IEnumerable<string> inputs);
  }

  public class App : IApp
  {
    public IEnumerable<string> Start(IEnumerable<string> inputs)
    {
      throw new System.NotImplementedException();
    }
  }
}