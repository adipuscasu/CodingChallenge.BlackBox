using BlackBox.BusinessLogic;
using CodingChallenge.BlackBox;
using System.Security;

namespace BlackBoxApp
{
    public partial class MainForm : Form
    {
        private Dictionary<string, byte[]> _blackBoxCandidates = new Dictionary<string, byte[]>();

        private readonly BlackBoxGenerator _blackBoxGenerator = new BlackBoxGenerator();

        private BlackboxParser _blackboxParser;
        public MainForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBoxDescription.Text = RemoveFileNameExtension(openFileDialog1.FileName);
                    lblSelectedFile.Text = "Selected file: " + openFileDialog1.FileName;
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private string RemoveFileNameExtension(string fileName)
        {
            return Path.GetFileNameWithoutExtension(fileName);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            EnableOrDisableItems();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            EnableOrDisableItems();
            dataGridView1.Refresh();
        }

        private void EnableOrDisableItems()
        {
            if (!string.IsNullOrEmpty(textBoxDescription.Text) && openFileDialog1.CheckFileExists)
            {
                btnAddFileAndDescription.Enabled = true;

            }
            else
            {
                btnAddFileAndDescription.Enabled = false;
            }

            if (_blackBoxCandidates.Count > 0)
            {
                textBoxOutPutFileLocation.Enabled = true;
                btnSaveFile.Enabled = true;
            }
            else
            {
                textBoxOutPutFileLocation.Enabled = false;
                btnSaveFile.Enabled = false;
            }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            EnableOrDisableItems();
            SetDataSource();
        }

        private void btnAddFileAndDescription_Click(object sender, EventArgs e)
        {
            AddFileNameAndDescription();
        }

        private void SetDataSource()
        {
            if (_blackBoxCandidates.Count == 0)
            {
                return;
            }
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = _blackBoxCandidates;

            dataGridView1.DataSource = bindingSource;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[0].HeaderText = "Description";
            dataGridView1.Columns[1].HeaderText = "Image";

            dataGridView1.AutoResizeColumns();
            dataGridView1.Refresh();

        }

        private void AddFileNameAndDescription()
        {
            if (openFileDialog1.CheckFileExists)
            {
                byte[] fileContent = BlackBoxGenerator.GetFileContentAsByteArray(openFileDialog1.FileName);

                if (fileContent.Length > 0 && _blackBoxCandidates.TryAdd(textBoxDescription.Text, fileContent))
                {
                    textBoxDescription.Text = string.Empty;
                    openFileDialog1.Reset();
                    openFileDialog1.FileName = string.Empty;
                    lblSelectedFile.Text = string.Empty;
                    SetDataSource();
                    dataGridView1.Refresh();
                }
            }
        }

        private void DeleteSelectedItem(DataGridView e)
        {
            if (e.Rows.Count == 0)
            {
                return;
            }

            var rows = e.Rows;

            Dictionary<string, byte[]> dict2 = new Dictionary<string, byte[]>();
            foreach (DataGridViewRow row in rows)
            {
                var gridKey = (KeyValuePair<string, byte[]>)row.DataBoundItem;

                dict2.TryAdd(gridKey.Key, gridKey.Value);
            }

            var missingKeyValuePair = _blackBoxCandidates.Except(dict2).FirstOrDefault();

            if (missingKeyValuePair.Key != null)
            {
                _blackBoxCandidates.Remove(missingKeyValuePair.Key);
            }
            else
            {
                Console.WriteLine("No missing key value pair found.");
            }
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            DeleteSelectedItem((DataGridView)sender);
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            _blackBoxGenerator.CreateFile(_blackBoxCandidates, textBoxOutPutFileLocation.Text);
            MessageBox.Show($"File created at {textBoxOutPutFileLocation.Text}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonLoadBlackbox_Click(object sender, EventArgs e)
        {
            if (openFileDialogBlackboxLoad.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    labelSelectedBlackboxFile.Text = "Selected file: " + openFileDialogBlackboxLoad.FileName;
                    _blackboxParser = new BlackboxParser(openFileDialogBlackboxLoad.FileName);
                    PopulateDescriptionsComboBox();
                    comboBoxDescriptions.Enabled = true;
                    comboBoxDescriptions.Text = string.Empty;
                    buttonExtractImage.Enabled = true;
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void ButtonGenerateImage_Click(object sender, EventArgs e)
        {
            if (comboBoxDescriptions.SelectedItem is null)
            {
                MessageBox.Show("Please select a value from the list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {

                var description = comboBoxDescriptions.SelectedItem.ToString();
                _blackboxParser.BuildImageByDescription(description);
                string path = Path.GetDirectoryName(openFileDialogBlackboxLoad.FileName) + "\\" + description + ".jpg";

                MessageBox.Show($"Image extracted at {path}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void PopulateDescriptionsComboBox()
        {
            IEnumerable<string> descriptions = _blackboxParser.GetDescriptions();
            comboBoxDescriptions.Items.Clear();

            foreach (string desc in descriptions)
            {
                comboBoxDescriptions.Items.Add(desc);
            }

            comboBoxDescriptions.Refresh();

        }
    }
}