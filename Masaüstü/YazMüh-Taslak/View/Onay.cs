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
using YazMüh_Taslak.Controller;

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
        public string base64Resim;
        public Onay()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        KayıtKontrol kg= new KayıtKontrol();
        private void button1_Click(object sender, EventArgs e)
        {
            bool sonuc=kg.onay(textBox1.Text,ad,soyad,tc,dtarih,telefon,mail,adres,deneyim,ucret,okul,sifre,base64Resim);
            if (sonuc == true)
                this.Hide();
        }


        private void Onay_Load(object sender, EventArgs e)
        {
            
        }
    }
}
