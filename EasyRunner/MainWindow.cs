using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EasyRunner.ViewModels;
using EasyRunner.Utils;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace EasyRunner
{
    public partial class MainWindow : Form
    {
        #region fields
        private MainWindowViewModel _viewModel;

        private NetController _netController;

        private bool _isConnected = false;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
            _netController = new NetController();
        }


        #region internal_fucs
        private void MainWindow_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            this.ip_textbox.DataBindings.Add("Text", _viewModel, "IpAddress");
            this.file_textbox.DataBindings.Add("Text", _viewModel, "FilePath");
        }

        
        #endregion

        #region events
        private async void Button_Clicked(object sender, EventArgs e)
        {

            Button btn = sender as Button;

            if (btn.Name.Equals("browse_btn"))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                var ret = openFileDialog.ShowDialog();

                if (ret == DialogResult.OK)
                {
                    _viewModel.FilePath = openFileDialog.FileName;
                }
            }

            else if (btn.Name.Equals("test_btn"))
            {
                using Ping ping = new Ping();
                try
                {
                    var reply=await Task<PingReply>.Run(()=>ping.Send(_viewModel.IpAddress,2500));
                    if (reply.Status != IPStatus.Success)
                        throw new Exception("被测设备未连通");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                MessageBox.Show("被测设备连通性正常");
            }

            else if (btn.Name.Equals("connect_btn"))
            {
                try
                {
                    await _netController.InitializeAsync(new NetConfig(_viewModel.FilePath, ip: _viewModel.IpAddress));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                _isConnected = true;
                MessageBox.Show("已建立被设备的FTP和TELNET连接");
            }

            

            else if (this._isConnected)
            {
                if (btn.Name.Equals("tarns_btn"))
                {
                    NetConfig netConfig = _netController.NetConfig;
                    netConfig.LocalFile=_viewModel.FilePath;
                    _netController.NetConfig = netConfig;
                    _netController.UploadAsync();

                }

                else if (btn.Name.Equals("del_btn"))
                {
                    _netController.DeleteAsync();
                }
                else if (btn.Name.Equals("run_btn"))
                {
                    _netController.Run();
                    
                }
            }

            else
            {
                MessageBox.Show("请先与被测设备建立连接！");
            }
        }
        #endregion
    }
}
