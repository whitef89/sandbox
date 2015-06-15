using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Linq;
using System.Collections.ObjectModel;

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
        private Collection<string> filePath = new Collection<string>();

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

        public Collection<string> Path
        {
            get
            {
                return filePath;
            }
        }

        #endregion

        public static void saveSettings(Dictionary<string, string> param, Collection<string> dirPath)
        {
            string path = "C:\\Config.xml";
            XDocument xmlDocument = XDocument.Load(path);
            XElement root = xmlDocument.Element("Settings");
            root.SetElementValue("url", param["url"]);
            root.SetElementValue("username", param["username"]);
            root.SetElementValue("password", param["password"]);
            root.SetElementValue("proxy", param["proxy"]);
            root.SetElementValue("uploadInterval", param["uploadInt"]);

            foreach (var x in root.Element("filepath").Elements("path"))
            {
                int i = 0;

                x.SetElementValue("path", dirPath[i]);

                ++i;
            }

            root.Save(path, SaveOptions.DisableFormatting);
            Console.WriteLine(root);
        }

        private void loadFtpConfig()
        {
            XDocument xmlDocument = null;

            xmlDocument = XDocument.Load("C:\\Config.xml");

            if (xmlDocument != null)
            {
                XElement root = xmlDocument.Element("Settings");
                ftpUrl = root.Element("url").Value;
                userName = root.Element("username").Value;
                password = root.Element("password").Value;
                proxy = root.Element("proxy").Value;
                uploadInterval = root.Element("uploadInterval").Value.Equals("") ? 0 : Convert.ToInt32(root.Element("uploadInterval").Value);

                XElement pathList = root.Element("filepath");
                Console.WriteLine("pathList: " + pathList);
                foreach (XElement x in pathList.Descendants("path"))
                {
                    filePath.Add(x.Value);
                }
            }
            else
            {
                ftpUrl = "public.ftp-servers.example.com";
                userName = "username";
                password = "password";
                proxy = "proxy.example.hu";
                uploadInterval = 4;
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
            return "Konfig: " + FTPUrl + " " + UserName + " " + Password + " " + Proxy + " " + UploadInterval + " " + Path;
        }

    }
}

    //<filepath>
    //    <path>c:\Users\FeherF\projects\FTPUpload\toZip\RISKU\*.DBF</path>
    //    <path>c:\Users\FeherF\projects\FTPUpload\toZip\\RISKU\*.DBT</path>
    //    <path>c:\Users\FeherF\projects\FTPUpload\toZip\RISKU\DG\*.*</path>
    //    <path>c:\Users\FeherF\projects\FTPUpload\toZip\RISKU\ECS\*.*</path>
    //    <path>c:\Users\FeherF\projects\FTPUpload\toZip\RISKU\KS\*.*</path>
    //    </path>c:\Users\FeherF\projects\FTPUpload\toZip\RISKU\NT\*.*</path>
    //    <path>c:\Users\FeherF\projects\FTPUpload\toZip\RISKU\RK\*.*</path>
    //    <path>c:\Users\FeherF\projects\FTPUpload\toZip\RISKU\TK\*.*</path>
    //    </path>
    //</filepath>