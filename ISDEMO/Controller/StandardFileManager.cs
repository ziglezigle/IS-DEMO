using System;
using System.Collections.Generic;
using System.IO;
using ISDEMO.model;

namespace ISDEMO.Controller
{
    public class StandardFileManager : FileManager<StandardInfo>
    {
        private static string folderPath = @"C:\NestingData";
        private static string filePath = Path.Combine(folderPath, "standardInfo.txt");
        
        public List<StandardInfo> ReadFile(string file)
        {
            var standardInfos = new List<StandardInfo>();

            try
            {
                if (!Directory.Exists(folderPath) || !File.Exists(file))
                    return null;

                using (var reader = new StreamReader(file))
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

        public void WriteFile(List<StandardInfo> list)
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
    }
}