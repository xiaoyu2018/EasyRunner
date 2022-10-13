using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace EasyRunner.Utils
{
    internal class FtpClient
    {
        private FtpWebRequest _request;
        private string ip;
        private string dest_file;
        private string un;
        private string pw;

        public FtpClient(string ip, string dest_file, string un, string pw)
        {
            this.ip = ip;
            this.dest_file = dest_file;
            this.un = un;
            this.pw = pw;
        }

        public void ConfigRequest()
        {
            try
            {
                
                _request = (FtpWebRequest)WebRequest.Create($"ftp://{ip}/{dest_file}");
                _request.KeepAlive = true;
                _request.Credentials = new NetworkCredential(un, pw);
            }
            catch
            {
                throw;
            }
        }

        public async Task UploadAsync(string loc_file)
        {
            

            try
            {
                ConfigRequest();

                _request.Method = WebRequestMethods.Ftp.UploadFile;

                FileInfo fileInfo = new FileInfo(loc_file);

                using FileStream fs = fileInfo.OpenRead();
                using var rs = await _request.GetRequestStreamAsync();

                byte[] buffer = new byte[2048];
                int len = 0;
                do
                {
                    len = await fs.ReadAsync(buffer, 0, buffer.Length);
                    await rs.WriteAsync(buffer, 0, len);

                } while (len > 0);

            }
            catch
            {

                throw;
            }
            finally
            {
                _request.Abort();

            }

        }

        public async Task DeleteAsync()
        {
            
            FtpWebResponse response = null;

            try
            {
                ConfigRequest();
                _request.Method = WebRequestMethods.Ftp.DeleteFile;

                response = (FtpWebResponse)await _request.GetResponseAsync();

            }

            catch
            {

                throw;
            }

            finally
            {
                if (response != null)
                    response.Close();
                _request.Abort();
            }

            
        }

    }
}
