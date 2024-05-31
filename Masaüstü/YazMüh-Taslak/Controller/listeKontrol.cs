using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YazMüh_Taslak.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YazMüh_Taslak.Controller
{
    internal class listeKontrol
    {
        private static readonly HttpClient client = new HttpClient();
        Baglanti bg = new Baglanti();
        private List<string[]> diyetListesi = new List<string[]>();
        List<string> keyList = new List<string>();
        List<string> kaloriList= new List<string>();

        public List<string[]> listeGonder(string id, string tc,string ogun,string deger)
        {

            try
            {
                FirebaseResponse al3 = bg.baglan().Get("diyetlistesi/" + id + "/" + tc + "/" + deger + "/" + ogun + "/");
                Dictionary<string, DiyetListesi2> veri = JsonConvert.DeserializeObject<Dictionary<string, DiyetListesi2>>(al3.Body.ToString());

                if (al3.Body != null)
                {
                    if (veri == null)
                    {
                        return null;
                    }
                    else
                    {
                        foreach (var item3 in veri)
                        {
                            string[] liste = { item3.Key, item3.Value.adet.ToString() };
                            diyetListesi.Add(liste);
                        }
                        return diyetListesi;
                    }
                    
                }
                
                else
                {
                    MessageBox.Show("Kullanıcı bulunamadı");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Giriş Başarısız: " + ex.Message);
            }
            return null;
        }

        public int ListeNoAyarla(string id)// ayrı bir klasta yazılabilir
        {
            try
            {
/*                string secilenKisi = comboBox1.Text; // ComboBox1'de seçili olan kişinin adını alın
*/              int sonDugumIndis = 1; // İndis tanımlanıyor ve başlangıç değeri 1 olarak atanıyor
                var seciliAnahtar = id;
                FirebaseResponse al1 = bg.baglan().Get("diyetlistesi/" + seciliAnahtar); // Kullanıcının varlığını kontrol et
                if (al1.Body == "null")
                {
                    // Kullanıcı bulunamadı, listeNo'yu 1 olarak ayarlayın ve çıkış yapın
                    return 0;
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

                return sonDugumIndis;
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlem Başarısız: " + ex.Message);
                return -1; // Hata durumunda -1 döndür
            }
        }

        public List<string> kaloriGonder(string id, string tc,string numara)
        {
            FirebaseResponse response = bg.baglan().Get("diyetlistesi/" + id + "/" + tc + "/");
            dynamic data = response.ResultAs<dynamic>();
            string listeadi = data[Convert.ToInt32(numara)].listeadi;
            int toplamkalori = data[Convert.ToInt32(numara)].toplamkalori;
            string stoplamkalori = toplamkalori.ToString();
            string slisteadi = listeadi;
            kaloriList.Add(stoplamkalori);
            kaloriList.Add(slisteadi);

            return kaloriList;
        }


    }
}
