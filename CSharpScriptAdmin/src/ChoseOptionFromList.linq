<Query Kind="Program" />

using System;
using System.Windows.Forms;
void Main()
{
	string selection = ShowSelectionDialog(new string[]
	{
			"Option A",
			"Option B",
			"Option C"
	});
	
			Console.WriteLine("Selected choice: " + selection);
}

// You can define other methods, fields, classes and namespaces here


	static string ShowSelectionDialog(string[] choices)
	{
		string selected = null;

		var form = new Form()
		{
			Width = 300,
			Height = 250,
			Text = "Choose an Option",
			FormBorderStyle = FormBorderStyle.FixedDialog,
			StartPosition = FormStartPosition.CenterScreen
		};

		var listBox = new ListBox()
		{
			Dock = DockStyle.Top,
			Height = 150
		};
		listBox.Items.AddRange(choices);
		form.Controls.Add(listBox);

		var button = new Button()
		{
			Text = "OK",
			Dock = DockStyle.Bottom,
			Height = 30
		};
		button.Click += (sender, e) =>
		{
			if (listBox.SelectedItem != null)
			{
				selected = listBox.SelectedItem.ToString();
				form.Close();
			}
			else
			{
				MessageBox.Show("Please select an item before clicking OK.");
			}
		};
		form.Controls.Add(button);

		Application.Run(form);
		return selected;
	}

