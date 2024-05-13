using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp;
using Newtonsoft.Json;

namespace YazMüh_Taslak
{
    internal class Baglanti
    {
        public IFirebaseClient baglan()
        {
            IFirebaseConfig fc = new FirebaseConfig()
            {
                AuthSecret = "Lq97gqGJHbmpNPx6uT0rza5zG3f4X1ot3J5PqHW3",
                BasePath = "https://diet-tracker10-default-rtdb.europe-west1.firebasedatabase.app/"
            };
            IFirebaseClient client = new FireSharp.FirebaseClient(fc);
            return client;
        }
        
    }
}
