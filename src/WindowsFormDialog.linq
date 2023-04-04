<Query Kind="Program" />


using System.Windows.Forms;

using System.Drawing;

void Main()
{
	// Create a new instance of the form.
	Form inputForm = new Form();
	// Create two buttons to use as the accept and cancel buttons.
	Button buttonOk = new Button();
	Button buttonCancel = new Button();

	// Set the text of buttonOk to "OK".
	buttonOk.Text = "OK";
	// Set the position of the button on the form.
	buttonOk.Location = new Point(10, 10);
	// Set the text of buttonCancel to "Cancel".
	buttonCancel.Text = "Cancel";
	// Set the position of the button based on the location of buttonOk.
	buttonCancel.Location
	   = new Point(buttonOk.Left, buttonOk.Height + buttonOk.Top + 10);
	// Make buttonOk's dialog result OK.
	buttonOk.DialogResult = DialogResult.OK;
	// Make buttonCancel's dialog result Cancel.
	buttonCancel.DialogResult = DialogResult.Cancel;
	// Set the caption bar text of the form.   
	inputForm.Text = "Input Dialog Box";

	// Define the border style of the form to a dialog box.
	inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
	// Set the accept button of the form to buttonOk.
	inputForm.AcceptButton = buttonOk;
	// Set the cancel button of the form to buttonCancel.
	inputForm.CancelButton = buttonCancel;
	// Set the start position of the form to the center of the screen.
	inputForm.StartPosition = FormStartPosition.CenterScreen;

	var textBox1 = new System.Windows.Forms.TextBox();
	
	textBox1.AcceptsReturn = true;
	textBox1.AcceptsTab = true;
	textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
	textBox1.Multiline = true;
	textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
	
	textBox1.Location = new Point(buttonOk.Left, buttonOk.Height + buttonOk.Top + 30);
	
	textBox1.Size = new System.Drawing.Size(50,50);

	// Add buttonOk to the form.
	inputForm.Controls.Add(buttonOk);
	// Add buttonCancel to the form.
	inputForm.Controls.Add(buttonCancel);
	
	inputForm.Controls.Add(textBox1);

	// Display the form as a modal dialog box.
	inputForm.ShowDialog();

	// Determine if the OK button was clicked on the dialog box.
	if (inputForm.DialogResult == DialogResult.OK)
	{
		// Display a message box indicating that the OK button was clicked.
		MessageBox.Show("The OK button on the form was clicked.");
		MessageBox.Show(textBox1.Text);
		// Optional: Call the Dispose method when you are finished with the dialog box.
		inputForm.Dispose();
	}
	else
	{
		// Display a message box indicating that the Cancel button was clicked.
		MessageBox.Show("The Cancel button on the form was clicked.");
		// Optional: Call the Dispose method when you are finished with the dialog box.
		inputForm.Dispose();
	}
}

// You can define other methods, fields, classes and namespaces here