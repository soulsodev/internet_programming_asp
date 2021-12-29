using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm2
{
    public partial class Form1 : Form
    {
        Simplex simplex;

        public Form1()
        {
            simplex = new Simplex();
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int x, y;
            if (int.TryParse(textX.Text, out x) && int.TryParse(textY.Text, out y))
            {
                textAddResponse.Text = simplex.Add(x, y).ToString();
            }
            else
            {
                MessageBox.Show("Please, enter Int values.");
            }
        }

        private void buttonConcat_Click(object sender, EventArgs e)
        {
            double d;
            if (double.TryParse(textD.Text, out d))
            {
                textConcatResponse.Text = simplex.Concat(textS.Text, d);
            }
            else
            {
                MessageBox.Show("Please, enter Double value to D.");
            }
        }

        private void buttonSum_Click(object sender, EventArgs e)
        {
            int k1, k2;
            float f1, f2;
            var a1 = new A();
            var a2 = new A();

            if (int.TryParse(textA1K.Text, out k1) && float.TryParse(textA1F.Text, out f1)
            && int.TryParse(textA2K.Text, out k2) && float.TryParse(textA2F.Text, out f2))
            {
                a1.s = textA1S.Text;
                a1.k = k1;
                a1.f = f1;

                a2.s = textA2S.Text;
                a2.k = k2;
                a2.f = f2;

                var result = simplex.Sum(a1, a2);
                textSumResponse.Text = result.s + " " + result.k + " " + result.f;
            }
            else
            {
                MessageBox.Show("Please, enter correct values.");
            }
        }
    }
}
