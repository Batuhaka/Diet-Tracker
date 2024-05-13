using Bunifu.Framework.UI;
using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace YazMüh_Taslak
{
    public partial class mesajyaz : Form
    {
        public mesajyaz()
        {
            InitializeComponent();
        }
        public string id;
        public string tc;
        public string name;
        public string isim;
        Baglanti bg = new Baglanti();
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            timer1.Stop();
        }
        void cek()
        {

            try
            {
                FirebaseResponse al3 = bg.baglan().Get("mesaj/" + id + "/" + tc + "/");
                Dictionary<string, message> veri = JsonConvert.DeserializeObject<Dictionary<string, message>>(al3.Body.ToString());

                if (al3.Body != null)
                {
                    flowLayoutPanel1.Controls.Clear();
                    if (veri == null)
                    {
                        MessageBox.Show("buradayim");
                        message m = new message()
                        {
                            alici = id,
                            gonderen = tc,
                            mesaj = "Diyetisyen " + isim,
                            durum = "aktif",
                            tarih = 100
                        };
                        bg.baglan().Push("mesaj/" + id + "/" + tc + "/", m);
                    }
                    else
                    {
                        foreach (var item3 in veri)
                        {

                            Label newLabel = new Label();
                            newLabel.Text = item3.Value.mesaj;
                            if (item3.Value.alici == id)
                            {
                                newLabel.ForeColor = Color.Red;
                                newLabel.TextAlign = ContentAlignment.MiddleRight;
                            }
                            else
                            {
                                newLabel.ForeColor = Color.Blue;
                                newLabel.TextAlign = ContentAlignment.MiddleLeft;
                            }
                            newLabel.AutoSize = false;
                            newLabel.Size = new System.Drawing.Size(510, 45);
                            this.Controls.Add(newLabel);
                            flowLayoutPanel1.Controls.Add(newLabel);
                            flowLayoutPanel1.AutoScrollPosition = new System.Drawing.Point(0, flowLayoutPanel1.VerticalScroll.Maximum);
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

        message ms = new message();

        private void button2_Click(object sender, EventArgs e)
        {
            // Şu anki UTC tarih ve saati al
            DateTime utcNow = DateTime.UtcNow;

            // Unix zaman damgası hesapla (3 saat ileri)
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long timestamp = (long)(utcNow - epoch).TotalSeconds;

            // Mesajı oluştur
            message m = new message()
            {
                alici = id,
                gonderen = tc,
                mesaj = richTextBox1.Text,
                durum = "aktif",
                tarih = timestamp
            };

            // Firebase'a mesajı gönder
            bg.baglan().Push("mesaj/" + id + "/" + tc + "/", m);

            // Mesaj gönderme tarihini consola yazdır (UTC)
            Console.WriteLine("Mesaj gönderilme tarihi (UTC): " + utcNow);

            // Unix zaman damgası olarak tarihi consola yazdır
            Console.WriteLine("Unix zaman damgası: " + timestamp);

            // Mesajları göstermek için cek() metodunu çağır
            cek();

            // RichTextBox'ı temizle
            richTextBox1.Text = "";
        }

        private void mesajyaz_Load(object sender, EventArgs e)
        {

            timer1.Enabled = true;
            timer1.Start();
            saniye = 3;
            label1.Text = name;
            cek();

        }
        int saniye;
        private void timer1_Tick(object sender, EventArgs e)
        {
            saniye--;
            if (saniye == 0)
            {
                cek();
                saniye = 3;
            }

        }
    }
}
