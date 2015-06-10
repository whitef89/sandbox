using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FTPUtil;
using System.Collections.Generic;

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
            Dictionary<string, string> param = new Dictionary<string,string>();
            param.Add("url", "test url");
            param.Add("username", "test username");
            param.Add("password", "test password");
            param.Add("proxy","test proxy");
            param.Add("uploadInt",Convert.ToString(5));
            Config.saveSettings(param);
            Config _conf = Config.Instance;
            Console.WriteLine(_conf);
        }
    }
}
