using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using FTPUtil;


namespace FTPConfig
{
    class ConfigModel : INotifyPropertyChanged
    {
        #region dataMembers

        private string serverURL;
        private string userName;
        private string password;
        private string proxy;

        private int uploadInterval;
        private Collection<string> pathToCopy;

        Config _sourceConf = Config.Instance;

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        #region constructors
        public ConfigModel()
        {
            this.serverURL = _sourceConf.FTPUrl;
            this.userName = _sourceConf.UserName;
            this.password = _sourceConf.Password;
            this.proxy = _sourceConf.Proxy;
            this.uploadInterval = _sourceConf.UploadInterval;
            //this.pathToCopy = path;
        }

        public ConfigModel(String url, String user, String pass, String proxy, int intervall, Collection<String> path)
        {
            this.serverURL = url;
            this.userName = user;
            this.password = pass;
            this.proxy = proxy;
            this.uploadInterval = intervall;
            this.pathToCopy = path;

        }
        #endregion

        #region publicProperties
        public string FTPServerUrl
        {
            get { return this.serverURL; }
            set
            {

                this.serverURL = value;
                this.NotifyPropertyChanged("FTPServerUrl");

            }
        }

        public string UserName
        {
            get { return this.userName; }
            set
            {
                this.userName = value;
                this.NotifyPropertyChanged("UserName");
            }
        }

        public string Password
        {
            get { return this.password; }
            set
            {
                this.password = value;
                this.NotifyPropertyChanged("Password");
            }
        }

        public string ProxyUrl
        {
            get { return this.proxy; }
            set
            {
                this.proxy = value;
                this.NotifyPropertyChanged("ProxyUrl");
            }
        }

        public int UploadInterval
        {
            get { return this.uploadInterval; }
            set
            {
                this.uploadInterval = value;
                this.NotifyPropertyChanged("UploadInterval");
            }
        }

        public Collection<string> path
        {
            get { return this.pathToCopy; }
            set
            {
                this.pathToCopy = value;
                this.NotifyPropertyChanged("path");
            }
        }
        #endregion

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public override string ToString()
        {
            return "Konfig: " + FTPServerUrl + " " + UserName + " " + Password + " " + ProxyUrl + " " + uploadInterval + " " + path;
        }


    }
}
