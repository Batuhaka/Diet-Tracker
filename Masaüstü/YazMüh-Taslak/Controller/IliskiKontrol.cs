using Bunifu.Framework.UI;
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
    internal class IliskiKontrol
    {
        Baglanti bg = new Baglanti();
        public List<string> kullaniciListesi = new List<string>();
        private List<string[]> veriListesi =new List<string[]>();
        public List<string> iliski(string tc)
        {
            try
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
                                kullaniciListesi.Add(item2.Key.ToString());
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
            return kullaniciListesi;
            /*mesaj m = new mesaj();
            diyetYaz d= new diyetYaz();
            hastalarım h = new hastalarım();
            h.kullaniciListesi1.AddRange(kullaniciListesi);
            m.kullaniciListesi1.AddRange(kullaniciListesi);
            d.kullaniciListesi1.AddRange(kullaniciListesi);*/

        }
        int sayac=0;
        public List<string[]> hasta(List<string> kullaniciListesi1)
        {
            hastalarım h = new hastalarım();
            mesaj m= new mesaj();
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
/*                              MessageBox.Show("girdim.");
                                MessageBox.Show(item3.Value.name);
                                h.yazdir(item3.Value.name, item3.Value.lastname, item3.Value.age, item3.Value.boy,
                                    item3.Value.kilo, item3.Value.bmi);*/
                                string[] veri1 = {item3.Value.name, item3.Value.lastname, item3.Value.age, item3.Value.boy,
                                    item3.Value.kilo, item3.Value.bmi,item3.Key};
                                veriListesi.Add(veri1);
                            }
                        }
                    }
                    return veriListesi;

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
        public string idGonder(List<string[]> veriListesi,string ad)
        {
            foreach (var item in veriListesi)
            {
                string isim = item[0] + " " + item[1];
                if (isim==ad)
                {
                    return item[6];
                }
            }
            return null;
        }
    }
}
