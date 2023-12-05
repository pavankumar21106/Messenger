using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.IO;
using System.Threading.Tasks;
using System.Configuration;
namespace LMS.DocumentUploadService.AWSS3Client{
    public class AWSS3Client : IDocumentManager    {
        private readonly AmazonS3Client _s3Client;
        private readonly TransferUtility _transferUtility;
        private AwsConfigurationsForS3 awsConfig;
        public AWSS3Client()
        {
            SetAwsConfiguration();
            var bucketEndPoint = RegionEndpoint.GetBySystemName(awsConfig.StorageRegion);
            _s3Client = new AmazonS3Client(awsConfig.AccessKey,
                                           awsConfig.SecreKey,
                                           new AmazonS3Config() { UseAccelerateEndpoint = true, RegionEndpoint = bucketEndPoint });
            _transferUtility = new TransferUtility(_s3Client);
        }
        public byte[] DownloadDocument(string filePath)
        {
            var ms = new MemoryStream();
            var response = _s3Client.GetObject(awsConfig.BucketName, filePath);
            response.ResponseStream.CopyTo(ms);
            return ms.ToArray();
        }
        public async Task<byte[]> DownloadDocumentAsync(string filePath)
        {
            var ms = new MemoryStream();
            var response = await _s3Client.GetObjectAsync(awsConfig.BucketName, filePath);
            response.ResponseStream.CopyTo(ms);
            return ms.ToArray();
        }
        public MemoryStream GetDocumentStream(string filePath)
        {
            var ms = new MemoryStream();
            var response = _s3Client.GetObject(awsConfig.BucketName, filePath);
            response.ResponseStream.CopyTo(ms);
            return ms;
        }
        public async Task<MemoryStream> GetDocumentStreamAsync(string filePath)
        {
            var ms = new MemoryStream();
            var response = await _s3Client.GetObjectAsync(awsConfig.BucketName, filePath);
            response.ResponseStream.CopyTo(ms);
            return ms;
        }
        public void UploadDocument(Stream fs, string filePath)
        {
            if (fs == null && fs.Length <= 0)
            {
                throw new  EmptyStreamExceptions("Stream doesnot exists.");
            }
            _transferUtility.Upload(fs, awsConfig.BucketName, filePath);
        }
        public void UploadDocument(byte[] file, string filePath)
        {
            Stream fs = new MemoryStream(file);
            UploadDocument(fs, filePath);
        }
        private void SetAwsConfiguration()
        {
            awsConfig = new AwsConfigurationsForS3            {
                AccessKey = ConfigurationManager.AppSettings["AWSAccessKey"],
                SecreKey = ConfigurationManager.AppSettings["AWSSecretKey"],
                StorageRegion = ConfigurationManager.AppSettings["AWSStorageRegion"],
                BucketName = ConfigurationManager.AppSettings["BucketName"]
            };
        }
    }
     public class AwsConfigurationsForS3    {
        public string AccessKey { get; set; }
        public string SecreKey { get; set; }
        public string StorageRegion { get; set; }
        public string BucketName { get; set; }
    }
}