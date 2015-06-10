using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Linq;

namespace FTPUtil
{
    public sealed class Config
    {
        #region members

        private string ftpUrl;
        private string userName;
        private string password;
        private string proxy;
        private int uploadInterval;

        private static Config instance = null;
        #endregion

        private static bool _refreshing = true;

        #region constructor
        
        private Config()
        {
            loadFtpConfig();
        }

        #endregion

        #region properties
        public static Config Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Config();
                }
                return instance;
            }
        }

        public string FTPUrl
        {
            get
            {
                return ftpUrl;
            }
        }
        public string UserName
        {
            get
            {
                return userName;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
        }

        public string Proxy
        {
            get
            {
                return proxy;
            }
        }

        public int UploadInterval
        {
            get
            {
                return uploadInterval;
            }
        }

        #endregion

        public static void saveSettings(Dictionary<string,string> param)
        {
            string path = "C:\\Config.xml";
            XDocument xmlDocument = XDocument.Load(path);
            XElement root = xmlDocument.Element("Settings");
            root.SetElementValue("url",param["url"]);
            root.SetElementValue("username", param["username"]);
            root.SetElementValue("password", param["password"]);
            root.SetElementValue("proxy", param["proxy"]);
            root.SetElementValue("uploadInterval", param["uploadInt"]);
            root.Save(path, SaveOptions.DisableFormatting);
            Console.WriteLine(root);
        }

        private void loadFtpConfig()
        {
            XDocument xmlDocument = XDocument.Load("C:\\Config.xml");
            if (xmlDocument != null)
            {
                XElement root = xmlDocument.Element("Settings");
                ftpUrl = root.Element("url").Value;
                userName = root.Element("username").Value;
                password = root.Element("password").Value;
                proxy = root.Element("proxy").Value;
                uploadInterval = Convert.ToInt32(root.Element("uploadInterval").Value);
            }
           
        }

        public void Resync()
        {
            _refreshing = true;
        }

        public void saveConfig()
        {

        }

        public override string ToString()
        {
            return "Konfig: " + FTPUrl + " " + UserName + " " + Password + " " + Proxy + " " + UploadInterval;
        }

    }
}
