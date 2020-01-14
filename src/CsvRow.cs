using System;
using System.Collections.Generic;

namespace SyntaxSolutions.CsvBuilder
{
    public class CsvRow
    {
        public List<string> Cells { get; set; }

        /// <summary>
        /// Create a new CsvRow
        /// </summary>
        public CsvRow()
        {
            this.Cells = new List<string>();
        }

        /// <summary>
        /// Add text to row cell 
        /// </summary>
        /// <param name="text"></param>
        public void AddCell(string text)
        {
            this.Cells.Add(String.Format("\"{0}\"", text));
        }
    }
}
