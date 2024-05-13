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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Baglanti bg = new Baglanti();
        private void button2_Click(object sender, EventArgs e)
        {
            Kayıt k = new Kayıt();
            k.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                FirebaseResponse al = bg.baglan().Get("bilgitbl/");
                Dictionary<string, Bilgi> veri = JsonConvert.DeserializeObject<Dictionary<string, Bilgi>>(al.Body.ToString());


                // Check if data exists and parse it
                if (al.Body != null)
                {
                    foreach (var item in veri)
                    {
                        while (item.Key == maskedTextBox2.Text)
                        {
                            if (item.Value.sifre == maskedTextBox1.Text)
                            {
                                Ana a = new Ana();
                                a.ad = item.Value.ad;
                                a.soyad = item.Value.soyad;
                                a.tc = item.Value.tc;
                                a.img = item.Value.base64resim;
                                a.Show();
                                this.Hide();
                                break;
                            }
                            else
                            {
                                MessageBox.Show("başarısız");
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Kullanıcı bulunamadı");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giriş Başarısız: " + ex.Message);
            }
        }
    }
}
