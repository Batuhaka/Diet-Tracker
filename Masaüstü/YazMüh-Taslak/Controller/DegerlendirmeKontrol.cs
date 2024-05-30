using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazMüh_Taslak.Controller
{
    internal class DegerlendirmeKontrol
    {
        Baglanti bg= new Baglanti();
        int tPuan = 0;
        private List<string[]> degerlendirmeListesi = new List<string[]>();

        public List<string[]> degerlendirme(string tc)
        {
            try
            {
                FirebaseResponse al3 = bg.baglan().Get("reviews/" + tc + "/");
                Dictionary<string, Degerlendirme> veri = JsonConvert.DeserializeObject<Dictionary<string, Degerlendirme>>(al3.Body.ToString());

                if (al3.Body != null)
                {
                    foreach(var item in veri)
                    {
                        string[] liste = { item.Value.Hasta, item.Value.Puan,item.Value.Yorum };
                        degerlendirmeListesi.Add(liste);
                        
                    }
                    return degerlendirmeListesi;

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
            return null;
        }
    }
}
