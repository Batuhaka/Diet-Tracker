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
        private void button1_Click(object sender, EventArgs e)
        {

            bunifuCustomDataGrid1.Rows.Clear();
            bunifuCustomDataGrid1.Columns.Clear();
            bunifuCustomDataGrid1.Columns.Add("Name", "Ad");
            bunifuCustomDataGrid1.Columns.Add("LastName", "Soyad");
            bunifuCustomDataGrid1.Columns.Add("Age", "Yaş");
            bunifuCustomDataGrid1.Columns.Add("Mail", "Mail");
            DataGridViewButtonColumn butonSutunu = new DataGridViewButtonColumn();
            butonSutunu.HeaderText = "İşlem";
            butonSutunu.Name = "islem";
            butonSutunu.Text = "Görüntüle"; // Butonun metni
            butonSutunu.FlatStyle=FlatStyle.Flat;
            butonSutunu.DefaultCellStyle.BackColor = Color.FromArgb(126, 216, 84);
            butonSutunu.DefaultCellStyle.ForeColor = Color.White;
           
            
            butonSutunu.UseColumnTextForButtonValue = true; // Butonun her hücrede aynı metni göstermesi
            bunifuCustomDataGrid1.Columns.Add(butonSutunu);
            bunifuCustomDataGrid1.CellContentClick += BunifuCustomDataGrid1_CellContentClick;


            /*try
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

                                try
                                {
                                    FirebaseResponse al3 = bg.baglan().Get("users/");
                                    Dictionary<string, Users> veri = JsonConvert.DeserializeObject<Dictionary<string, Users>>(al3.Body.ToString());

                                    if (al3.Body != null)
                                    {
                                        foreach (var item3 in veri)
                                        {
                                            for (int i = 0; i < kullaniciListesi1.Count; i++)
                                            {
                                                if (item3.Key == kullaniciListesi1[i])
                                                {
                                                    bunifuCustomDataGrid1.Rows.Add(item3.Value.name, item3.Value.lastname, item3.Value.age, item3.Value.email);
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
            }*/



            try
            {
                FirebaseResponse al3 = bg.baglan().Get("users/");
                Dictionary<string, Users> veri = JsonConvert.DeserializeObject<Dictionary<string, Users>>(al3.Body.ToString());

                if (al3.Body != null)
                {
                    foreach (var item3 in veri)
                    {
                        for (int i = 0; i < kullaniciListesi1.Count; i++)
                        {
                            if (item3.Key == kullaniciListesi1[i])
                            {
                                bunifuCustomDataGrid1.Rows.Add(item3.Value.name, item3.Value.lastname, item3.Value.age, item3.Value.email);
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
                    string seciliMail = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Mail"].Value.ToString();

                    MessageBox.Show("Düzenleme işlemi için seçili veri: " + seciliName + " " + seciliLastName + ", " + seciliAge + ", " + seciliMail);
                }
            }
        }
    }
}
