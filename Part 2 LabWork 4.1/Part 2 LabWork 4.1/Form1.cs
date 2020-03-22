using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Part_2_LabWork_4._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ich bind gut!");
        }

        private void BtnNo_MouseMove(object sender, MouseEventArgs e)
        {
            BtnNo.Top -= e.Y;
            BtnNo.Left += e.X;
            if (BtnNo.Top < -10 || BtnNo.Top > 100)
                BtnNo.Top = 60;
            if (BtnNo.Top < -80 || BtnNo.Top > 250)
                BtnNo.Top = 120;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(this);
            newForm.Show();
        }

        private void MdiP_Click(object sender, EventArgs e)
        {
            Form3 newForm3 = new Form3();
            newForm3.Show();
        }
    }
}
