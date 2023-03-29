namespace BlackBoxApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label2 = new Label();
            textBoxOutPutFileLocation = new TextBox();
            lblSelectedFile = new Label();
            dataGridView1 = new DataGridView();
            button3 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            btnSaveFile = new Button();
            btnAddFileAndDescription = new Button();
            tabPage2 = new TabPage();
            groupBoxExtract = new GroupBox();
            comboBoxDescriptions = new ComboBox();
            buttonExtractImage = new Button();
            label4 = new Label();
            groupBoxLoadBlackbox = new GroupBox();
            labelSelectedBlackboxFile = new Label();
            button1 = new Button();
            openFileDialog1 = new OpenFileDialog();
            openFileDialogBlackboxLoad = new OpenFileDialog();
            saveFileDialogImage = new SaveFileDialog();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            groupBoxExtract.SuspendLayout();
            groupBoxLoadBlackbox.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 33);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(703, 360);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(textBoxOutPutFileLocation);
            tabPage1.Controls.Add(lblSelectedFile);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(btnSaveFile);
            tabPage1.Controls.Add(btnAddFileAndDescription);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(695, 332);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Generate BlackBox";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 279);
            label2.Name = "label2";
            label2.Size = new Size(140, 15);
            label2.TabIndex = 9;
            label2.Text = "Blackbox.dat file location";
            // 
            // textBoxOutPutFileLocation
            // 
            textBoxOutPutFileLocation.Location = new Point(6, 297);
            textBoxOutPutFileLocation.Name = "textBoxOutPutFileLocation";
            textBoxOutPutFileLocation.Size = new Size(417, 23);
            textBoxOutPutFileLocation.TabIndex = 8;
            textBoxOutPutFileLocation.Text = "C:\\temp\\blackbox.dat";
            // 
            // lblSelectedFile
            // 
            lblSelectedFile.AutoSize = true;
            lblSelectedFile.Location = new Point(17, 38);
            lblSelectedFile.Name = "lblSelectedFile";
            lblSelectedFile.Size = new Size(73, 15);
            lblSelectedFile.TabIndex = 7;
            lblSelectedFile.Text = "Selected file:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 67);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(683, 150);
            dataGridView1.TabIndex = 6;
            dataGridView1.UserDeletedRow += dataGridView1_UserDeletedRow;
            // 
            // button3
            // 
            button3.Location = new Point(258, 6);
            button3.Name = "button3";
            button3.Size = new Size(93, 27);
            button3.TabIndex = 5;
            button3.Text = "Open file";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 12);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 4;
            label1.Text = "File description";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(96, 9);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(147, 23);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // btnSaveFile
            // 
            btnSaveFile.Location = new Point(429, 289);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new Size(260, 37);
            btnSaveFile.TabIndex = 2;
            btnSaveFile.Text = "Create file";
            btnSaveFile.UseVisualStyleBackColor = true;
            btnSaveFile.Click += btnSaveFile_Click;
            // 
            // btnAddFileAndDescription
            // 
            btnAddFileAndDescription.Location = new Point(518, 6);
            btnAddFileAndDescription.Name = "btnAddFileAndDescription";
            btnAddFileAndDescription.Size = new Size(171, 37);
            btnAddFileAndDescription.TabIndex = 0;
            btnAddFileAndDescription.Text = "Add file and description";
            btnAddFileAndDescription.UseVisualStyleBackColor = true;
            btnAddFileAndDescription.Click += btnAddFileAndDescription_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBoxExtract);
            tabPage2.Controls.Add(groupBoxLoadBlackbox);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(695, 332);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Extract from BlackBox";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBoxExtract
            // 
            groupBoxExtract.Controls.Add(comboBoxDescriptions);
            groupBoxExtract.Controls.Add(buttonExtractImage);
            groupBoxExtract.Controls.Add(label4);
            groupBoxExtract.Location = new Point(6, 110);
            groupBoxExtract.Name = "groupBoxExtract";
            groupBoxExtract.Size = new Size(683, 66);
            groupBoxExtract.TabIndex = 12;
            groupBoxExtract.TabStop = false;
            groupBoxExtract.Text = "Extract image by description";
            // 
            // comboBoxDescriptions
            // 
            comboBoxDescriptions.Enabled = false;
            comboBoxDescriptions.FormattingEnabled = true;
            comboBoxDescriptions.Location = new Point(151, 22);
            comboBoxDescriptions.Name = "comboBoxDescriptions";
            comboBoxDescriptions.Size = new Size(327, 23);
            comboBoxDescriptions.TabIndex = 14;
            // 
            // buttonExtractImage
            // 
            buttonExtractImage.Enabled = false;
            buttonExtractImage.Location = new Point(501, 22);
            buttonExtractImage.Name = "buttonExtractImage";
            buttonExtractImage.Size = new Size(149, 23);
            buttonExtractImage.TabIndex = 13;
            buttonExtractImage.Text = "Extract image";
            buttonExtractImage.UseVisualStyleBackColor = true;
            buttonExtractImage.Click += ButtonGenerateImage_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 25);
            label4.Name = "label4";
            label4.Size = new Size(139, 15);
            label4.TabIndex = 12;
            label4.Text = "Select image description:";
            // 
            // groupBoxLoadBlackbox
            // 
            groupBoxLoadBlackbox.Controls.Add(labelSelectedBlackboxFile);
            groupBoxLoadBlackbox.Controls.Add(button1);
            groupBoxLoadBlackbox.Location = new Point(6, 6);
            groupBoxLoadBlackbox.Name = "groupBoxLoadBlackbox";
            groupBoxLoadBlackbox.Size = new Size(683, 98);
            groupBoxLoadBlackbox.TabIndex = 11;
            groupBoxLoadBlackbox.TabStop = false;
            groupBoxLoadBlackbox.Text = "Load blackbox.dat file";
            // 
            // labelSelectedBlackboxFile
            // 
            labelSelectedBlackboxFile.AutoSize = true;
            labelSelectedBlackboxFile.Location = new Point(6, 63);
            labelSelectedBlackboxFile.Name = "labelSelectedBlackboxFile";
            labelSelectedBlackboxFile.Size = new Size(73, 15);
            labelSelectedBlackboxFile.TabIndex = 10;
            labelSelectedBlackboxFile.Text = "Selected file:";
            // 
            // button1
            // 
            button1.Location = new Point(6, 22);
            button1.Name = "button1";
            button1.Size = new Size(93, 27);
            button1.TabIndex = 9;
            button1.Text = "Open file";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ButtonLoadBlackbox_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg)|*.jpg;";
            // 
            // openFileDialogBlackboxLoad
            // 
            openFileDialogBlackboxLoad.Filter = "Dat files (*.dat)|*.dat;";
            // 
            // saveFileDialogImage
            // 
            saveFileDialogImage.Filter = "Image files (*.jpg, *.jpeg)|*.jpg;";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "Coding challenge";
            Activated += MainForm_Activated;
            MouseDown += MainForm_MouseDown;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            groupBoxExtract.ResumeLayout(false);
            groupBoxExtract.PerformLayout();
            groupBoxLoadBlackbox.ResumeLayout(false);
            groupBoxLoadBlackbox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnAddFileAndDescription;
        private Button button3;
        private Label label1;
        private TextBox textBox1;
        private Button btnSaveFile;
        private OpenFileDialog openFileDialog1;
        private DataGridView dataGridView1;
        private Label lblSelectedFile;
        private Label label2;
        private TextBox textBoxOutPutFileLocation;
        private GroupBox groupBoxExtract;
        private Button buttonExtractImage;
        private Label label4;
        private GroupBox groupBoxLoadBlackbox;
        private Label labelSelectedBlackboxFile;
        private Button button1;
        private OpenFileDialog openFileDialogBlackboxLoad;
        private SaveFileDialog saveFileDialogImage;
        private ComboBox comboBoxDescriptions;
    }
}