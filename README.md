# CSV Builder for .Net
A simple .Net library used to format data into comma-separated values (CSV)

## Installation

```sh
PM> Install-Package SyntaxSolutions.CsvBuilder
```

## Example

```c#
using SyntaxSolutions.CsvBuilder;

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

byte[] fileContents = builder.GetBytes();
```
