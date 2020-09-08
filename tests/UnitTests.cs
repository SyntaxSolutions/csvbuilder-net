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
            headers.AddCell("Header 4");
            headers.AddCell(" Header 5");
            headers.AddCell("Header 6 ");
            headers.AddCell("Header 7");
            builder.AddHeaders(headers);

            var row = new CsvRow();
            row.AddCell("Cell 1 \"with quotes\"");
            row.AddCell("Cell 2 with line break 1\r\nline break 2");
            row.AddCell("Cell 3");
            row.AddCell("Cell, with, commas");
            row.AddCell(" leading space");
            row.AddCell("trailing space ");
            row.AddCell(null);
            builder.AddRow(row);

            byte[] actualBytes = builder.GetBytes();
            byte[] expectedBytes = System.IO.File.ReadAllBytes("TestBasicHeadersAndRows_Expected.csv");

            // ensure the two arrays are the same length 
            Assert.AreEqual(expectedBytes.Length, actualBytes.Length,
                String.Format("Total byte count does not match Expected: '{0}', Actual: '{1}' | {2}", expectedBytes.Length, (actualBytes.Length), BitConverter.ToString(actualBytes))
            );

            // ensure the bytes are identical 
            for (int i = 0; i < expectedBytes.Length; i++)
            {
                byte expected = expectedBytes[i];
                byte actual = actualBytes[i];

                Assert.IsTrue(expected == actual,
                    String.Format("Expected: '{0}', Actual: '{1}' at offset {2} | {3}", BitConverter.ToString(new byte[] { (byte)expected }), BitConverter.ToString(new byte[] { (byte)actual }), i, BitConverter.ToString(actualBytes))
                );
            }
        }

        [TestMethod]
        public void TestZeroHeadersAndRows()
        {
            var builder = new CsvBuilder();
            byte[] actualBytes = builder.GetBytes();
            int expectedByteLength = 0;

            // ensure the two arrays are the same length 
            Assert.AreEqual(expectedByteLength, actualBytes.Length,
                String.Format("Total byte count does not match Expected: '{0}', Actual: '{1}' | {2}", expectedByteLength, (actualBytes.Length), BitConverter.ToString(actualBytes))
            );
        }
    }
}
