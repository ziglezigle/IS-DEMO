using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Documents;
using ISDEMO.model;

namespace ISDEMO.Database
{
    public class FileManager
    {
        private static string folderPath = @"C:\NestingData";
        private static string filePath = Path.Combine(folderPath, "standardInfo.txt");
        
        public static void WriteStandardInfos(List<StandardInfo> list)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
            
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    foreach (var content in list)
                    {
                        writer.WriteLine(content);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("오류: " + ex.Message);
            }
        }

        public static List<StandardInfo> ReadStandardInfos()
        {
            var standardInfos = new List<StandardInfo>();

            try
            {
                if (!Directory.Exists(folderPath) || !File.Exists(filePath))
                    return null;

                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var standardInfo = StandardInfo.StringToStandardInfo(line);
                        standardInfos.Add(standardInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("오류: " + ex.Message);
            }

            return standardInfos;
        }
    }
}
