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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CascadeMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                label1.Text = label1.Text + "\n" + frm.Text;
            }
        }

        private void NewMenuItem_Click(object sender, EventArgs e)
        {
            Form4 newChild = new Form4();
            newChild.MdiParent = this;
            newChild.Show();
        }
    }
}
