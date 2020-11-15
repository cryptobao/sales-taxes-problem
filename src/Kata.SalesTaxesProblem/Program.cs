using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kata.SalesTaxesProblem
{
  class Program
  {
    static void Main(string[] args)
    {
      if(!ArgsAreValid(args))
      {
        PrintSummary();
        return;
      }

      var items = new List<string>();
      var freeTax = new List<string>();

      if(!TryReadFiles(args[0], ref items))
      {
        PrintFileNotValid(args[0]);
        return;
      }
      else if(args.Length == 2 && !TryReadFiles(args[1], ref freeTax))
      {
        PrintFileNotValid(args[1]);
        return;
      }

      var result = App.Instance(freeTax).Start(items);
      result.ToList().ForEach(Console.WriteLine);

    }


    static void PrintSummary()
    {
      Console.WriteLine("You need to provide these arguments:");
      Console.WriteLine("1. File path of what was purchased");
      Console.WriteLine("2. (OPTIONAL) List of goods exempt from sales tax");
    }

    static void PrintFileNotValid(string path)
    {
      var oldColor = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine($"File not found {path}");
      Console.ForegroundColor = oldColor;
    }

    static bool TryReadFiles(string path, ref List<string> output)
    {
      if(!File.Exists(path))
        return false;

      output.AddRange(File.ReadAllLines(path));
      return true;
    }

    static bool ArgsAreValid(string[] args)
    {
      return args.Length != 0 && args.Length <= 2;
    }
  }
}
