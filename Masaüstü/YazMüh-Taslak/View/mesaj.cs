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
using YazMüh_Taslak.Controller;

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
        private List<string[]> veriListesi = new List<string[]>();
        public string isim;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        IliskiKontrol ik = new IliskiKontrol();
        private void mesaj_Load(object sender, EventArgs e)
        {
            int sayac = 0;
            veriListesi= ik.hasta(kullaniciListesi1);
            foreach (var veri in veriListesi)
            {
                sayac++;
                goster(sayac,veri);
                
            }
            
        }
        public void goster(int sayac, string[] veri)
        {
            switch (sayac)
            {
                case 1:
                    panel1.Visible= true;
                    label1.Text = veri[0] + " " + veri[1];
                    break;
                case 2:
                    panel2.Visible = true;
                    label2.Text = veri[0] + " " + veri[1];
                    break;
                case 3:
                    panel3.Visible = true;
                    label3.Text = veri[0] + " " + veri[1];
                    break;
                default:
                    panel4.Visible = true;
                    label4.Text = veri[0] + " " + veri[1];
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
