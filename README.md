# CSV Builder for .Net
A simple .Net library used to format data into comma-separated values (CSV).

## Features

1. RFC 4180 standard compliant 
1. UTF-8 encoded. 
1. Excel compatible.
1. Compatible with frameworks: net6.0, net452

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