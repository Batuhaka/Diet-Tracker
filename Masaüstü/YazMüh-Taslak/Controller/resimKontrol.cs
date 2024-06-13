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
            // Proje kök dizinini bulma
            string currentDirectory = Directory.GetCurrentDirectory();

            // JSON dosyasının tam yolunu oluştur
            string serviceAccountPath = Path.Combine(currentDirectory, "diet-tracker10-firebase-adminsdk-1ulfv-52e4ea8a48.json");

            GoogleCredential credential = GoogleCredential.FromFile(serviceAccountPath);
            _storageClient = StorageClient.Create(credential);
        }

        public void DownloadImage(string bucketName, string objectName, string destinationFilePath)
        {
            try
            {
                using (var outputFile = File.OpenWrite(destinationFilePath))
                {
                    // Firebase Storage'dan resmi indirme
                    _storageClient.DownloadObject(bucketName, objectName, outputFile);
                }
                Console.WriteLine("Image downloaded successfully to " + destinationFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error downloading image: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
            }
        }
    }
}
