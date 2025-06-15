<Query Kind="Program" />

using System;
using System.Windows.Forms;

/// <summary>
/// Choose files and folders using WinForm dialog of Windows
/// </summary>
void Main()
{
	Console.WriteLine(ChooseFolder());
	
	IList<string> il = ChooseMultipleFiles();
	
	foreach (var file in il)
	{
		Console.WriteLine(file);
	}
}

// You can define other methods, fields, classes and namespaces here
private static string ChooseFolder()
{
	string choosedFolder = "";

	using (var folderDialog = new FolderBrowserDialog())
	{
		DialogResult result = folderDialog.ShowDialog();

		if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
		{
			//Console.WriteLine("Selected folder: " + folderDialog.SelectedPath);
			choosedFolder = folderDialog.SelectedPath;
		}
	}
	return choosedFolder;
}

private static IList<string> ChooseMultipleFiles()
{
	List<string> result = new();
    using (var dialog = new OpenFileDialog())
    {
        dialog.Filter = "All files (*.*)|*.*";
        dialog.Multiselect = true;

        if (dialog.ShowDialog() == DialogResult.OK)
		{
			foreach (var file in dialog.FileNames)
			{
				result.Add(file);
			}
		}
	}
	return result;

}