using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing; // Để sử dụng Image
namespace bt5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string imageFile)
        {
            InitializeComponent();

            if (pictureBox1 == null)
            {
                pictureBox1 = new PictureBox();
                pictureBox1.Dock = DockStyle.Fill;
                this.Controls.Add(pictureBox1);
            }


            pictureBox1.Image = Image.FromFile(imageFile);


            Text = imageFile.Substring(imageFile.LastIndexOf('\\') + 1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
