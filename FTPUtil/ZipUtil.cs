using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ionic.Zip;
using Ionic.Zlib;
using System.Collections.ObjectModel;
using System.IO;

namespace FTPUtil
{
    public class ZipUtil
    {
        static private Config conf = Config.Instance;

        public static void createZip(string name)
        {
            using (ZipFile z = new ZipFile())
            {
                z.CompressionLevel = CompressionLevel.BestCompression;
                Collection<string> pathList = conf.Path;
                string path = "";
                foreach (string p in pathList)
                {
                    if (p.EndsWith("\\*.*"))
                    {
                        path = p.Remove(p.Length - 3);
                    }
                    else
                    {
                        path = p;
                    }
                    if (isDirectory(path))
                    {
                        Console.WriteLine("path: " + @path);
                        Console.WriteLine("Zip path: " + @getZipPath(path));
                        z.AddDirectory(@path, @getZipPath(path));
                    }
                    else
                    {
                        Console.WriteLine("path: " + @path);
                        Console.WriteLine("Zip path: " + @getZipPath(path));
                        Console.WriteLine("extension: " + getExtension(path));
                        Console.WriteLine("getFilePath: " + getFilePath(path));
                        z.AddSelectedFiles(@getExtension(path), @getFilePath(path), @"\RISKU");
                    }

                   
                }
                //z.AddSelectedFiles(@"*.DBF", @"c:\Users\FeherF\projects\FTPUpload\toZip\RISKU\", @"\RISKU");
             
                z.Save(@name + "_"+ DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".zip");
            }
                    
        }

        private static Boolean isDirectory(string path)
        {
            return Directory.Exists(@path);
        }

        private static string getZipPath(string s)
        {
            int startIndex = s.IndexOf("\\RISKU");
            int endIndex = s.LastIndexOf("\\");
            string pathInZip = s.Substring(startIndex, endIndex - startIndex);
            return pathInZip;
        }

        private static string getExtension(string s)
        {
            return s.Substring(s.LastIndexOf("\\")+1, s.Length-s.LastIndexOf("\\")-1);
        }

        private static string getFilePath(string s)
        {
            return s.Substring(0, s.Length - getExtension(s).Length);
        }

        public static void deleteZip(string path)
        {
            if (File.Exists(@path))
            {
                File.Delete(@path);
            }
        }
    }
}
