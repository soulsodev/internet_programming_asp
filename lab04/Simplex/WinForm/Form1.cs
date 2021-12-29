using System;
using System.Windows.Forms;
using WinForm.ServiceReference1;

namespace WinForm
{
    public partial class Form1 : Form
    {
        SimplexSoapClient simplex;

        public Form1()
        {
            InitializeComponent();
            simplex = new SimplexSoapClient();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int k1, k2;
            float f1, f2;

            A a1 = new A();
            A a2 = new A();

            if (int.TryParse(textBox8.Text, out k1) && 
                float.TryParse(textBox9.Text, out f1) && 
                int.TryParse(textBox11.Text, out k2) && 
                float.TryParse(textBox12.Text, out f2))
            {
                a1.s = textBox7.Text;
                a1.k = k1;
                a1.f = f1;

                a2.s = textBox10.Text;
                a2.k = k2;
                a2.f = f2;

                A result = simplex.Sum(a1, a2);
                textBox13.Text = result.s;
                textBox14.Text = result.k.ToString();
                textBox15.Text = result.f.ToString();
            }
            else
            {
                MessageBox.Show("Please, enter correct values.");
            }
        }
    }
}
