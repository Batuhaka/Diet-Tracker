using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using FireSharp.Response;
using Newtonsoft.Json;
using Microsoft.VisualBasic.ApplicationServices;
using Bunifu.Framework.UI;
using System.Drawing.Text;

namespace YazMüh_Taslak
{
    public partial class diyetYaz : Form
    {
        public List<string> kullaniciListesi1 { get; set; } // kullaniciListesi1 özelliği

        public diyetYaz()
        {
            InitializeComponent();
            LoadDataFromJson();
            kullaniciListesi1 = new List<string>(); // Özelliği başlat
        }
        Baglanti bg = new Baglanti();
        public string tc;
        private void LoadDataFromJson()
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
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        List<Liste> sabahListesi = new List<Liste>();
        List<Liste> ogleListesi = new List<Liste>();
        List<Liste> aksamListesi = new List<Liste>();
        private void toplamKaloriHesapla()
        {
            double toplamKalori = 0;
            foreach (Liste item in sabahListesi) { toplamKalori += item.Kalori * item.Adet; }
            foreach (Liste item in ogleListesi) { toplamKalori += item.Kalori * item.Adet; }
            foreach (Liste item in aksamListesi) { toplamKalori += item.Kalori * item.Adet; }
            label5.Text = toplamKalori.ToString();

        }
        private void besinlerTablo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0) // 3. sütun ve satır kontrolü
            {
                // Butona tıklanıldığında yapılacak işlemler
                string column1Value = besinlerTablo.Rows[e.RowIndex].Cells["column1"].Value.ToString();
                // Başka formu açma ve veriyi iletimi
                besinler besinler = new besinler();
                besinler.Show();
                besinler.aramayap(column1Value); // column1 değerini diğer forma iletiyoruz
            }
            if (e.ColumnIndex == 3 && e.RowIndex >= 0) // 3. sütun ve satır kontrolü
            {
                secenek secenek = new secenek();

                // secenek formunu modal olarak göster ve FormClosed olayını dinle
                secenek.FormClosed += (s, args) =>
                {
                    secenek secenekk = (secenek)s;

                    // Kullanıcı işlemi iptal etmediyse devam edin
                    if (secenekk.DialogResult == DialogResult.OK)
                    {
                        // secenek formundan secim değerini al
                        int secim = secenek.secim;
                        // Diğer işlemleri yapabilirsiniz
                        string column1Value = besinlerTablo.Rows[e.RowIndex].Cells["column1"].Value.ToString();
                        double kalori = Convert.ToDouble(besinlerTablo.Rows[e.RowIndex].Cells["column2"].Value);
                        ListBox[] listBoxes = { listBox1, listBox2, listBox3 };
                        Liste yeniYiyecek = new Liste(column1Value, secim, kalori);

                        List<Liste> hedefListe;
                        if (secim == 1)
                            hedefListe = sabahListesi;
                        else if (secim == 2)
                            hedefListe = ogleListesi;
                        else
                            hedefListe = aksamListesi;

                        if (hedefListe.Any(item => item.YiyecekAdi == yeniYiyecek.YiyecekAdi))
                        {
                            Liste mevcutYiyecek = hedefListe.FirstOrDefault(item => item.YiyecekAdi == yeniYiyecek.YiyecekAdi);
                            if (mevcutYiyecek != null)
                            {
                                mevcutYiyecek.AdetArttir();
                                // Listedeki öğeyi güncelle
                                listBoxes[secim - 1].Items.Clear();
                                foreach (Liste yiyecek in hedefListe)
                                {
                                    listBoxes[secim - 1].Items.Add(yiyecek.Adet + " " + yiyecek.YiyecekAdi);
                                }
                                listBoxes[secim - 1].Refresh();
                            }
                        }
                        else
                        {
                            hedefListe.Add(yeniYiyecek);
                            listBoxes[secim - 1].Items.Add(yeniYiyecek.Adet + " " + column1Value);
                            listBoxes[secim - 1].Refresh(); // listBox'ı yeniden çizmek için
                        }
                    }
                };
                secenek.ShowDialog();
            }
            toplamKaloriHesapla();
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                // listBox1 seçili bir öğe içeriyorsa, diğer listBox'ları temizle
                listBox2.ClearSelected();
                listBox3.ClearSelected();
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                // listBox2 seçili bir öğe içeriyorsa, diğer listBox'ları temizle
                listBox1.ClearSelected();
                listBox3.ClearSelected();
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex != -1)
            {
                // listBox3 seçili bir öğe içeriyorsa, diğer listBox'ları temizle
                listBox1.ClearSelected();
                listBox2.ClearSelected();
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            string selectedText = "";
            // SabahListesi için
            if (listBox1.SelectedItem != null)
            {
                selectedText = listBox1.SelectedItem.ToString();
                int indexOfFirstSpace = selectedText.IndexOf(' ');
                string foodname = selectedText.Substring(indexOfFirstSpace + 1);
                foreach (Liste item in sabahListesi)
                {
                    if (item.YiyecekAdi == foodname)
                    {
                        item.AdetAzalt();
                        if (item.Adet == 0)
                        {
                            sabahListesi.Remove(item);
                        }
                        listBox1.Items.Clear(); // Listeyi temizle
                        foreach (Liste listItem in sabahListesi)
                        {
                            listBox1.Items.Add(listItem.Adet + " " + listItem.YiyecekAdi);
                        }
                        break;
                    }
                }
            }
            // OgleListesi için
            if (listBox2.SelectedItem != null)
            {
                selectedText = listBox2.SelectedItem.ToString();
                int indexOfFirstSpace = selectedText.IndexOf(' ');
                string foodname = selectedText.Substring(indexOfFirstSpace + 1);
                foreach (Liste item in ogleListesi)
                {
                    if (item.YiyecekAdi == foodname)
                    {
                        item.AdetAzalt();
                        if (item.Adet == 0)
                        {
                            ogleListesi.Remove(item);
                        }
                        listBox2.Items.Clear(); // Listeyi temizle
                        foreach (Liste listItem in ogleListesi)
                        {
                            listBox2.Items.Add(listItem.Adet + " " + listItem.YiyecekAdi);
                        }
                        break;
                    }
                }
            }

            // AksamListesi için
            if (listBox3.SelectedItem != null)
            {
                selectedText = listBox3.SelectedItem.ToString();
                int indexOfFirstSpace = selectedText.IndexOf(' ');
                string foodname = selectedText.Substring(indexOfFirstSpace + 1);
                foreach (Liste item in aksamListesi)
                {
                    if (item.YiyecekAdi == foodname)
                    {
                        item.AdetAzalt();
                        if (item.Adet == 0)
                        {
                            aksamListesi.Remove(item);
                        }
                        listBox3.Items.Clear(); // Listeyi temizle
                        foreach (Liste listItem in aksamListesi)
                        {
                            listBox3.Items.Add(listItem.Adet + " " + listItem.YiyecekAdi);
                        }
                        break;
                    }
                }
            }
            toplamKaloriHesapla();
        }
        List<object> anahtarListesi = new List<object>(); // Anahtarları saklamak için bir liste oluştur

        private async void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            
                var seciliAnahtar = anahtarListesi[comboBox1.SelectedIndex];
                // Seçili anahtarı kullanarak ilgili işlemleri yapabilirsiniz
            
            FirebaseManager firebaseManager = new FirebaseManager();
            DiyetListesi diyetListesi = new DiyetListesi
            {
                ListeAdi = listeAdı.Text,
                ListeNo = listeNo.Text,
                ToplamKalori = Convert.ToInt32(label5.Text),
                YollayanID = seciliAnahtar.ToString(),//yollanan- yollayan olacak
                YollananID =tc,
                Sabah = sabahListesi.Select(y => new Yiyecek { YiyecekAdi = y.YiyecekAdi, Adet = y.Adet }).ToList(),
                Ogle = ogleListesi.Select(y => new Yiyecek { YiyecekAdi = y.YiyecekAdi, Adet = y.Adet }).ToList(),
                Aksam = aksamListesi.Select(y => new Yiyecek { YiyecekAdi = y.YiyecekAdi, Adet = y.Adet }).ToList()
            };
            bool sonuc = await firebaseManager.DiyetListesiEkle(diyetListesi);
            if (sonuc)
            {
                Console.WriteLine("Diyet listesi başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Diyet listesi eklenirken bir hata oluştu.");
            }

            listeNoAyarla();
        }
        public void combobox1Doldur()
        {
            int sayac = 0;

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
                                sayac++;
                                
                                string kullaniciAdSoyad = item3.Value.name + " " + item3.Value.lastname;
                                anahtarListesi.Add(item3.Key);
                                // ComboBox'a kullanıcı adını ekle
                                comboBox1.Items.Add(kullaniciAdSoyad);
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
        public void listeNoAyarla()
        {
            try
            {
                string secilenKisi = comboBox1.Text; // ComboBox1'de seçili olan kişinin adını alın
                int sonDugumIndis = 1; // İndis tanımlanıyor ve başlangıç değeri 1 olarak atanıyor
                var seciliAnahtar = anahtarListesi[comboBox1.SelectedIndex];
                FirebaseResponse al1 = bg.baglan().Get("diyetlistesi/" + seciliAnahtar); // Kullanıcının varlığını kontrol et
                if (al1.Body == "null")
                {
                    // Kullanıcı bulunamadı, listeNo'yu 1 olarak ayarlayın ve çıkış yapın
                    listeNo.Text = "1";
                    return;
                }

                string data = al1.Body.ToString(); // Firebase'den gelen veriyi string olarak alın

                // Veriyi JSON olarak parse edin
                dynamic parsedData = JsonConvert.DeserializeObject(data);

                // Her bir kişi için diyet listelerini dolaş
                foreach (var kisi in parsedData)
                {
                    int listeSayisi = 0; // Kişinin diyet listesi sayısını tutmak için sayaç

                    // Kişinin diyet listesi nesnelerini dolaş
                    foreach (var diyetListesi in kisi.Value)
                    {
                        if (diyetListesi != null)
                        {
                            listeSayisi++;
                        }
                    }

                    sonDugumIndis = Math.Max(sonDugumIndis, listeSayisi);
                }

                listeNo.Text = (sonDugumIndis + 1).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlem Başarısız: " + ex.Message);
            }
        }

       
        private void diyetYaz_Load(object sender, EventArgs e)
        {
            combobox1Doldur();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeNoAyarla();
        }
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            listeAdı.Text = "İsimsiz";
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            comboBox1.SelectedIndex = -1;
            listeNo.Text = "";
            label5.Text = "";
        }
    }
}



