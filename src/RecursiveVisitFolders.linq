<Query Kind="Program" />

void Main()
{
	string folderToVisit = @"E:\CCP_library\Doc_IT_New";
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