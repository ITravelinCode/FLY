
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace FLY.Business.Services.Implements
{
    public class GoogleDriveService : IGoogleDriveService
    {
        private readonly string? _credentialsPath;

        public GoogleDriveService()
        {
            _credentialsPath = Environment.GetEnvironmentVariable("CREDENTIALS_PATH");
        }
        public async Task DeleteFileAsync(string fileName, string parentFolderId)
        {
            var credentials = await GetCredentialsAsync();
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials,
                ApplicationName = "FLY"
            });

            try
            {
                var request = service.Files.List();
                request.Q = $"name='{fileName}' and parents in '{parentFolderId}'";
                var files = await request.ExecuteAsync();

                if(files.Files.Count > 0)
                {
                    var fileId = files.Files[0].Id;

                    await service.Files.Delete(fileId).ExecuteAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Some error with it, please contact administrator");
            }
        }

        public async Task<byte[]> GetFileContentAsync(string fileName, string parentFolderId)
        {
            var credentials = await GetCredentialsAsync();
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials,
                ApplicationName = "FLY"
            });
            try
            {
                var request = service.Files.List();
                request.Q = $"name='{fileName}' and parents in '{parentFolderId}'";
                var files = await request.ExecuteAsync();

                if(files.Files.Count > 0)
                {
                    var fileId = files.Files[0].Id;

                    var memoryStream = new MemoryStream();
                    var getRequest = service.Files.Get(fileId);
                    await getRequest.DownloadAsync(memoryStream);
                    return memoryStream.ToArray();
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Some error with it, please contact administrator");
            }
        }

        public async Task UploadFileAsync(Stream fileStream, Google.Apis.Drive.v3.Data.File fileMetadata)
        {
            var credentials = await GetCredentialsAsync();
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials,
                ApplicationName = "FLY"
            });
            var file = await service.Files.Create(fileMetadata, fileStream, fileMetadata.MimeType).UploadAsync();
        }

        private async Task<UserCredential> GetCredentialsAsync()
        {
            // Set up the flow and the data store
            using var stream = new FileStream(_credentialsPath, FileMode.Open, FileAccess.Read);
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(stream).Secrets,
                new[] { DriveService.Scope.DriveFile },
                "user",
                CancellationToken.None,
                new FileDataStore("GoogleDriveUploads.json", true)
            ).Result;
            return credential;
        }
    }
}
