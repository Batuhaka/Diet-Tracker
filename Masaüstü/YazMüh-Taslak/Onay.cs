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
using System.IO;

namespace YazMüh_Taslak
{
    public partial class Onay : Form
    {
        public string ad;
        public string soyad;
        public string tc;
        public string dtarih;
        public string telefon;
        public string mail;
        public string adres;
        public string deneyim;
        public string ucret;
        public string okul;
        public string sifre;
        public Image img;
        public Onay()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Baglanti bg= new Baglanti();
        Bilgi b = new Bilgi();
        private void button1_Click(object sender, EventArgs e)
        {
            MemoryStream memoryStream = new MemoryStream();
            img.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);

            byte[] resimBytes = memoryStream.ToArray();

            string base64Resim = Convert.ToBase64String(resimBytes);

            Bilgi bilgi = new Bilgi()
            {
                ad = ad,
                soyad = soyad,
                tc = tc,
                dtarih = dtarih,
                telefon = telefon,
                mail = mail,
                adres = adres,
                deneyim = deneyim,
                ucret = ucret,
                okul = okul,
                sifre = sifre,
                base64resim = base64Resim
            };

            try
            {
                FirebaseResponse al = bg.baglan().Get("Keys/");
                Dictionary<string, Keys> veri = JsonConvert.DeserializeObject<Dictionary<string, Keys>>(al.Body.ToString());


                // Check if data exists and parse it
                if (al.Body != null)
                {
                    foreach (var item in veri)
                    {
                        while (item.Key == textBox1.Text)
                        {
                            if (item.Value.Key == textBox1.Text)
                            {
                                
                                var yolla = bg.baglan().Set("bilgitbl/" + tc, bilgi);
                                var sil = bg.baglan().Delete("Keys/"+textBox1.Text);
                                MessageBox.Show("Kayıt Başarılı");
                                Giris g = new Giris();
                                g.Show();
                                this.Hide();
                                break;
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


        private void Onay_Load(object sender, EventArgs e)
        {
            
        }
    }
}
