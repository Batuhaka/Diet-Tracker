using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp;
using FireSharp.Interfaces;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Mail;
using YazMüh_Taslak.Controller;

namespace YazMüh_Taslak
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        public void gizle()
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            Kayıt k = new Kayıt();
            k.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GirisKontrol gk = new GirisKontrol();
            bool sonuc = gk.giris(maskedTextBox2.Text, maskedTextBox1.Text);
            if (sonuc==true)
            {
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız");
            }
        }
    }
}
