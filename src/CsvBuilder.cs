using System;
using System.Linq;
using System.Text;

namespace SyntaxSolutions.CsvBuilder
{
    public class CsvBuilder
    {
        private StringBuilder headerBuilder;
        private StringBuilder contentBuilder;
        private string delimiter = ",";
        private string linebreak = "\r\n";
        private char BOM = '\uFEFF';

        /// <summary>
        /// Create a new CsvBuilder
        /// </summary>
        public CsvBuilder()
        {
            this.contentBuilder = new StringBuilder();
            this.headerBuilder = new StringBuilder();
        }

        /// <summary>
        /// Add a CSVRow used for the column headers values
        /// </summary>
        /// <param name="row"></param>
        public void AddHeaders(CsvRow row)
        {
            if (row != null)
            {
                if (row.Cells.Count() > 0)
                {
                    string line = String.Join(this.delimiter, row.Cells.ToArray());
                    line += this.linebreak;
                    this.headerBuilder.Append(line);
                }
            }
        }

        /// <summary>
        /// Add a CSVRow
        /// </summary>
        /// <param name="text"></param>
        public void AddRow(CsvRow row)
        {
            if (row != null)
            {
                if (row.Cells.Count() > 0)
                {
                    // flush any previously added cells 
                    string line = String.Join(this.delimiter, row.Cells.ToArray());
                    this.contentBuilder.Append(line);
                }
            }

            this.newLine();
        }

        /// <summary>
        /// Return the contents of the CSV as a UTF8 encoded array of bytes
        /// </summary>
        /// <returns></returns>
        public byte[] GetBytes()
        {
            string content = String.Empty;
            if (this.headerBuilder.ToString().Length > 0 || this.contentBuilder.ToString().Length > 0)
            {
                // add a Byte Order Marker to the data stream to ensure MS Excel opens the CSV file with UTF8 encoding.
                content = this.BOM + this.headerBuilder.ToString() + this.contentBuilder.ToString();
            }

            return Encoding.UTF8.GetBytes(content);
        }

        /// <summary>
        /// Add a new line
        /// </summary>
        /// <param name="text"></param>
        private void newLine()
        {
            this.contentBuilder.Append(this.linebreak);
        }

    }
}
