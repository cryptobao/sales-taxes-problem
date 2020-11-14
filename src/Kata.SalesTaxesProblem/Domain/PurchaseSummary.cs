namespace Kata.SalesTaxesProblem.Domain
{
  public class PurchaseSummary
  {
    public int Amount { get; init; }
    public Item Item { get; init; }
    public double Price { get; init; }
    public double Tax { get; init; }
  }
}