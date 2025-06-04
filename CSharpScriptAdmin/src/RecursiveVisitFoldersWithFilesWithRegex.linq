<Query Kind="Program" />

Action<string> VisitDirectory ;

Action<string> VisitFile;

Predicate<string> FilterFile;

void Main()
{
	string folderToVisit = @"E:\CCP_library";
	List<string> listOfSelectedFiles = new List<string>();
	//VisitDirectory = (s) => { Console.WriteLine(s); };
	VisitDirectory = (s) => { };
	FilterFile = (s) => {
	Regex r = new Regex(@"python", RegexOptions.IgnoreCase);
	return r.IsMatch(s);
	};
	VisitFile = (s) => {
	Console.WriteLine("File - ---- >" + s);
	string fileName = Path.GetFileName(s);
//	Console.WriteLine(fileName);
	};
	RecursiveVisitWithFolders(folderToVisit, VisitDirectory, VisitFile, FilterFile);
}

void RecursiveVisitWithFolders(string folder, Action<string> functionVisitDirectory, Action<string> functionVisitFolder, Predicate<string> filterFolder)
{
	functionVisitDirectory(folder);
	var folderCollection = Directory.GetDirectories(folder);
	foreach (var fld in folderCollection)
	{
		RecursiveVisitWithFolders(fld, functionVisitDirectory, functionVisitFolder, filterFolder);
	}
	var filesCollection = Directory.GetFiles(folder);
	foreach(var fl in filesCollection.Select(x=>x).Where(x=> filterFolder(Path.GetFileName(x))))
	{
		//Console.WriteLine("file -> " + fl);
		functionVisitFolder(fl);
	}
	

}
// You can define other methods, fields, classes and namespaces here