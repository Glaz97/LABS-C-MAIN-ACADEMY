using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Part_2_LabWork_4._1
{
    public partial class Form5 : Form
    {
        Point Bgn;

        public Form5()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.SkyBlue;
            BtnNext.Text = "Close";
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            GraphicsPath my_pth = new GraphicsPath();
            my_pth.AddEllipse(0, 0, Width, Height);
            Region my_rg = new Region(my_pth);
            Region = my_rg;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form5_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Bgn = new Point(e.X, e.Y);
            }
        }

        private void Form5_MouseMove(object sender, MouseEventArgs e)
        {
            if((e.Button & MouseButtons.Left) != 0)
            {
                Point dP = new Point(e.X - Bgn.X, e.Y - Bgn.Y);
                Location = new Point(Location.X + dP.X, Location.Y + dP.Y);
            }
        }
    }
}
