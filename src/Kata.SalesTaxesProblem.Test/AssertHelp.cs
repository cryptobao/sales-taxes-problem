using NUnit.Framework;

namespace Kata.SalesTaxesProblem.Test
{
  public static class AssertHelp
  {
    ///<summary>
    /// Compara di 'double'. Sono uguali se la loro differenza è <= 0.001
    ///</summary>
    public static void AreEqual(double expected, double actual)
    {
      Assert.AreEqual(expected, actual, 0.001);
    }
  }
}