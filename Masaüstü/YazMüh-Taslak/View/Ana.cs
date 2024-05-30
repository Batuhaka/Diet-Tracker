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
using YazMüh_Taslak.Controller;
using YazMüh_Taslak.View;

namespace YazMüh_Taslak
{
    public partial class Ana : Form
    {
        public string ad;
        public string soyad;
        public string tc;
        public string img;
        public string ucret;
        public Ana()
        {
            InitializeComponent();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public List<string> kullaniciListesi = new List<string>();
        private List<string[]> degerlendirmeListesi = new List<string[]>();
        int puan = 0;
        int degerlendirme=0;
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
            a.kullaniciListesi1 = kullaniciListesi;
            a.Show();
        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            Vki v= new Vki();
            v.Show();
        }

        
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
            IliskiKontrol ik= new IliskiKontrol();
            kullaniciListesi=ik.iliski(tc);
            label10.Text=kullaniciListesi.Count.ToString();
            int kazanc = Convert.ToInt16(ucret);
            int kisi = Convert.ToInt16(label10.Text);
            label11.Text=(kazanc*kisi).ToString();

            DegerlendirmeKontrol dk= new DegerlendirmeKontrol();
            degerlendirmeListesi= dk.degerlendirme(tc);
            foreach(var item in degerlendirmeListesi)
            {
                puan += Convert.ToInt16(item[1]);
                degerlendirme++;

            }
            double oPuan = (puan / degerlendirme);
            switch (oPuan) 
            {
                case double n when (n >= 0 && n < 1):
                    pictureBox3.Visible = true;
                    break;
                case double n when (n >= 1 && n < 2):
                    pictureBox3.Visible = true; pictureBox4.Visible = true;
                    break;
                case double n when (n >= 2 && n < 3):
                    pictureBox3.Visible = true; pictureBox4.Visible = true; pictureBox5.Visible = true;
                    break;
                case double n when (n >= 3 && n < 4):
                    pictureBox3.Visible = true; pictureBox4.Visible = true; pictureBox5.Visible = true;
                    pictureBox6.Visible = true;
                    break;
                case double n when (n >= 4 && n <= 5):
                    pictureBox3.Visible = true; pictureBox4.Visible = true; pictureBox5.Visible = true;
                    pictureBox6.Visible= true;
                    pictureBox7.Visible = true;
                    break;
            }

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
            m.kullaniciListesi1 = kullaniciListesi;
            m.tc = tc;
            m.Show();
        }
        diyetYaz d = new diyetYaz();
        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            d.kullaniciListesi1=kullaniciListesi;
            d.Show();
            d.tc = tc;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Yorum y = new Yorum();
            y.yorumListesi = degerlendirmeListesi;
            y.tc = tc;
            y.Show();
        }

        private void bunifuTileButton6_Click(object sender, EventArgs e)
        {
            listeGor lg = new listeGor();
            lg.kullaniciListesi1 = kullaniciListesi;
            lg.tc = tc;
            lg.Show();
        }
    }
}
