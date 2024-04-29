using System;
using System.Collections.Generic;
using ISDEMO.model;
using OfficeOpenXml;
using System.IO;
using System.Text.RegularExpressions;

namespace ISDEMO.Excel
{
    public class ExcelDataReader
    {
        private static List<Part> parts = new List<Part>();

        public static List<Part> PartListFromExcel(string filePath)
        {
            //List<string> sheets = GetExcelSheets(filePath);
            //PrintSheets(sheets);

            const string sheet = "IMB-현장"; // 원하는 시트 선택
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[sheet];
                var row = FindStartingRow(worksheet);

                while (row <= worksheet.Dimension.End.Row)
                {
                    var cellValue = worksheet.Cells[row, 4].Value;
                    if (cellValue != null && int.TryParse(cellValue.ToString(), out int intValue))
                    {
                        parts.Add(ExtractData(worksheet, row));
                    }

                    row++;
                }
            }

            /*PrintParts();
            Console.WriteLine(parts.Count);*/
            return parts;
        }

        private static int FindStartingRow(ExcelWorksheet worksheet)
        {
            var row = 1;
            for (; row < worksheet.Dimension.End.Row; row++)
            {
                if (worksheet.Cells[row, 1].Value == null ||
                    worksheet.Cells[row, 1].Value.ToString() != "ASSEM") continue;
                row++;
                break;
            }
            return row;
        }

        private void PrintSheets(List<string> sheets)
        {
            foreach (var sheet in sheets)
            {
                Console.WriteLine(sheet);
            }
        }

        private List<string> GetExcelSheets(string filePath)
        {
            var sheetNames = new List<string>();
            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                foreach (var sheet in package.Workbook.Worksheets)
                {
                    sheetNames.Add(sheet.Name);
                }
            }
            return sheetNames;
        }

        private static Part ExtractData(ExcelWorksheet worksheet, int row)
        {
            var assem = worksheet.Cells[row, 1].Value?.ToString() ?? string.Empty;
            var mark = worksheet.Cells[row, 2].Value?.ToString() ?? string.Empty;
            var desc = worksheet.Cells[row, 3].Value?.ToString() ?? string.Empty;
            var length = Convert.ToInt32(worksheet.Cells[row, 4].Value);
            var num = Convert.ToInt32(worksheet.Cells[row, 5].Value);
            var weightOne = Convert.ToDouble(worksheet.Cells[row, 6].Value);
            var weightSum = Convert.ToDouble(worksheet.Cells[row, 7].Value);
            var pArea = Convert.ToDouble(worksheet.Cells[row, 8].Value);
            var material = worksheet.Cells[row, 9].Value?.ToString() ?? string.Empty;
            var type = Regex.Match(desc, @"^[^\d]+").Value;
            var size = Regex.Match(desc, @"[\d\*\.]+").Value;
            Description description = new Description(type, size);
            
            return new Part(assem, mark, description, length, num, weightOne, weightSum, pArea, material);
        }

        private void PrintParts()
        {
            foreach (var part in parts)
                Console.WriteLine(part.ToString());
        }
    }
}
