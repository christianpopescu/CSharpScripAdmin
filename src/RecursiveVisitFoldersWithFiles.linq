<Query Kind="Program" />

Action<string> VisitDirectory ;

void Main()
{
	string folderToVisit = @"E:\CCP_library\Doc_IT_New";
	VisitDirectory = (s) => {Console.WriteLine(s);};
	RecursiveVisitWithFolders(folderToVisit, VisitDirectory);
}

void RecursiveVisitWithFolders(string folder, Action<string> functionVisitDirectory)
{
	functionVisitDirectory(folder);
	var folderCollection = Directory.GetDirectories(folder);
	foreach (var fld in folderCollection)
	{
		RecursiveVisitWithFolders(fld, functionVisitDirectory);
	}
	var filesCollection = Directory.GetFiles(folder);
	foreach(var fl in filesCollection)
	{
		Console.WriteLine("file -> " + fl);
	}
	

}
// You can define other methods, fields, classes and namespaces here