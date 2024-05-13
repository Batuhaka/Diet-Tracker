using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YazMüh_Taslak;

public class FirebaseManager
{
    private readonly Baglanti _baglanti;

    public FirebaseManager()
    {
        _baglanti = new Baglanti();
    }

    public async Task<bool> DiyetListesiEkle(DiyetListesi diyetListesi)
    {
        try
        {
            IFirebaseClient client = _baglanti.baglan();

            var yol = "diyetlistesi/" + diyetListesi.YollayanID + "/" + diyetListesi.YollananID + "/" + diyetListesi.ListeNo;

            FirebaseResponse response = await client.SetAsync(yol + "/listeadi", diyetListesi.ListeAdi);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return false;

            response = await client.SetAsync(yol + "/toplamkalori", diyetListesi.ToplamKalori);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return false;

            // Sabah yiyecekleri
            for (int i = 0; i < diyetListesi.Sabah.Count; i++)
            {
                var sabahYiyecek = diyetListesi.Sabah[i];
                response = await client.SetAsync($"{yol}/sabah/{sabahYiyecek.YiyecekAdi}/adet", sabahYiyecek.Adet);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return false;
            }

            // Öğle yiyecekleri
            for (int i = 0; i < diyetListesi.Ogle.Count; i++)
            {
                var ogleYiyecek = diyetListesi.Ogle[i];
                response = await client.SetAsync($"{yol}/ogle/{ogleYiyecek.YiyecekAdi}/adet", ogleYiyecek.Adet);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return false;
            }

            // Akşam yiyecekleri
            for (int i = 0; i < diyetListesi.Aksam.Count; i++)
            {
                var aksamYiyecek = diyetListesi.Aksam[i];
                response = await client.SetAsync($"{yol}/aksam/{aksamYiyecek.YiyecekAdi}/adet", aksamYiyecek.Adet);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            // Hata durumunda burada işlemler yapılabilir, loglama yapılabilir.
            Console.WriteLine("Hata: " + ex.Message);
            return false;
        }
    }

  
}
