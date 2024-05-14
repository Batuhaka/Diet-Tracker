using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazMüh_Taslak.Controller
{
    internal class MesajKontrol
    {
        Baglanti bg=new Baglanti();
        private List<string[]> mesajListesi = new List<string[]>();
        public List<string[]> cek(string id, string tc,string isim)
        {
            mesajListesi.Clear();
            try
            {
                FirebaseResponse al3 = bg.baglan().Get("mesaj/" + id + "/" + tc + "/");
                Dictionary<string, message> veri = JsonConvert.DeserializeObject<Dictionary<string, message>>(al3.Body.ToString());

                if (al3.Body != null)
                {
                    
                    if (veri == null)
                    {
                        MessageBox.Show("buradayim");
                        message m = new message()
                        {
                            alici = id,
                            gonderen = tc,
                            mesaj = "Diyetisyen " + isim,
                            durum = "aktif",
                            tarih = 100
                        };
                        bg.baglan().Push("mesaj/" + id + "/" + tc + "/", m);
                    }
                    else
                    {
                        foreach (var item3 in veri)
                        {
                            
                            string[] liste = {item3.Value.mesaj, item3.Value.alici};
                            mesajListesi.Add(liste);
                        }
                    }
                    return mesajListesi;

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

        public void yaz(string id, string tc, string mesaj)
        {
            DateTime utcNow = DateTime.UtcNow;

            // Unix zaman damgası hesapla (3 saat ileri)
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long timestamp = (long)(utcNow - epoch).TotalSeconds;

            // Mesajı oluştur
            message m = new message()
            {
                alici = id,
                gonderen = tc,
                mesaj = mesaj,
                durum = "aktif",
                tarih = timestamp
            };

            bg.baglan().Push("mesaj/" + id + "/" + tc + "/", m);
        }
    }
}
