<Query Kind="Program" />

class Program
{
	static void Main()
	{
		ProcessStartInfo psi = new ProcessStartInfo
		{
			FileName = "cmd.exe",
			WorkingDirectory = @"D:\ccp_wrks\CSharpScripAdmin\CSharpScriptAdmin\src",
			Arguments = "/K", // Keeps the window open
			UseShellExecute = true
		};

		Process.Start(psi);
	}
}

// You can define other methods, fields, classes and namespaces here
