using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EasyRunner.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string IpAddress { get; set; }

        private string _filePath;

        public string FilePath
        {
            get { return _filePath; }
            set 
            { 
                _filePath = value; 
                PropertyChanged.Invoke(this,new PropertyChangedEventArgs("FilePath"));
            }
        }




        public MainWindowViewModel()
        {

        }
    }
}
