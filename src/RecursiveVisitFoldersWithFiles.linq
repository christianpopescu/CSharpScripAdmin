<Query Kind="Program" />

Action<string> VisitDirectory ;

Action<string> VisitFile;

Predicate<string> FilterFile;

Dictionary<string,Predicate<string>> FilterFileList = new Dictionary<string, System.Predicate<string>>();

void Main()
{
	// List file that have a path too long to be copied to a tablet
	
	string folderToVisit = @"E:\CCP_library\Doc_it_new";
	InitFilterDictionary();
	List<string> listOfSelectedFiles = new List<string>();
	//VisitDirectory = (s) => { Console.WriteLine(s); };
	
	VisitDirectory = (s) => { };
	//FilterFile = 
	FilterFile = FilterFileList["No Filter"];
	VisitFile = (s) => {
	if (s.Length > 235)
	Console.WriteLine("File - ---- >" + s);
	//string fileName = Path.GetFileName(s);
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

void InitFilterDictionary()
{
	FilterFileList["No Filter"] = (s) => { return true;};
	FilterFileList["Contains Python"] = (s) => { return s.Contains("Python");};
}

// You can define other methods, fields, classes and namespaces here