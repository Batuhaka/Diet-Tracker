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
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using System.IO;
using static System.Windows.Forms.LinkLabel;

namespace YazMüh_Taslak
{
    public partial class mesaj : Form
    {
        private resimKontrol resimKontrol;
        public string tc;
        int sayac = 0;
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
            veriListesi= ik.hasta(kullaniciListesi1);
            foreach (var veri in veriListesi)
            {
 
                if (sayac != 4)
                {
                    sayac++;
                    goster(sayac, veri);
                }
                
            }

            
        }
        public void goster(int sayac, string[] veri)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string folderPath = Path.Combine(currentDirectory, "Png");

            
            
            switch (sayac)
            {
                case 1:
                    panel1.Visible= true;
                    resimyukle(kullaniciListesi1[0]);
                    label1.Text = veri[0] + " " + veri[1];
                    string resimYolu = Path.Combine(folderPath, "{replace2}.png");
                    string newLink2 = resimYolu.Replace("{replace2}", kullaniciListesi1[0].ToString());
                    pictureBox1.Image = Image.FromFile(newLink2);
                    break;
                case 2:
                    panel2.Visible = true;
                    resimyukle(kullaniciListesi1[1]);
                    label2.Text = veri[0] + " " + veri[1];
                    string resimYolu1 = Path.Combine(folderPath, "{replace2}.png");
                    string newLink3 = resimYolu1.Replace("{replace2}", kullaniciListesi1[1].ToString());
                    pictureBox3.Image = Image.FromFile(newLink3);
                    break;
                case 3:
                    panel3.Visible = true;
                    label3.Text = veri[0] + " " + veri[1];
                    resimyukle(kullaniciListesi1[2]);
                    string resimYolu2 = Path.Combine(folderPath, "{replace2}.png");
                    string newLink4 = resimYolu2.Replace("{replace2}", kullaniciListesi1[2].ToString());
                    pictureBox4.Image = Image.FromFile(newLink4);
                    break;
                default:
                    panel4.Visible = true;
                    label4.Text = veri[0] + " " + veri[1];
                    resimyukle(kullaniciListesi1[3]);
                    string resimYolu3 = Path.Combine(folderPath, "{replace2}.png");
                    string newLink5 = resimYolu3.Replace("{replace2}", kullaniciListesi1[3].ToString());
                    pictureBox5.Image = Image.FromFile(newLink5);
                    break;
            }

        }

        public void goster2(int sayac, string[] veri)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string folderPath = Path.Combine(currentDirectory, "Png");

            /*string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = Path.Combine(desktopPath, "YeniKlasor5");*/

            switch (sayac)
            {
                case 4:
                    panel5.Visible = true;
                    resimyukle(kullaniciListesi1[4]);
                    label5.Text = veri[0] + " " + veri[1];
                    string resimYolu = Path.Combine(folderPath, "{replace2}.png");
                    string newLink2 = resimYolu.Replace("{replace2}", kullaniciListesi1[4].ToString());
                    pictureBox8.Image = Image.FromFile(newLink2);
                    break;
                case 5:
                    panel6.Visible = true;
                    resimyukle(kullaniciListesi1[5]);
                    label6.Text = veri[0] + " " + veri[1];
                    string resimYolu1 = Path.Combine(folderPath, "{replace2}.png");
                    string newLink3 = resimYolu1.Replace("{replace2}", kullaniciListesi1[5].ToString());
                    pictureBox9.Image = Image.FromFile(newLink3);
                    break;
                case 6:
                    panel7.Visible = true;
                    label7.Text = veri[0] + " " + veri[1];
                    resimyukle(kullaniciListesi1[6]);
                    string resimYolu2 = Path.Combine(folderPath, "{replace2}.png");
                    string newLink4 = resimYolu2.Replace("{replace2}", kullaniciListesi1[6].ToString());
                    pictureBox10.Image = Image.FromFile(newLink4);
                    break;
                default:
                    panel8.Visible = true;
                    label8.Text = veri[0] + " " + veri[1];
                    resimyukle(kullaniciListesi1[7]);
                    string resimYolu3 = Path.Combine(folderPath, "{replace2}.png");
                    string newLink5 = resimYolu3.Replace("{replace2}", kullaniciListesi1[7].ToString());
                    pictureBox11.Image = Image.FromFile(newLink5);
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

        private void resimyukle(string id)
        {
            resimKontrol storageHelper = new resimKontrol();
            string currentDirectory = Directory.GetCurrentDirectory();
            string folderPath = Path.Combine(currentDirectory, "Png");
            string filePath = Path.Combine(folderPath, "{replace2}.png");

            string pngPath = "profile_images/{replace}.jpg";
            string placeholder = id;
            string newLink = pngPath.Replace("{replace}", placeholder);
            string newLink2 = filePath.Replace("{replace2}", placeholder);
            storageHelper.DownloadImage("diet-tracker10.appspot.com", newLink, newLink2);
        }


        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panel1.Visible= false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            sayac = 0;
            veriListesi = ik.hasta(kullaniciListesi1);
            foreach (var veri in veriListesi)
            {
                if (sayac >= 4 && sayac<kullaniciListesi1.Count)
                {
                    goster2(sayac, veri);
                }
                sayac++;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            mesajyaz my = new mesajyaz();
            my.id = kullaniciListesi1[4];
            my.name = label5.Text;
            my.tc = tc;
            my.isim = isim;
            my.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mesajyaz my = new mesajyaz();
            my.id = kullaniciListesi1[5];
            my.name = label6.Text;
            my.tc = tc;
            my.isim = isim;
            my.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            mesajyaz my = new mesajyaz();
            my.id = kullaniciListesi1[6];
            my.name = label7.Text;
            my.tc = tc;
            my.isim = isim;
            my.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            mesajyaz my = new mesajyaz();
            my.id = kullaniciListesi1[7];
            my.name = label8.Text;
            my.tc = tc;
            my.isim = isim;
            my.Show();
        }


    }
}
