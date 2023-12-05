using Genesis.ContentBuilder.Repository.Queries;
using Genesis.Framework.Configurations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
namespace Genesis.ContentBuilder.Services{
    class FTPService    {
        private ProviderConfiguration _providerConfiguration { get; set; }
        private string _ftpPath;
        NetworkCredential _credentials;
        public FTPService(ProviderConfiguration provideConfiguration) {
            this._providerConfiguration = provideConfiguration;
            this._ftpPath = _providerConfiguration.CdnFileStoreConfiguration.FTPFilePath;
            var username = _providerConfiguration.CdnFileStoreConfiguration.FTPUsername;
            var password = _providerConfiguration.CdnFileStoreConfiguration.FTPPassword;
            this._credentials = new NetworkCredential(username, password);
        }
        public List<FTPFile>  GetFiles() {
            List<FTPFile> filesDetails = new List<FTPFile>();
            FtpWebRequest listFilesRequest = (FtpWebRequest)WebRequest.Create(_ftpPath);
            listFilesRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            listFilesRequest.Credentials = this._credentials;
            FtpWebResponse listResponse = (FtpWebResponse)listFilesRequest.GetResponse();
            StreamReader reader = new StreamReader(listResponse.GetResponseStream());
            while (!reader.EndOfStream)
            {
                var filename = reader.ReadLine();
                if (!filename.Contains("<DIR>"))
                {
                    var details = filename.Split(new[] { ' ' }, 4, StringSplitOptions.RemoveEmptyEntries).ToList();
                    filesDetails.Add(new FTPFile(details.ElementAtOrDefault(3), DateTime.Parse(details.ElementAtOrDefault(0) + ' ' + details.ElementAtOrDefault(1)), Int32.Parse(details.ElementAtOrDefault(2))));
                }
            }
            return filesDetails;
         }
        public Stream DownloadFile(string filename) {
            FtpWebRequest downloadFileRequest = (FtpWebRequest)WebRequest.Create(_ftpPath+filename);
            downloadFileRequest.Method = WebRequestMethods.Ftp.DownloadFile;
            downloadFileRequest.Credentials = this._credentials;
            FtpWebResponse listResponse = (FtpWebResponse)downloadFileRequest.GetResponse();
            return listResponse.GetResponseStream();
        }
        public bool DeleteFile(string filename) {
            FtpWebRequest deleteFileRequest = (FtpWebRequest)WebRequest.Create(_ftpPath + filename);
            deleteFileRequest.Method = WebRequestMethods.Ftp.DeleteFile;
            deleteFileRequest.Credentials = this._credentials;
            FtpWebResponse deleteResponse = (FtpWebResponse)deleteFileRequest.GetResponse();
            return deleteResponse.StatusCode == FtpStatusCode.FileActionOK;
        }
    }
}