namespace Kata.SalesTaxesProblem.Domain
{
  public class Purchase
  {
    public int Amount { get; init; }
    public double Price { get; init; }
    public Item Item { get; init; }
  }
}