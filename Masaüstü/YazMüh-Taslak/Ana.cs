using Bunifu.Framework.UI;
using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazMüh_Taslak
{
    public partial class Ana : Form
    {
        public string ad;
        public string soyad;
        public string tc;
        public string img;
        public Ana()
        {
            InitializeComponent();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Region = new Region(path);
        }
        hastalarım a = new hastalarım();
        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            a.tc = tc;
            a.Show();
        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            Vki v= new Vki();
            v.Show();
        }
        Baglanti bg= new Baglanti();
        public List<string> kullaniciListesi = new List<string>();
        
        private void Ana_Load(object sender, EventArgs e)
        {
            label4.Text = ad;
            label5.Text=soyad;
            label6.Text=tc;
            byte[] resimBytes = Convert.FromBase64String(img);

            // Byte dizisini resme dönüştür ve PictureBox'ta görüntüle
            using (MemoryStream memoryStream = new MemoryStream(resimBytes))
            {
                Image resim = Image.FromStream(memoryStream);
                pictureBox1.Image = resim;
            }

            try
            {
                FirebaseResponse al = bg.baglan().Get("relationships/");
                Dictionary<string, relationship> veri1 = JsonConvert.DeserializeObject<Dictionary<string, relationship>>(al.Body.ToString());


                if (al.Body != null)
                {
                    foreach (var item in veri1)
                    {

                        if (item.Key == tc)
                        {

                            FirebaseResponse al2 = bg.baglan().Get("relationships/" + item.Key + "/");
                            Dictionary<string, relationship> veri2 = JsonConvert.DeserializeObject<Dictionary<string, relationship>>(al2.Body.ToString());
                            foreach (var item2 in veri2)
                            {
                                kullaniciListesi.Add(item2.Key.ToString());
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

            
            m.kullaniciListesi1.AddRange(kullaniciListesi);
            a.kullaniciListesi1.AddRange(kullaniciListesi);
            d.kullaniciListesi1.AddRange(kullaniciListesi);

        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            besinler besin  = new besinler();
            besin.Show();
        }
        mesaj m = new mesaj();
        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {
            m.isim = label4.Text + " " + label5.Text;
            m.tc = tc;
            m.Show();
        }
        diyetYaz d = new diyetYaz();
        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            d.Show();
            d.tc = tc;
        }
    }
}
