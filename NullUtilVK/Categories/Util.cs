using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullUtilVK.Enums.SafetyEnums;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Security.Cryptography;
using NullUtilVK.Enums;
using System.Net;

namespace NullUtilVK.Categories
{
    public class Util
    {
        public Util()
        {
            timr.AutoReset = false;
            timr.Elapsed += timr_Elapsed;
        }

        static System.Timers.Timer timr = new System.Timers.Timer(2000);
        static bool IsTimerRunning = false;

        public static string SecToTime(int Seconds)
        {
            if (Seconds >= 60 * 60)
                return String.Format("{0:00}:{1:00}:{2:00}", (Seconds / 360) % 60, (Seconds / 60) % 60, Seconds % 60);
            else
                return String.Format("{0:00}:{1:00}", (Seconds / 60) % 60, Seconds % 60);
        }

        internal static bool IsFilesTheSame(string path1, string path2)
        {
            bool isEqual = false;
            MD5 md5 = MD5.Create();
            byte[] hash1;
            byte[] hash2;
            string hash1hex = string.Empty;
            string hash2hex = string.Empty;

            while (IsFileLocked(new FileInfo(path1))) { }
            using (var stream = File.OpenRead(path1))
            {
                hash1 = md5.ComputeHash(stream);
            }
            while (IsFileLocked(new FileInfo(path2))) { }
            using (var stream = File.OpenRead(path2))
            {
                hash2 = md5.ComputeHash(stream);
            }

            for (int i = 0; i < hash1.Length; i++)
            {
                hash1hex += hash1[i].ToString("X2");
            }
            for (int i = 0; i < hash2.Length; i++)
            {
                hash2hex += hash2[i].ToString("X2");
            }

            if (hash1hex.Length == hash2hex.Length)
            {
                int i = 0;
                while (i < hash1hex.Length && hash1hex[i] == hash2hex[i])
                {
                    i++;
                }
                if (i == hash1hex.Length)
                    isEqual = true;
            }

            return isEqual;
        }

        internal static /*virtual*/ bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        internal static long GetFolderSize(string Path)
        {
            long Size = 0;
            foreach (var file in Directory.GetFiles(Path))
            {
                Size += new FileInfo(file).Length;
            }
            return Size;
        }

        internal static FileInfo GetBestFile(string Path, FileCriterion Criter)
        {
            List<FileInfo> Files = new List<FileInfo>();
            FileInfo Target = null;
            foreach (var filePath in Directory.GetFiles(Path))
            {
                Files.Add(new FileInfo(filePath));
            }
            switch (Criter)
            {
                case FileCriterion.Newest:
                    Target = Files.First(v => Files.Max(c => c.CreationTime) == v.CreationTime);
                    break;
                case FileCriterion.Oldest:
                    Target = Files.First(v => Files.Min(c => c.CreationTime) == v.CreationTime);
                    break;
                case FileCriterion.Biggest:
                    Target = Files.First(v => Files.Max(c => c.Length) == v.Length);
                    break;
                case FileCriterion.Smallest:
                    Target = Files.First(v => Files.Min(c => c.Length) == v.Length);
                    break;
            }
            return Target;
        }

        public static T? NullableEnumFrom<T>(int value) where T : struct
        {
            if (!Enum.IsDefined(typeof(T), value))
                return null;

            return (T)(object)value;
        }

        public static T EnumFrom<T>(int value) where T : struct
        {
            if (!Enum.IsDefined(typeof(T), value))
                throw new ArgumentException("Value is undefined", "value");

            return (T)(object)value;
        }

        public static long GetWebFileSize(string url)
        {
            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
            webReq.Method = "HEAD";
            HttpWebResponse webResp;
            long FileSize;

            while (IsTimerRunning) { }

            try
            {
                webResp = (HttpWebResponse)webReq.GetResponse();
                FileSize = webResp.ContentLength;
                webResp.Close();
                IsTimerRunning = true;
                timr.Start();
            }
            catch (WebException)
            {
                return 0;
            }
            return FileSize;
        }



        private static void timr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            IsTimerRunning = false;
        }
    }
}
