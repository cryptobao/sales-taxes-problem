using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace Kata.SalesTaxesProblem.Test
{
  public class AppTest
  {

    public App Sut;
    public string DirFilesTest = Path.Combine(Environment.CurrentDirectory, "FilesTest");

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
      var freeTaxList = new List<string>
      {
        "book",
        "box of chocolates",
        "chocolate",
        "chocolate bar",
        "packet of headache pills",
      };

      Sut = App.Instance(freeTaxList);
    }


    [TestCase("example1_input","example1_output")]
    [TestCase("example2_input","example2_output")]
    [TestCase("example3_input","example3_output")]
    public void Start_UseExampleFile(string fileInput, string fileExpected)
    {
      // Arrange
      var inputs = ReadFileTest(fileInput);
      var expected = ReadFileTest(fileExpected);

      // Act
      var actual = Sut.Start(inputs);

      // Assert
      CollectionAssert.AreEqual(expected, actual);
    }


    private IEnumerable<string> ReadFileTest(string file)
      => File.ReadAllLines(Path.Combine(DirFilesTest, file));
  }
}