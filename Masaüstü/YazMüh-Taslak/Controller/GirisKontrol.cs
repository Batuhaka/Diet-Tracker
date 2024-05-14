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
    internal class GirisKontrol
    {
        Baglanti bg = new Baglanti();
        
        public bool giris(string tc, string sifre)
        {
            try
            {
                FirebaseResponse al = bg.baglan().Get("bilgitbl/");
                Dictionary<string, Bilgi> veri = JsonConvert.DeserializeObject<Dictionary<string, Bilgi>>(al.Body.ToString());

                // Check if data exists and parse it
                if (al.Body != null)
                {
                    foreach (var item in veri)
                    {
                        if (item.Key == tc && item.Value.sifre == sifre)
                        {
                            Ana a = new Ana();
                            a.ad = item.Value.ad;
                            a.soyad = item.Value.soyad;
                            a.tc = item.Value.tc;
                            a.img = item.Value.base64resim;
                            a.Show();

                            return true; // Giriş başarılı
                        }
                    }

                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
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

            return false; // Giriş başarısız
        }
    }
}
