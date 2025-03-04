using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace SPSS.Services.FirebaseStorageService
{
    public class FirebaseStorageService : IFirebaseStorageService
    {
        private readonly string _bucket;
        private readonly StorageClient _storageClient;

        public FirebaseStorageService(IConfiguration configuration)
        {
            _bucket = configuration["Firebase:Bucket"];

            if (FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile(configuration["Firebase:CredentialPath"])
                });
            }

            var credential = GoogleCredential.FromFile(configuration["Firebase:CredentialPath"]);
            _storageClient = StorageClient.Create(credential);
        }

        public async Task<string> UploadImageAsync(Stream fileStream, string fileName)
        {
            var objectName = $"images/{fileName}";
            await _storageClient.UploadObjectAsync(_bucket, objectName, null, fileStream);

            return $"https://storage.googleapis.com/{_bucket}/{objectName}";
        }
    }
}