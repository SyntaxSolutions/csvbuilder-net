using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SyntaxSolutions.CsvBuilder
{
    public class CsvRow
    {
        private List<string> _cells { get; set; }

        /// <summary>
        /// Get a list of cells
        /// </summary>
        internal ReadOnlyCollection<string> Cells
        {
            get { return this._cells.AsReadOnly(); }
        }

        /// <summary>
        /// Create a new CsvRow
        /// </summary>
        public CsvRow()
        {
            this._cells = new List<string>();
        }

        /// <summary>
        /// Add a cell
        /// </summary>
        /// <param name="value">String value of the cell.</param>
        public void AddCell(string value)
        {
            string formattedText;

            if (String.IsNullOrEmpty(value))
            {
                formattedText = string.Empty; 
            }
            else
            {
                formattedText = value.Replace("\"", "\"\"");

                if (formattedText.Contains("\"")
                  || formattedText.Contains(",")
                  || formattedText.StartsWith(" ")
                  || formattedText.EndsWith(" ")
                  || formattedText.Contains("\r")
                  || formattedText.Contains("\n")
                )
                {
                    formattedText = String.Format("\"{0}\"", formattedText);
                }
            }

            this._cells.Add(formattedText);
        }
    }
}
