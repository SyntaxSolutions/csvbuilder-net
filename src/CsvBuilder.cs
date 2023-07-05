using System;
using System.Linq;
using System.Text;

namespace SyntaxSolutions.CsvBuilder
{
    /// <summary>
    /// Build CSV formatted data
    /// </summary>
    public class CsvBuilder
    {
        private StringBuilder _headerBuilder;
        private StringBuilder _contentBuilder;
        private const string DELIMETER = ",";
        private const string LINEBREAK = "\r\n";
        private const char BOM = '\uFEFF';

        /// <summary>
        /// Create a new CsvBuilder
        /// </summary>
        public CsvBuilder()
        {
            this._contentBuilder = new StringBuilder();
            this._headerBuilder = new StringBuilder();
        }

        /// <summary>
        /// Add headers
        /// </summary>
        /// <param name="row">CsvRow containing the header cells.</param>
        public void AddHeaders(CsvRow row)
        {
            if (row != null)
            {
                if (row.Cells.Count() > 0)
                {
                    string line = String.Join(DELIMETER, row.Cells.ToArray());
                    this._headerBuilder.Append(line);
                }
            }

            this._headerBuilder.Append(LINEBREAK);
        }

        /// <summary>
        /// Add a row
        /// </summary>
        /// <param name="row">CsvRow containing the row cells.</param>
        public void AddRow(CsvRow row)
        {
            if (row != null)
            {
                if (row.Cells.Count() > 0)
                {
                    string line = String.Join(DELIMETER, row.Cells.ToArray());
                    this._contentBuilder.Append(line);
                }
            }

            this._contentBuilder.Append(LINEBREAK);
        }

        /// <summary>
        /// Get the CSV contents
        /// </summary>
        /// <returns>UTF8 encoded array of bytes.</returns>
        public byte[] GetBytes()
        {
            string content = String.Empty;
            if (this._headerBuilder.ToString().Length > 0 || this._contentBuilder.ToString().Length > 0)
            {
                // add a Byte Order Marker to the data stream to ensure MS Excel opens the CSV file with UTF8 encoding.
                content = BOM + this._headerBuilder.ToString() + this._contentBuilder.ToString();
            }

            return Encoding.UTF8.GetBytes(content);
        }
    }
}
