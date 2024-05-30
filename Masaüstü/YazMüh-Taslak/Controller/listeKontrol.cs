using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YazMüh_Taslak.Model;

namespace YazMüh_Taslak.Controller
{
    internal class listeKontrol
    {
        private static readonly HttpClient client = new HttpClient();
        Baglanti bg = new Baglanti();
        private List<string[]> diyetListesi = new List<string[]>();
        List<string> keyList = new List<string>();
        /*public List<string[]> listeGonder(string id,string tc)
        {
            try
            {
                FirebaseResponse al3 = bg.baglan().Get("diyetlistesi/" + id + "/" + tc + "/");
                string jsonResponse = al3.Body.ToString();
                var veri = JsonConvert.DeserializeObject<Dictionary<string, List<object>>>(jsonResponse);
                Dictionary<string, DiyetListesi> veri = JsonConvert.DeserializeObject<Dictionary<string, DiyetListesi>>(al3.Body.ToString());

                if (al3.Body != null)
                {

                        foreach (var item3 in veri)
                        {
                            string[] liste = { item3.Value.ListeAdi,item3.Value.ToplamKalori.ToString() };
                            diyetListesi.Add(liste);
                        }

                    return diyetListesi;

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

        }*/

        public List<string[]> keyGonder(string id, string tc,string ogun,string deger)
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

        
    }
}
