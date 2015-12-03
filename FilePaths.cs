using System.IO;

namespace _2courOOP_KR
{
    public static class FilePaths
    {
        private static string[] filePaths;
        private static string[] repFilePaths;

        public static  string[] GetPath()
        {
         filePaths =
            Directory.GetFiles(
                @"C:\Users\Bodiver\Documents\Visual Studio 2015\Projects\2courOOP KR\2courOOP KR\bin\Debug", "*.osl");
            return filePaths;
        }

        public static string[] GetRepPath()
        {
                    repFilePaths =
            Directory.GetFiles(
                @"C:\Users\Bodiver\Documents\Visual Studio 2015\Projects\2courOOP KR\2courOOP KR\bin\Debug", "*.rep");
            return repFilePaths;
        }
    }
}