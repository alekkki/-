using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Test_App
{
    public partial class FormMap : Form
    {
        private Point currentPoint;
        private Pen dashedPen;
        private Pen solidPen;
        private SolidBrush brush;

        public FormMap()
        {
            InitializeComponent();
            currentPoint = new Point();
            dashedPen = new Pen(Color.Red, 2);
            dashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            solidPen = new Pen(Color.Red, 4);
            solidPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            brush = new SolidBrush(Color.Black);
            DoubleBuffered = true;
        }

        private void FormMap_Load(object sender, EventArgs e)
        {
            Image image = Image.FromFile("G:\\1.jpg");
            pictureBoxMap.Image = image;
            pictureBoxMap.Height = image.Height;
            pictureBoxMap.Width = image.Width;
        }

        private void pictureBoxMap_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(dashedPen, currentPoint.X, currentPoint.Y - 50, currentPoint.X, currentPoint.Y + 50);
            e.Graphics.DrawLine(dashedPen, currentPoint.X - 50, currentPoint.Y, currentPoint.X + 50, currentPoint.Y);
            e.Graphics.DrawEllipse(solidPen, currentPoint.X - 50, currentPoint.Y - 50, 100, 100);

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(currentPoint.X - 50, currentPoint.Y - 50, 100, 100);
            Region region = new Region();
            region.Exclude(path);
            Graphics g = e.Graphics;
            g.FillRegion(brush, region);

            Invalidate(true);
        }

        private void pictureBoxMap_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Hide();
            currentPoint.X = e.X;
            currentPoint.Y = e.Y;
            Invalidate(true);
        }
    }
}
