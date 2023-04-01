<Query Kind="Program" />

void Main()
{
	string folderToVisit = @"E:\CCP_library\Doc_IT_New";
	RecursiveVisitWithFolders(folderToVisit);
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

void RecursiveVisitWithFolders(string folder)
{
	Console.WriteLine(folder);
	var folderCollection = Directory.GetDirectories(folder);
	foreach (var fld in folderCollection)
	{
		RecursiveVisitWithFolders(fld);
	}
	var filesCollection = Directory.GetFiles(folder);
	foreach(var fl in filesCollection)
	{
		Console.WriteLine("file -> " + fl);
	}
	

}
// You can define other methods, fields, classes and namespaces here