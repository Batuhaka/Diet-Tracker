using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazMüh_Taslak
{
    public partial class Vki : Form
    {
        public Vki()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double kilo = Convert.ToDouble(textBox2.Text);
            double boy = Convert.ToDouble(textBox1.Text)/100;
            double vki = kilo/ (boy * boy);
            MessageBox.Show(vki.ToString());

            if (vki < 18.5)
            {
                progressBar1.Value = 7;
                label4.Text = (vki.ToString() + "--->" + "Zayıf");
            }
            else if (vki < 24.9)
            {
                progressBar1.Value = 15;
                label4.Text = (vki.ToString() + "--->" + "Normal");
            }
            else if (vki < 29.9)
            {
                progressBar1.Value = 23;
                label4.Text = (vki.ToString() + "--->" + "Fazla Kilolu");
            }
            else if (vki < 39.9)
            {
                progressBar1.Value = 31;
                label4.Text = (vki.ToString() + "--->" + "Obez");
            }
            else
            {
                progressBar1.Value = 40;
                label4.Text = (vki.ToString() + "--->" + "Aşırı Obez");
            }

        }

        private void Vki_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 40;
            progressBar1.Minimum = 0;
            progressBar1.Value= 0;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
