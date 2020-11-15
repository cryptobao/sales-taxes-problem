using System.Collections.Generic;

namespace Kata.SalesTaxesProblem
{
  public interface IApp
  {
    IEnumerable<string> Start(IEnumerable<string> inputs);
  }

  public class App : IApp
  {
    private readonly IParser parser;
    private readonly ICalculator applier;
    private readonly IBillGenerator generator;
    private readonly IBillPrinter printer;

    public App(IParser parser, ICalculator applier,
      IBillGenerator generator, IBillPrinter printer)
    {
      this.parser = parser;
      this.applier = applier;
      this.generator = generator;
      this.printer = printer;
    }

    public IEnumerable<string> Start(IEnumerable<string> inputs)
    {
      var purchases = parser.Parse(inputs);
      var taxed = applier.Calculate(purchases);
      var bill = generator.Generate(taxed);
      var result = printer.Print(bill);

      return result;
    }
  }
}