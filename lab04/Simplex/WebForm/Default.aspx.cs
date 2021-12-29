using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class Default : System.Web.UI.Page
    {
        Simplex.Simplex simplex;
        protected void Page_Load(object sender, EventArgs e)
        {
            simplex = new Simplex.Simplex();
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            int x, y;
            if (int.TryParse(textX.Text, out x) && int.TryParse(textY.Text, out y))
            {
                textAddResponse.Text = simplex.Add(x, y).ToString();
            }
            else
            {
                textAddResponse.Text = "Error!";
            }
        }

        protected void Concat_Click(object sender, EventArgs e)
        {
            double d;
            if (double.TryParse(textD.Text, out d))
            {
                textConcatResponse.Text = simplex.Concat(textS.Text, d);
            }
            else
            {
                textConcatResponse.Text = "Error!";
            }
        }

        protected void Sum_Click(object sender, EventArgs e)
        {
            int k1, k2;
            float f1, f2;
            var a1 = new Simplex.A();
            var a2 = new Simplex.A();

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
                textSumResponse.Text = "Error!";
            }
        }
    }
}