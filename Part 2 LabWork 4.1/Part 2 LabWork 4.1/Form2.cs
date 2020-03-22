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
    public partial class Form2 : Form
    {
        private Form1 pF;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 f)
        {
            InitializeComponent();
            f.BackColor = Color.Red;
            pF = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 newForm1 = new Form1();
            newForm1.BackColor = Color.Black;
            newForm1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                pF.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Fick keine Form!");
            }
            finally
            {
                Close();
            }
        }
    }
}
