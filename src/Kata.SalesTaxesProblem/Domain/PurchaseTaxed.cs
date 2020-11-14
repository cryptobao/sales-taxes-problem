namespace Kata.SalesTaxesProblem.Domain
{
  public class PurchaseTaxed
  {
    public int Amount { get; init; }
    public Item Item { get; init; }
    public double Price { get; init; }
    public double Tax { get; init; }
  }
}