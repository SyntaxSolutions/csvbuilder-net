# csvbuilder-net
A simple .Net library used to format data into comma-separated values (CSV)
```c#
using CsvBuilder.CsvBuilder;
using CsvBuilder.CsvRow;

var builder = new CsvBuilder();

var headers = new CsvRow();
headers.addCell("Header 1");
headers.addCell("Header 2");
headers.addCell("Header 3");
builder.addHeaders(headers);

var row = new CsvRow();
row.addCell("Cell 1");
row.addCell("Cell 2");
row.addCell("Cell 3");
builder.addRow(row);

byte[] fileContents = builder.getBytes();
```
