using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazMüh_Taslak
{
    public class DiyetListesi
    {
        public string ListeAdi { get; set; }
        public string ListeNo { get; set; }
        public int ToplamKalori { get; set; }
        public string YollayanID { get; set; }
        public string YollananID { get; set; }
        public List<Yiyecek> Sabah { get; set; }
        public List<Yiyecek> Ogle { get; set; }
        public List<Yiyecek> Aksam { get; set; }
    }
    

    public class Yiyecek
    {
        public string YiyecekAdi { get; set; }
        public int Adet { get; set; }
    }
}
