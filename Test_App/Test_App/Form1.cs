using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_App
{
    public partial class FormSniper : Form
    {
        public FormSniper()
        {
            InitializeComponent();
        }

        private void FormSniper_Load(object sender, EventArgs e)
        {
            Image image = Image.FromFile("G:\\1.jpg");
            pictureBoxMap.Image = image;
            pictureBoxMap.Height = image.Height;
            pictureBoxMap.Width = image.Width;
        }
    }
}
