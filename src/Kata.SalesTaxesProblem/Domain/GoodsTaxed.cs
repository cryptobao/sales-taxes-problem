namespace Kata.SalesTaxesProblem.Domain
{
  public class GoodsTaxed
  {
    public int Amount { get; init; }
    public string Name { get; init; }
    public double Price { get; init; }
    public double Tax { get; init; }
    public bool IsImported { get; init; }
  }
}