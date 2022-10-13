using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyRunner.Utils
{
    
    struct NetConfig
    {
        public string Ip { get; set; }

        public string DestFile { get; set; }

        public string LocalFile { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }


        public NetConfig(
            string local,
            string un = "wxy", string pw = "2838896",
            string ip = "192.168.1.1", string dest = "test"
            )
        {
            
            Ip = ip;
            DestFile = dest;
            LocalFile = local;
            UserName = un;
            Password = pw;
        }
    }

    class NetController
    {

        private FtpClient _ftpClient;
        private TelnetClinet _telnetClinet;

        private NetConfig _netConfig;

        public NetConfig NetConfig
        {
            get => _netConfig;
            set => _netConfig = value;
        }

        public NetController()
        {
            
        }

        public async Task InitializeAsync(NetConfig netConfig)
        {
            this.NetConfig = netConfig;
            try
            {
                _ftpClient = new FtpClient(_netConfig.Ip,_netConfig.DestFile,_netConfig.UserName,_netConfig.Password);
                _telnetClinet = new TelnetClinet();
                await _telnetClinet.ConnectAsync(_netConfig.Ip, 23);
                await _telnetClinet.LoginAsync(_netConfig.UserName, _netConfig.Password, 200);
            }
            catch
            {
                throw;
            }
        }

        public NetController(NetConfig config) => NetConfig = config;

        public async void DeleteAsync()
        {
            try
            {
                
                await _ftpClient.DeleteAsync();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                return;
            }
            MessageBox.Show($"文件{_netConfig.DestFile}已被成功删除");
        }

        public async void UploadAsync()
        {

            try
            {
                await _ftpClient.UploadAsync(_netConfig.LocalFile);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }

            MessageBox.Show($"文件{_netConfig.LocalFile}已被上传至:/home/{_netConfig.UserName}/{_netConfig.DestFile}");
        }

        public async void Run()
        {
            try
            {
                await _telnetClinet.WriteLineAsync("chmod 777 test");
                await _telnetClinet.ReadAsync();
                await _telnetClinet.WriteLineAsync("~/test");
                string res= await _telnetClinet.ReadAsync();
                MessageBox.Show(res);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }

        }

        
    }

    
}
