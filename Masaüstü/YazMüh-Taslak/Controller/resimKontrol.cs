using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Storage.V1;
using System.IO;
using Google.Apis.Auth.OAuth2;
namespace YazMüh_Taslak
{
    internal class resimKontrol
    {
        private readonly StorageClient _storageClient;

        public resimKontrol()
        {
            // Firebase Storage'a erişim için gerekli yetkilendirmeler
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string serviceAccountPath = Path.Combine(desktopPath, "diet-tracker10-firebase-adminsdk-1ulfv-156bb9fe7d.json");
            GoogleCredential credential = GoogleCredential.FromFile(serviceAccountPath);
            _storageClient = StorageClient.Create(credential);
        }

        public void DownloadImage(string bucketName, string objectName, string destinationFilePath)
        {
            using (var outputFile = File.OpenWrite(destinationFilePath))
            {
                // Firebase Storage'dan resmi indirme
                _storageClient.DownloadObject(bucketName, objectName, outputFile);
            }
        }
    }
}
