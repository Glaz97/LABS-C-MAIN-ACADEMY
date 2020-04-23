using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Simple_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Lft = "";
        string op = "";
        string Rht = "";
        ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();

        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement c in LayoutRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string s = (string)((Button)e.OriginalSource).Content;
                textBlock.Text += s;               

                int num;
                bool result = Int32.TryParse(s, out num);
                if (result == true)
                {
                    if (op == "")
                    {
                        Lft += s;
                    }
                    else
                    {
                        Rht += s;
                    }
                }

                else
                {
                    if (s == "=")
                    {
                        Update_RightOp();
                        textBlock.Text += Rht;
                        op = "";
                    }

                    else if (s == "CLEAR")
                    {
                        Lft = "";
                        Rht = "";
                        op = "";
                        textBlock.Text = "";                      
                    }

                    else
                    {
                        if (Rht != "")
                        {
                            Update_RightOp();
                            Lft = Rht;
                            Rht = "";
                            if ((s=="*")|(s == "/"))
                            {
                                string lastSymb = textBlock.Text.Substring(textBlock.Text.Length-1);
                                string beginStr = textBlock.Text.Substring(0, textBlock.Text.Length-1);
                                textBlock.Text = "(" + beginStr + ")"+ lastSymb;
                            }
                        }
                        op = s;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Update_RightOp()
        {
            try
            {
                int nmb1 = Int32.Parse(Lft);
                int nmb2 = Int32.Parse(Rht);

                switch (op)
                {
                    case "+":                       
                        Rht = proxy.add(nmb1, nmb2).ToString();
                        break;
                    case "-":
                        Rht = proxy.Sub(nmb1, nmb2).ToString();
                        break;
                    case "*":
                        Rht = proxy.Mul(nmb1, nmb2).ToString();
                        break;
                    case "/":
                        Rht = proxy.Div(nmb1, nmb2).ToString();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
