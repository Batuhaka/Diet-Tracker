using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YazMüh_Taslak.Controller
{
    internal class KayıtKontrol
    {

        public Image img;
        public string ad;
        public string soyad;
        public string tc;
        public string dtarih;
        public string telefon;
        public string mail;
        public string adres;
        public string deneyim;
        public string ucret;
        public string okul;
        public string sifre;
        public string base64Resim;
        
        Baglanti bg = new Baglanti();

        public bool onayyolla(string ad, string soyad,
            string tc, string dtarih, string telefon, string mail,
            string adres, string deneyim, string ucret, string okul, string sifre,string base64Resim)
        {
            this.ad = ad;
            this.soyad = soyad;
            this.tc = tc;
            this.dtarih = dtarih;
            this.telefon = telefon;
            this.mail = mail;
            this.adres = adres;
            this.deneyim = deneyim;
            this.ucret = ucret;
            this.okul = okul;
            this.sifre = sifre;
            this.base64Resim = base64Resim;
            
            Onay o = new Onay();
            o.Show();
            return true;
        }

        public bool onay(string key, string ad, string soyad,
            string tc, string dtarih, string telefon, string mail,
            string adres, string deneyim, string ucret, string okul, string sifre, string base64Resim)
        {


            Bilgi bilgi = new Bilgi()
            {
                ad = ad,
                soyad = soyad,
                tc = tc,
                dtarih = dtarih,
                telefon = telefon,
                mail = mail,
                adres = adres,
                deneyim = deneyim,
                ucret = ucret,
                okul = okul,
                sifre = sifre,
                base64resim = base64Resim
            };
            try
            {
                FirebaseResponse al = bg.baglan().Get("Keys/");
                Dictionary<string, Keys> veri = JsonConvert.DeserializeObject<Dictionary<string, Keys>>(al.Body.ToString());

                if (al.Body != null)
                {
                    foreach (var item in veri)
                    {
                            if (item.Key==key && item.Value.Key == key)
                            {
                                var yolla = bg.baglan().Set("bilgitbl/" + tc, bilgi);
                                /*var sil = bg.baglan().Delete("Keys/" + key);*/
                                MessageBox.Show("Kayıt Başarılı");
                                Giris g = new Giris();
                                g.Show();
                                return true;
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
            return false;
        }
    }
}
