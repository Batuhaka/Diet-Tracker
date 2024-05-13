using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
namespace YazMüh_Taslak
{
    public partial class besinler : Form
    {

        public besinler()
        {
            InitializeComponent();
            LoadDataFromJson();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public  void LoadDataFromJson()
        {
            try
            {
                // JSON dosyasını oku
                string jsonFilePath = "data.json";
                string jsonData = File.ReadAllText(jsonFilePath);

                // JSON verisini işle
                JsonDocument doc = JsonDocument.Parse(jsonData);
                JsonElement root = doc.RootElement;

                // Tabloyu temizle
                besinlerTablo.Rows.Clear();

                // Her bir besin öğesi için verileri tabloya ekle
                foreach (JsonElement item in root.EnumerateArray())
                {
                    string foodName = item.GetProperty("foodname").GetString();
                    double energy = item.GetProperty("Energy").GetDouble(); // Kalori değeri double türünde
                                                                              // Diğer sütunları da burada ekleyebilirsiniz

                    // Verileri tabloya ekle
                    besinlerTablo.Rows.Add(foodName, energy);
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda mesajı göster
                MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }
        private void icerikTabloDoldur(string foodname)
        {
            try
            {
                // JSON dosyasını oku
                string jsonFilePath = "data.json";
                string jsonData = File.ReadAllText(jsonFilePath);

                // JSON verisini işle
                JsonDocument doc = JsonDocument.Parse(jsonData);
                JsonElement root = doc.RootElement;

                // Seçilen yiyeceği bul
                JsonElement selectedFood = root.EnumerateArray()
                    .FirstOrDefault(item => item.GetProperty("foodname").GetString() == foodname);


                // Diğer bilgileri al
                float energy = selectedFood.GetProperty("Energy").GetSingle();
                float water = selectedFood.GetProperty("Water").GetSingle();
                float sugar = selectedFood.GetProperty("Sugars, total ").GetSingle();
                float calcium = selectedFood.GetProperty("Calcium").GetSingle();
                float iron = selectedFood.GetProperty("Iron").GetSingle();
                float magnesium = selectedFood.GetProperty("Magnesium").GetSingle();
                float potassium = selectedFood.GetProperty("Potassium").GetSingle();
                float sodium = selectedFood.GetProperty("Sodium").GetSingle();
                float protein = selectedFood.GetProperty("Protein").GetSingle();
                float karbonhidrat = selectedFood.GetProperty("Carbohydrate").GetSingle();
                float yag = selectedFood.GetProperty("Total Fat").GetSingle();
                label3.Text = karbonhidrat.ToString();
                label6.Text = protein.ToString();
                label9.Text = yag.ToString();
                if (foodname.Length > 17)
                {
                    label11.Text = foodname.Substring(0, 15) + "...";
                }
                else
                {
                    label11.Text = foodname;
                }
                yuzdehesapla(karbonhidrat, protein, yag);

                // İçerik tablosunu temizle
                icerikTablo.Rows.Clear();

                // Diğer bilgileri içerik tablosuna ekle
                icerikTablo.Rows.Add("Enerji (kcal)", energy);
                icerikTablo.Rows.Add("Su (g)", water);
                icerikTablo.Rows.Add("Şeker (g)", sugar);
                icerikTablo.Rows.Add("Kalsiyum (mg)", calcium);
                icerikTablo.Rows.Add("Demir (mg)", iron);
                icerikTablo.Rows.Add("Magnezyum (mg)", magnesium);
                icerikTablo.Rows.Add("Potasyum (mg)", potassium);
                icerikTablo.Rows.Add("Sodyum (mg)", sodium);
                string imageUrl = selectedFood.GetProperty("URL").GetString();
                // Resmi pictureBox1'e ekle
                pictureBox1.ImageLocation = imageUrl;
                Console.WriteLine(imageUrl);

            }
            catch (Exception ex)
            {
                // Hata durumunda mesajı göster
                MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }
        private void besinlerTablo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            groupBox1.Visible = true;
            SetColumn6HeaderText();
            comboBox2.SelectedIndex = -1;
            string selectedFoodName = besinlerTablo.CurrentRow.Cells["column1"].Value.ToString();
            icerikTabloDoldur(selectedFoodName);
        }
        private void yuzdehesapla(float karbonhidrat, float yag, float protein)
        {
            float toplamEnerji = karbonhidrat + yag + protein;

            // Karbonhidrat, yağ ve proteinin toplam içindeki yüzdesini hesapla
            float karbonhidratYuzde = (karbonhidrat / toplamEnerji) * 100;
            float yagYuzde = (yag / toplamEnerji) * 100;
            float proteinYuzde = (protein / toplamEnerji) * 100;

            // Sonuçları etiketlere yazdır
            label4.Text = string.Format("%{0:F1}", karbonhidratYuzde);
            label8.Text = string.Format("%{0:F1}", yagYuzde);
            label5.Text = string.Format("%{0:F1}", proteinYuzde);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetColumn6HeaderText();
            // Seçilen sayıyı al
            int selectedNumber = Convert.ToInt32(comboBox2.SelectedItem);

            // İçerik tablosundaki tüm satırları döngü ile gez
            foreach (DataGridViewRow row in icerikTablo.Rows)
            {
                // Her satırın column5 değerini al
                float column5Value = Convert.ToSingle(row.Cells["column5"].Value);

                // Seçilen sayıyla column5 değerini çarp ve sonucu column6'ya yaz
                row.Cells["column6"].Value = selectedNumber * column5Value;
            }
        }

        private void SetColumn6HeaderText()
        {
            // comboBox2 ve comboBox1'in seçili metinlerini al
            string comboBox2Text = comboBox2.SelectedItem != null ? comboBox2.SelectedItem.ToString() : comboBox2.Text;
            string comboBox1Text = comboBox1.SelectedItem != null ? comboBox1.SelectedItem.ToString() : comboBox1.Text;

            // Column6'nın başlık metnini oluştur
            string column6HeaderText = comboBox2Text + " " + comboBox1Text;

            // Column6'nın başlık metnini ayarla
            icerikTablo.Columns["column6"].HeaderText = column6HeaderText;
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            string arananKelime = aramaCubugu.text;
            foreach (DataGridViewRow row in besinlerTablo.Rows)
            {
                if (row.Cells["Column1"].Value.ToString().ToLower().Contains(arananKelime))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }

            // DataGridView'i güncelle
            besinlerTablo.Refresh();
        }
        public void aramayap(string aranan)
        {
            aramaCubugu.text = aranan.ToLower();
            bunifuImageButton1_Click(null,null);
            groupBox1.Visible = true;
            icerikTabloDoldur(aranan);
        }
    }
}
