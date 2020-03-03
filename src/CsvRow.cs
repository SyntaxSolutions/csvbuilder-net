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
            string formattedText;

            if (String.IsNullOrEmpty(text))
            {
                formattedText = string.Empty; 
            }
            else
            {
                formattedText = text.Replace("\"", "\"\"");

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

            this.Cells.Add(formattedText);
        }
    }
}
