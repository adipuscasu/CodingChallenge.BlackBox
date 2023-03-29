
OpenFileDialog dialog = new OpenFileDialog();
if (DialogResult.OK == dialog.ShowDialog())
{
    string path = dialog.FileName;
}
Console.WriteLine("Hello World!");