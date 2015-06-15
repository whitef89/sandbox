using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FTPUtil;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FTPTest
{
    [TestClass]
    public class FTPTest
    {
        [TestMethod]
        public void loadConfigXml()
        {
            Console.WriteLine("load Config XML file");
            Config _conf = Config.Instance;
            Console.WriteLine(_conf);
        }

        [TestMethod]
        public void saveConfigXml()
        {
            Console.WriteLine("save Config XML file");
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("url", "test url");
            param.Add("username", "test username");
            param.Add("password", "test password");
            param.Add("proxy", "test proxy");
            param.Add("uploadInt", Convert.ToString(5));

            Collection<string> path = new Collection<string>();
            path.Add("fuck");
            path.Add("you");
            Config.saveSettings(param, path);
            Config _conf = Config.Instance;
            Console.WriteLine(_conf);
        }


        [TestMethod]
        public void createZip()
        {
            FTPUtil.ZipUtil.createZip(@"c:\sdf");
        }

        [TestMethod]
        public void deleteZip()
        {
            FTPUtil.ZipUtil.deleteZip(@"c:\sdf_20150615_230008.zip");
        }

        [TestMethod]
        public void uploadToFTP()
        {
            FtpHandler.FTPUpload("c:\\sdf_20150615_230344.zip");
        }

    }
}