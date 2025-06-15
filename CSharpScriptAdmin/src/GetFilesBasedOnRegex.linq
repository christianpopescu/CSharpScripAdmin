<Query Kind="Program" />

/// <summary>
/// The purpose is to get the file(s) that correspond to a given Regex
/// </summary>

void Main()
{
	GetAllFilesWithAGivenPattern();
}

public static void GetAllFilesWithAGivenPattern()
{
	string folderPath = @"D:\Temp\ToDelete\X"; // <- update this
	string pattern = @"^prefix_qal(\d{2})";

	var idList = new List<string>();

	foreach (string file in Directory.GetFiles(folderPath))
	{
		string fileName = Path.GetFileName(file);
		Match match = Regex.Match(fileName, pattern, RegexOptions.IgnoreCase);

		if (match.Success)
		{
			string id = match.Groups[1].Value;
			idList.Add(id);
			Console.WriteLine($"File: {fileName}, ID: {id}");
		}

	}
}

// You can define other methods, fields, classes and namespaces here
