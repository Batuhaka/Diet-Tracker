using Bunifu.Framework.UI;
using FireSharp.Response;
using Newtonsoft.Json;
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
    public partial class mesaj : Form
    {
        public string tc;
        public mesaj()
        {
            InitializeComponent();
        }
        Baglanti bg = new Baglanti();
        public List<string> kullaniciListesi1 = new List<string>();
        public string isim;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void mesaj_Load(object sender, EventArgs e)
        {
            int sayac = 0;

            try
            {
                FirebaseResponse al3 = bg.baglan().Get("users/");
                Dictionary<string, Users> veri = JsonConvert.DeserializeObject<Dictionary<string, Users>>(al3.Body.ToString());

                if (al3.Body != null)
                {
                    foreach (var item3 in veri)
                    {
                        for (int i = 0; i < kullaniciListesi1.Count; i++)
                        {
                            if (item3.Key == kullaniciListesi1[i])
                            {
                                sayac++;
                                goster(sayac);
                                switch (sayac)
                                {
                                    case 1:
                                        
                                        label1.Text = item3.Value.name +" "+ item3.Value.lastname;
                                        break;
                                    case 2:
                                        label2.Text = item3.Value.name + " " + item3.Value.lastname;
                                        break;
                                    case 3:
                                        label3.Text = item3.Value.name + " " + item3.Value.lastname;
                                        break;
                                    default:
                                        label4.Text = item3.Value.name + " " + item3.Value.lastname;
                                        break;
                                }

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
        void goster(int sayac)
        {
            switch (sayac)
            {
                case 1:
                    panel1.Visible= true;
                    break;
                case 2:
                    panel2.Visible = true;
                    break;
                case 3:
                    panel3.Visible = true;
                    break;
                default:
                    panel4.Visible = true;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mesajyaz my = new mesajyaz();
            my.id = kullaniciListesi1[0];
            my.name = label1.Text;
            my.tc = tc;
            my.isim = isim;
            my.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mesajyaz my = new mesajyaz();
            my.id = kullaniciListesi1[1];
            my.tc = tc;
            my.name = label2.Text;
            my.isim = isim;
            my.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mesajyaz my = new mesajyaz();
            my.id = kullaniciListesi1[2];
            my.tc = tc;
            my.name = label3.Text;
            my.isim = isim;
            my.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mesajyaz my = new mesajyaz();
            my.id = kullaniciListesi1[3];
            my.tc = tc;
            my.name = label4.Text;
            my.isim = isim;
            my.Show();
        }
    }
}
