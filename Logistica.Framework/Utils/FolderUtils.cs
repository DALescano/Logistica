using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Logistica.Framework
{
    public sealed class FolderUtils
    {
        public static string[] List(string path)
        {
            var directories = Directory.GetDirectories(path);
            return directories;
        }

        public static void Delete(string path)
        {
            System.IO.Directory.Delete(path, true);
        }

        public static void CreateSubDirectory(string name, bool deleteIfExists)
        {
            if (Directory.Exists(name))
            {
                ////Directory.Delete(name, true);
            }

            Directory.CreateDirectory(name);
        }


        public static void Open(string path)
        {
            string myPath = path;
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = myPath;
            prc.Start();
        }

        public static bool Exist(string path)
        {

            return Directory.Exists(path);
        }
    }
}
