using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SyntaxSolutions.CsvBuilder;


namespace csvbuilder_net_tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestBasicHeadersAndRows()
        {
            var builder = new CsvBuilder();

            var headers = new CsvRow();
            headers.AddCell("Header 1");
            headers.AddCell("Header 2");
            headers.AddCell("Header 3");
            builder.AddHeaders(headers);

            var row = new CsvRow();
            row.AddCell("Cell 1");
            row.AddCell("Cell 2");
            row.AddCell("Cell 3");
            builder.AddRow(row);

            byte[] actualBytes = builder.GetBytes();
            byte[] expectedBytes = System.IO.File.ReadAllBytes("TestBasicHeadersAndRows_Expected.csv");

            // ensure the two arrays are the same length 
            Assert.AreEqual(expectedBytes.Length, actualBytes.Length);

            // ensure the bytes are identical 
            for (int i = 0; i < expectedBytes.Length; i++)
            {
                byte expected = expectedBytes[i];
                byte actual = actualBytes[i];

                Assert.IsTrue(expected == actual,
                    String.Format("Expected: '{0}', Actual: '{1}' at offset {2}.", (byte)expected, (byte)actual, i)
                );
            }
        }
    }
}
