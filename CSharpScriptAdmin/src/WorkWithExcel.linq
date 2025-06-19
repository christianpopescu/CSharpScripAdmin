<Query Kind="Program">
  <NuGetReference>ClosedXML</NuGetReference>
  <Namespace>ClosedXML.Excel</Namespace>
</Query>

void Main()
{
	CreteExcelFileAndWriteValues();
	ReadValuesFromExcelFile();
 
}


private static void CreteExcelFileAndWriteValues()
{
	using (var workbook = new ClosedXML.Excel.XLWorkbook())
	{
		var worksheet = workbook.Worksheets.Add("Sheet1");
		worksheet.Cell("A1").Value = "Hello from LINQPad + ClosedXML!";
		worksheet.Cell("B1").Value = DateTime.Now;
		worksheet.Cell("A2").Value = "Line Two";
		worksheet.Cell("B2").Value = DateTime.Now;


		string filePath = Path.Combine(@"D:\Temp\ToDelete\", "linqpad_report.xlsx");
		workbook.SaveAs(filePath);

		filePath.Dump("Excel file saved to:");
	}
}

private static void ReadValuesFromExcelFile()
{
	string filePath = Path.Combine(@"D:\Temp\ToDelete\", "linqpad_report.xlsx");
	string sheetName = "Sheet1";
	string columnLetter = "A";

	using (var workbook = new ClosedXML.Excel.XLWorkbook(filePath))
	{
		var worksheet = workbook.Worksheet(sheetName);
		int row = 1;

		while (true)
		{
			var cell = worksheet.Cell($"{columnLetter}{row}");
			var value = cell.GetValue<string>();

			if (string.IsNullOrWhiteSpace(value))
				break;

			Console.WriteLine($"Row {row}: {value}");
			row++;
		}
	}
}
// You can define other methods, fields, classes and namespaces here
