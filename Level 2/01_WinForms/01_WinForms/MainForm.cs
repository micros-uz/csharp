using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_WinForms
{
    public partial class MainForm : Form
    {
        private string _fileName;
        private List<Font> _fonts;

        public MainForm()
        {
            InitializeComponent();

            comboBox1.Items.AddRange(
                System.Drawing.FontFamily.
                Families.Select(x => x.Name).ToArray());

            _fonts = new List<Font>();

                _fonts.AddRange(System.Drawing.FontFamily.
                Families.Select(x => CreateFont(x.Name)));

        }

        private Font CreateFont(string p)
        {
            try 
	        {
                return new Font(p, 10, FontStyle.Regular);
	        }
	        catch (Exception)
	        {
                return null;
	        }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void SaveFile()
        {
            richTextBox1.SaveFile(_fileName, RichTextBoxStreamType.PlainText);
            toolStripStatusLabel1.Text = "File was saved successfully";
            richTextBox1.Modified = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = openFileDialog1.ShowDialog();

            if (res == DialogResult.OK)
            {
                LoadFile(openFileDialog1.FileName);
            }
        }

        private void LoadFile(string fileName)
        {
            richTextBox1.LoadFile(fileName, RichTextBoxStreamType.PlainText);
            _fileName = fileName;

            EnableSave(false);

            richTextBox1.ModifiedChanged -= richTextBox1_ModifiedChanged;
            richTextBox1.Modified = false;
            richTextBox1.ModifiedChanged += richTextBox1_ModifiedChanged;

            toolStripStatusLabel1.Text = "File was loaded successfully";
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsFile();
        }

        private void SaveAsFile()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _fileName = saveFileDialog1.FileName;
                SaveFile();
            }
        }

        private void richTextBox1_ModifiedChanged(object sender, EventArgs e)
        {
            EnableSave(true);
        }

        private void EnableSave(bool val)
        {
            saveToolStripMenuItem.Enabled = val;
            toolStripButton2.Enabled = val;
            //saveAsToolStripMenuItem.Enabled = val;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (richTextBox1.Modified)
            {
                var res = MessageBox.Show("File was changed. Do you want to save changes?",
                    Text,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                switch (res)
                {
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    case DialogResult.Yes:
                        if (string.IsNullOrEmpty(_fileName))
                            SaveAsFile();
                        else
                            SaveFile();
                        break;
                }
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var font = richTextBox1.Font;

            var size = Convert.ToInt32(toolStripComboBox1.SelectedItem);

            var newFont = new Font(font.FontFamily,
                size, font.Style);

            richTextBox1.Font = newFont;

            //richTextBox1.SelectionFont = newFont;

        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font font = comboBox1.Font;
            Brush brush = Brushes.Black;
            string text = (string)comboBox1.Items[e.Index];

            var tmpFont = new Font("Lucida Console", font.Size, font.Style);

            if (_fonts.Select(x => x.FontFamily.Name).Contains(text))
            {
                font = _fonts.ToArray()[e.Index];
            }
            else
            {
                font = new Font("Arial", 10, FontStyle.Regular);
            }

            e.Graphics.DrawString(text, font, brush, e.Bounds);

            /*
            //if (e.Index == -1)
            //    return;

            //ComboBox combo = ((ComboBox)sender);
            //using (SolidBrush brush = new SolidBrush(e.ForeColor))
            //{
            //    Font font = e.Font;
            //    //if (/*Condition Specifying That Text Must Be Bold*/
            //    //    font = new System.Drawing.Font(font, FontStyle.Bold);
            //    e.DrawBackground();
            //    e.Graphics.DrawString(combo.Items[e.Index].ToString(), font, brush, e.Bounds);
            //    e.DrawFocusRectangle();
            //}
        }

    }
}
