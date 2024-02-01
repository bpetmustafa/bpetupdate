using System;
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BPET_PORTAL.profilsayfasi
{
    public class FtpManager
    {
        private string ftpServer = "ftp://95.0.50.22:1381";
        private string username = "mustafa.ceylan";
        private string password = "Defne2023";
        private string folder = "/bpet_portal/userphoto/";

        public async Task UploadFileAsync(string localFilePath, string remoteFileName)
        {
            string uri = ftpServer + folder + remoteFileName;
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, password);

            byte[] fileContents;
            using (FileStream fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    fileContents = br.ReadBytes((int)fs.Length);
                }
            }

            request.ContentLength = fileContents.Length;
            using (Stream requestStream = await request.GetRequestStreamAsync())
            {
                await requestStream.WriteAsync(fileContents, 0, fileContents.Length);
            }

            using (FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync())
            {
                Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
            }
        }

        // FTP'den dosya URI'sini alır
        public string GetFileUri(string remoteFileName)
        {
            string httpServer = "http://95.0.50.22:1380";
            return httpServer + folder + remoteFileName;
        }

    }
}
