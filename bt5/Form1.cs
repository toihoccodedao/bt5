using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bt5;

namespace bt5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = " bitmap file|*.bmp|JPEG|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Form2 form2 = new Form2(ofd.FileName);
                form2.MdiParent = this;
                form2.Show();
            }
        }


        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Font = new Font("Time new", 14, FontStyle.Regular);

            // Đặt giá trị mặc định trên ComboBox
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Rich Text Format (*.rtf)|*.rtf|Text File (*.txt)|*.txt|All Files (*.*)|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FilterIndex == 1) // Lưu định dạng .rtf
                {
                    richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.RichText);
                }
                else // Lưu định dạng .txt hoặc khác
                {
                    richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



 

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Font = new Font("Tahoma", 14, FontStyle.Regular);

            // Đặt giá trị mặc định trên ComboBox
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Rich Text Format (*.rtf)|*.rtf|Text File (*.txt)|*.txt|All Files (*.*)|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FilterIndex == 1) // Lưu định dạng .rtf
                {
                    richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.RichText);
                }
                else // Lưu định dạng .txt hoặc khác
                {
                    richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle = currentFont.Style ^ FontStyle.Bold; // Toggle Bold
                richTextBox1.SelectionFont = new Font(currentFont, newFontStyle);
            }


        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle = currentFont.Style ^ FontStyle.Italic; // Toggle Italic
                richTextBox1.SelectionFont = new Font(currentFont, newFontStyle);
            }

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle = currentFont.Style ^ FontStyle.Underline; // Toggle Underline
                richTextBox1.SelectionFont = new Font(currentFont, newFontStyle);
            }


        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFont = toolStripComboBox1.SelectedItem.ToString();

            // Nếu có đoạn văn bản được chọn, thay đổi font của đoạn được chọn
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                richTextBox1.SelectionFont = new Font(selectedFont, currentFont.Size, currentFont.Style);
            }
            else
            {
                // Nếu không có đoạn văn bản nào được chọn, áp dụng font mới tại vị trí con trỏ
                Font defaultFont = richTextBox1.Font;
                richTextBox1.SelectionFont = new Font(selectedFont, defaultFont.Size, defaultFont.Style);
            }
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            float selectedSize = float.Parse(toolStripComboBox2.SelectedItem.ToString());

            // Nếu có đoạn văn bản được chọn, thay đổi kích thước chữ của đoạn được chọn
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, selectedSize, currentFont.Style);
            }
            else
            {
                // Nếu không có đoạn văn bản nào được chọn, áp dụng kích thước mới tại vị trí con trỏ
                Font defaultFont = richTextBox1.Font;
                richTextBox1.SelectionFont = new Font(defaultFont.FontFamily, selectedSize, defaultFont.Style);
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";

            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                toolStripComboBox2.Items.Add(s);
            }
            toolStripComboBox2.Text = "14";

        }

        
    }

}
