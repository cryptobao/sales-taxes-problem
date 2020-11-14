using System.Collections.Generic;

namespace Kata.SalesTaxesProblem
{
  public interface IApp
  {
    IEnumerable<string> Start(IEnumerable<string> inputs);
  }

  public class App : IApp
  {
    private readonly IParser Parser;
    private readonly ICalculator Applier;
    private readonly IBillGenerator Generator;
    private readonly IBillPrinter Printer;

    public App(IParser parser, ICalculator applier,
      IBillGenerator generator, IBillPrinter printer)
    {
      this.Parser = parser;
      this.Applier = applier;
      this.Generator = generator;
      this.Printer = printer;
    }

    public IEnumerable<string> Start(IEnumerable<string> inputs)
    {
      var purchases = Parser.Parse(inputs);
      var taxed = Applier.Apply(purchases);
      var bill = Generator.Generate(taxed);
      var result = Printer.Print(bill);

      return result;
    }
  }
}