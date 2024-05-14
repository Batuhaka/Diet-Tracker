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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace YazMüh_Taslak
{
    public partial class hastalarım : Form
    {
        public hastalarım()
        {
            InitializeComponent();
        }
        public string tc;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        Baglanti bg = new Baglanti();
        public List<string> kullaniciListesi1 = new List<string>();
        private List<string[]> veriListesi = new List<string[]>();

        private void button1_Click(object sender, EventArgs e)
        {
            IliskiKontrol ik = new IliskiKontrol();

            bunifuCustomDataGrid1.Rows.Clear();
            bunifuCustomDataGrid1.Columns.Clear();
            bunifuCustomDataGrid1.Columns.Add("Name", "Ad");
            bunifuCustomDataGrid1.Columns.Add("LastName", "Soyad");
            bunifuCustomDataGrid1.Columns.Add("Age", "Yaş");
            bunifuCustomDataGrid1.Columns.Add("Kilo", "Kilo");
            bunifuCustomDataGrid1.Columns.Add("Boy", "Boy");
            bunifuCustomDataGrid1.Columns.Add("Bmi", "Bmi");
            DataGridViewButtonColumn butonSutunu = new DataGridViewButtonColumn();
            butonSutunu.HeaderText = "İşlem";
            butonSutunu.Name = "islem";
            butonSutunu.Text = "Görüntüle"; // Butonun metni
            butonSutunu.FlatStyle = FlatStyle.Flat;
            butonSutunu.DefaultCellStyle.BackColor = Color.FromArgb(126, 216, 84);
            butonSutunu.DefaultCellStyle.ForeColor = Color.White;


            butonSutunu.UseColumnTextForButtonValue = true; // Butonun her hücrede aynı metni göstermesi
            bunifuCustomDataGrid1.Columns.Add(butonSutunu);
            bunifuCustomDataGrid1.CellContentClick += BunifuCustomDataGrid1_CellContentClick;
            veriListesi= ik.hasta(kullaniciListesi1);
            foreach (var veri in veriListesi)
            {
                bunifuCustomDataGrid1.Rows.Add(veri[0], veri[1] ,veri[2] , veri[3] , veri[4] , veri[5]);
            }
            

        }


        private void BunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0) // Geçerli bir hücre tıklaması olduğundan emin olun
            {
                DataGridViewColumn seciliSutun = bunifuCustomDataGrid1.Columns[e.ColumnIndex];

                if (seciliSutun.Name == "islem") // Burada "İşlem" sütununun adını doğrulayın
                {
                    string seciliName = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                    string seciliLastName = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
                    string seciliAge = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Age"].Value.ToString();
                    string seciliKilo = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Kilo"].Value.ToString();
                    string seciliBoy = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Boy"].Value.ToString();
                    string seciliBmi = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Bmi"].Value.ToString();

                    MessageBox.Show(seciliName + " " + seciliLastName + ", " + seciliAge + ", " + seciliBoy +
                        ", " + seciliKilo + ", " + seciliBmi);
                }
            }
        }
    }
}
