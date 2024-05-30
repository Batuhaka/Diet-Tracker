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
    public partial class Yorum : Form
    {
        public Yorum()
        {
            InitializeComponent();
        }
        public string tc;
        public List<string[]> yorumListesi = new List<string[]>();
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Yorum_Load(object sender, EventArgs e)
        {
            DegerlendirmeKontrol dk= new DegerlendirmeKontrol();
            bunifuCustomDataGrid1.Rows.Clear();
            bunifuCustomDataGrid1.Columns.Clear();
            bunifuCustomDataGrid1.Columns.Add("Name", "Ad");
            bunifuCustomDataGrid1.Columns.Add("LastName", "Soyad");
            bunifuCustomDataGrid1.Columns.Add("Puan", "Puan");
            bunifuCustomDataGrid1.Columns.Add("Yorum", "Yorum");

            /*DataGridViewButtonColumn butonSutunu = new DataGridViewButtonColumn();
            butonSutunu.HeaderText = "İşlem";
            butonSutunu.Name = "islem";
            butonSutunu.Text = "Görüntüle"; // Butonun metni
            butonSutunu.FlatStyle = FlatStyle.Flat;
            butonSutunu.DefaultCellStyle.BackColor = Color.FromArgb(126, 216, 84);
            butonSutunu.DefaultCellStyle.ForeColor = Color.White;


            butonSutunu.UseColumnTextForButtonValue = true; // Butonun her hücrede aynı metni göstermesi
            bunifuCustomDataGrid1.Columns.Add(butonSutunu);*/
            //bunifuCustomDataGrid1.CellContentClick += BunifuCustomDataGrid1_CellContentClick;
            if (yorumListesi != null)
            {
                foreach (var veri in yorumListesi)
                {
                    bunifuCustomDataGrid1.Rows.Add(veri[0], "soyad", veri[1], veri[2]);
                }
            }
            else
                MessageBox.Show("yorum bulunamadı");
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0) // Geçerli bir hücre tıklaması olduğundan emin olun
            {
                DataGridViewColumn seciliSutun = bunifuCustomDataGrid1.Columns[e.ColumnIndex];


                    string yorum = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Yorum"].Value.ToString();
                    /*string seciliLastName = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
                    string seciliAge = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Age"].Value.ToString();
                    string seciliKilo = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Kilo"].Value.ToString();
                    string seciliBoy = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Boy"].Value.ToString();
                    string seciliBmi = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Bmi"].Value.ToString();*/

                    MessageBox.Show(yorum);

            }
        }
    }
}
