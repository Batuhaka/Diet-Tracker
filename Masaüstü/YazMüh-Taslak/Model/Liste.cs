using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazMüh_Taslak
{
    public class Liste
    {
        // Liste öğeleri için gerekli özellikler
        public string YiyecekAdi { get; set; }
        public string Ogun {  get; set; }
        public int Adet { get; set; }
        public int Secim { get; set; }
        public double Kalori { get; set; }
        // Liste sınıfının kurucu yöntemi
        public Liste(string yiyecekAdi, int secim, double kalori)
        {
            YiyecekAdi = yiyecekAdi;
            Adet = 1;
            Secim = secim;
            Kalori = kalori;
            if (secim == 1) { Ogun = "Sabah"; }
            if (secim == 2) { Ogun = "Ogle"; }
            if (secim == 3) { Ogun = "Aksam"; }
        }

        // Adet sayısını arttıran yöntem
        public void AdetArttir()
        {
            Adet++;
        }

        // Adet sayısını azaltan yöntem
        public void AdetAzalt()
        {
            if (Adet > 0)
            {
                Adet--;
            }
         
        }
    }
}
