using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Response;
using FireSharp.Config;
using FireSharp;
using FireSharp.Interfaces;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Security.Policy;
using Google.Cloud.Storage.V1;
using System.IO;
namespace YazMüh_Taslak
{
    public partial class Kayıt : Form
    {
        public Kayıt()
        {
            InitializeComponent();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image resim = pictureBox1.Image;

            

            Onay o = new Onay();
            o.ad = maskedTextBox2.Text;
            o.soyad = maskedTextBox6.Text;
            o.tc = maskedTextBox1.Text;
            o.dtarih = maskedTextBox5.Text;
            o.telefon = maskedTextBox4.Text;
            o.mail = maskedTextBox7.Text;
            o.adres = maskedTextBox8.Text;
            o.deneyim = comboBox1.Text;
            o.ucret = comboBox2.Text;
            o.okul = maskedTextBox11.Text;
            o.sifre = maskedTextBox3.Text;
            o.img = resim;
            /*Keys k = new Keys()
            {
                Key = maskedTextBox2.Text,
                Value = maskedTextBox6.Text,
            };
            var yolla = bg.baglan().Set("Keys/" + maskedTextBox6.Text, k);*/
            
            o.Show();
            this.Hide();
        }
        Baglanti bg = new Baglanti();
        private void Kayıt_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Onay o = new Onay();
            o.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Resim Seç"; 
            openFileDialog1.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp"; 
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = openFileDialog1.FileName;

                pictureBox1.Image = Image.FromFile(dosyaYolu);
            }
        }
    }
}
