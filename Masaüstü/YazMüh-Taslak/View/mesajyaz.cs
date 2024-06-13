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
using YazMüh_Taslak.Controller;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace YazMüh_Taslak
{
    public partial class mesajyaz : Form
    {
        public mesajyaz()
        {
            this.KeyPreview = true; // KeyPreview özelliğini true olarak ayarla

            InitializeComponent();
        }
        public string id;
        public string tc;
        public string name;
        public string isim;
        Baglanti bg = new Baglanti();
        private List<string[]> mesajListesi = new List<string[]>();
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            timer1.Stop();
        }
        void cek()
        {
            flowLayoutPanel1.Controls.Clear();

            mesajListesi = mk.cek(id, tc, isim);

            foreach (var veri2 in mesajListesi)
            {
                Label newLabel = new Label();
                newLabel.Text = veri2[0];
                if (veri2[1] == id)
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

        message ms = new message();

        private void button2_Click(object sender, EventArgs e)
        {
            // Şu anki UTC tarih ve saati al
            mk.yaz(id, tc, richTextBox1.Text);

            cek();

            richTextBox1.Text = "";
        }
        MesajKontrol mk= new MesajKontrol();
        private void mesajyaz_Load(object sender, EventArgs e)
        {
            String[] veri;
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

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                // Enter tuşuna basıldığında butonun tıklama olayını tetikle
                button2.PerformClick();
            }
        }
    }
}
