using Xunit.Abstractions;
using SyntaxSolutions.CsvBuilder;
using Xunit.Sdk;

namespace UnitTestDotNet
{
    public class UnitTests
    {
        private readonly ITestOutputHelper output;

        public UnitTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
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
            var filePath = Directory.GetCurrentDirectory() + @"..\..\..\..\..\Shared\TestBasicHeadersAndRows_Expected.csv";
            byte[] expectedBytes = System.IO.File.ReadAllBytes(filePath);

            try
            {
                // ensure the two arrays are the same length 
                Assert.Equal(expectedBytes.Length, actualBytes.Length);
            }
            catch (XunitException exception)
            {
                output.WriteLine(String.Format("Total byte count does not match Expected: '{0}', Actual: '{1}' | {2}", expectedBytes.Length, (actualBytes.Length), BitConverter.ToString(actualBytes)));
                output.WriteLine(exception.Message);
                throw;
            }

            // ensure the bytes are identical 
            for (int i = 0; i < expectedBytes.Length; i++)
            {
                byte expected = expectedBytes[i];
                byte actual = actualBytes[i];

                try
                {
                    Assert.True(expected == actual);
                }
                catch (XunitException exception)
                {
                    output.WriteLine(String.Format("Expected: '{0}', Actual: '{1}' at offset {2} | {3}", BitConverter.ToString(new byte[] { (byte)expected }), BitConverter.ToString(new byte[] { (byte)actual }), i, BitConverter.ToString(actualBytes)));
                    output.WriteLine(exception.Message);
                    throw;
                }
            }
        }

        [Fact]
        public void TestZeroHeadersAndRows()
        {
            var builder = new CsvBuilder();
            byte[] actualBytes = builder.GetBytes();
            int expectedByteLength = 0;

            try
            {
                // ensure the two arrays are the same length 
                Assert.Equal(expectedByteLength, actualBytes.Length);
            }
            catch (XunitException exception)
            {
                output.WriteLine(String.Format("Total byte count does not match Expected: '{0}', Actual: '{1}' | {2}", expectedByteLength, (actualBytes.Length), BitConverter.ToString(actualBytes)));
                output.WriteLine(exception.Message);
                throw;
            }
        }
    }
}