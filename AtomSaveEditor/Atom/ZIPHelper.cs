using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomSaveEditor.Atom
{
    class ZIPHelper
    {
        private static void CompressFile(string sDir, string sRelativePath, GZipStream zipStream)
        {
            char[] array = sRelativePath.ToCharArray();
            zipStream.Write(BitConverter.GetBytes(array.Length), 0, 4);
            char[] array2 = array;
            foreach (char value in array2)
            {
                zipStream.Write(BitConverter.GetBytes(value), 0, 2);
            }
            byte[] array3 = File.ReadAllBytes(Path.Combine(sDir, sRelativePath));
            zipStream.Write(BitConverter.GetBytes(array3.Length), 0, 4);
            zipStream.Write(array3, 0, array3.Length);
        }

        private static bool DecompressFile(string sDir, GZipStream zipStream)
        {
            byte[] array = new byte[4];
            int num = zipStream.Read(array, 0, 4);
            if (num < 4)
            {
                return false;
            }
            int num2 = BitConverter.ToInt32(array, 0);
            array = new byte[2];
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < num2; i++)
            {
                zipStream.Read(array, 0, 2);
                char value = BitConverter.ToChar(array, 0);
                stringBuilder.Append(value);
            }
            string path = stringBuilder.ToString();
            array = new byte[4];
            zipStream.Read(array, 0, 4);
            int num3 = BitConverter.ToInt32(array, 0);
            array = new byte[num3];
            zipStream.Read(array, 0, array.Length);
            string path2 = Path.Combine(sDir, path);
            string directoryName = Path.GetDirectoryName(path2);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            using (FileStream fileStream = new FileStream(path2, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fileStream.Write(array, 0, num3);
            }
            return true;
        }

        private static byte[] DecompressFileToBytes(string file, GZipStream zipStream)
        {
            string text;
            byte[] array;
            do
            {
                array = new byte[4];
                int num = zipStream.Read(array, 0, 4);
                if (num < 4)
                {
                    return null;
                }
                int num2 = BitConverter.ToInt32(array, 0);
                array = new byte[2];
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < num2; i++)
                {
                    zipStream.Read(array, 0, 2);
                    char value = BitConverter.ToChar(array, 0);
                    stringBuilder.Append(value);
                }
                text = stringBuilder.ToString();
                array = new byte[4];
                zipStream.Read(array, 0, 4);
                int num3 = BitConverter.ToInt32(array, 0);
                array = new byte[num3];
                zipStream.Read(array, 0, array.Length);
            }
            while (!(text.ToLower() == file.ToLower()));
            return array;
        }

        public static void CompressDirectory(string sInDir, string sOutFile)
        {
            string[] files = Directory.GetFiles(sInDir, "*.*", SearchOption.AllDirectories);
            int startIndex = (sInDir[sInDir.Length - 1] != Path.DirectorySeparatorChar) ? (sInDir.Length + 1) : sInDir.Length;
            using (FileStream compressedStream = new FileStream(sOutFile, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (GZipStream zipStream = new GZipStream(compressedStream, CompressionMode.Compress))
                {
                    string[] array = files;
                    foreach (string text in array)
                    {
                        string sRelativePath = text.Substring(startIndex);
                        ZIPHelper.CompressFile(sInDir, sRelativePath, zipStream);
                    }
                }
            }
        }

        public static byte[] CompressDirectory(string sInDir)
        {
            string[] files = Directory.GetFiles(sInDir, "*.*", SearchOption.AllDirectories);
            int startIndex = (sInDir[sInDir.Length - 1] != Path.DirectorySeparatorChar) ? (sInDir.Length + 1) : sInDir.Length;
            MemoryStream memoryStream = new MemoryStream();
            using (GZipStream zipStream = new GZipStream(memoryStream, CompressionMode.Compress))
            {
                string[] array = files;
                foreach (string text in array)
                {
                    string sRelativePath = text.Substring(startIndex);
                    ZIPHelper.CompressFile(sInDir, sRelativePath, zipStream);
                }
            }
            return memoryStream.ToArray();
        }

        public static void DecompressToDirectory(string sCompressedFile, string sDir)
        {
            using (FileStream compressedStream = new FileStream(sCompressedFile, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (GZipStream zipStream = new GZipStream(compressedStream, CompressionMode.Decompress, true))
                {
                    while (ZIPHelper.DecompressFile(sDir, zipStream))
                    {
                    }
                }
            }
        }

        public static byte[] DecompressToFileBytes(string archive, string filename)
        {
            using (FileStream compressedStream = new FileStream(archive, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (GZipStream zipStream = new GZipStream(compressedStream, CompressionMode.Decompress, true))
                {
                    return ZIPHelper.DecompressFileToBytes(filename, zipStream);
                }
            }
        }
    }
}
