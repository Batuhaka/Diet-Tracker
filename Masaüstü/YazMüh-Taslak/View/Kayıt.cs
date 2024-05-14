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
using YazMüh_Taslak.Controller;
namespace YazMüh_Taslak
{
    public partial class Kayıt : Form
    {
        public Kayıt()
        {
            InitializeComponent();

        }
        KayıtKontrol kg= new KayıtKontrol();
            
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Image resim = pictureBox1.Image;

            MemoryStream memoryStream = new MemoryStream();
            resim.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);

            byte[] resimBytes = memoryStream.ToArray();

            string base64Resim = Convert.ToBase64String(resimBytes);

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
            o.base64Resim = base64Resim;

            o.Show();
            this.Hide();
            /*bool sonuc=kg.onayyolla(maskedTextBox2.Text, maskedTextBox6.Text, maskedTextBox1.Text, maskedTextBox5.Text,
                maskedTextBox4.Text, maskedTextBox7.Text, maskedTextBox8.Text, comboBox1.Text, comboBox2.Text,
                maskedTextBox11.Text, maskedTextBox3.Text,base64Resim);

            if(sonuc==true)
                this.Hide();*/
        }
        Baglanti bg = new Baglanti();
        private void Kayıt_Load(object sender, EventArgs e)
        {

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
