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
    public partial class secenek : Form
    {
        public secenek()
        {
            InitializeComponent();
        }
        public static int secim;

        private void button1_Click(object sender, EventArgs e)
        {
            secim = 1;
            MessageBox.Show("Sabah Seçtiniz");
            this.DialogResult = DialogResult.OK; // DialogResult'ı OK olarak ayarla
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            secim = 2;
            MessageBox.Show("Öğle Seçtiniz");
            this.DialogResult = DialogResult.OK; // DialogResult'ı OK olarak ayarla
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            secim = 3;
            MessageBox.Show("Akşam Seçtiniz");
            this.DialogResult = DialogResult.OK; // DialogResult'ı OK olarak ayarla
            this.Close();
        }
    }
}
