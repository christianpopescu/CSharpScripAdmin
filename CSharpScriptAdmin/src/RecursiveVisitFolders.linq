<Query Kind="Program" />

void Main(string[] args)
{
#if !CMD
	args = new[] { @"D:\Temp\ToDelete\TerminalGui" };
#endif
	string folderToVisit = args[0];
	RecursiveVisit(folderToVisit);
}


void RecursiveVisit(string folder)
{
	Console.WriteLine(folder);
	var folderCollection = Directory.GetDirectories(folder);
	foreach (var fld in folderCollection)
	{
		RecursiveVisit(fld);
	}
			
}
// You can define other methods, fields, classes and namespaces here