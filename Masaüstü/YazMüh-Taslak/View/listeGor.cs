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

namespace YazMüh_Taslak.View
{
    public partial class listeGor : Form
    {
        public listeGor()
        {
            InitializeComponent();
        }
        public List<string> kullaniciListesi1 = new List<string>();
        private List<string[]> veriListesi = new List<string[]>();
        public string isim;
        public string id;
        public string numara;
        private List<string[]> diyetListesi = new List<string[]>();
        public List<string> kaloriListesi = new List<string>();

        public string tc;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        IliskiKontrol ik = new IliskiKontrol();
        listeKontrol lk = new listeKontrol();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            isim = comboBox1.SelectedItem.ToString();
            id = ik.idGonder(veriListesi, isim);
            int listeNo = lk.ListeNoAyarla(id);//ne kadar listesi varsa o kadar gözükmesini ayarlıyor
            comboBox2.Items.Clear();
            for (int i = 1; i <= listeNo; i++)
            {
                comboBox2.Items.Add(i.ToString());
            }
        }

        private void listeGor_Load(object sender, EventArgs e)
        {

            veriListesi = ik.hasta(kullaniciListesi1);
            foreach (var item in veriListesi)
            {
                comboBox1.Items.Add(item[0] + " " + item[1]);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            numara = comboBox2.SelectedItem.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            kaloriListesi.Clear();
            diyetListesi = lk.listeGonder(id, tc, "aksam", numara);
            if (diyetListesi == null)
            {
                MessageBox.Show("Belirtilen Liste Bulunamadı");
            }
            else
            {
                foreach (var item in diyetListesi)
                {
                    listBox3.Items.Add(item[0]);
                    listBox3.Items.Add("Adet: " + item[1]);
                }
                diyetListesi.Clear();

                diyetListesi = lk.listeGonder(id, tc, "ogle", numara);
                foreach (var item in diyetListesi)
                {
                    listBox2.Items.Add(item[0]);
                    listBox2.Items.Add("Adet: " + item[1]);
                }
                diyetListesi.Clear();

                diyetListesi = lk.listeGonder(id, tc, "sabah", numara);
                foreach (var item in diyetListesi)
                {     
                    listBox1.Items.Add(item[0]);
                    listBox1.Items.Add("Adet: " + item[1]);
                }
                diyetListesi.Clear();

                kaloriListesi =lk.kaloriGonder(id, tc, numara);
                label9.Text = kaloriListesi[0];
                label7.Text = kaloriListesi[1];
                
            }
        }
        
    }
}
