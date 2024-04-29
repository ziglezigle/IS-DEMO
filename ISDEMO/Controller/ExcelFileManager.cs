using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using ISDEMO.model;
using OfficeOpenXml;

namespace ISDEMO.Controller;

public class ExcelFileManager : FileManager<Part>
{
    private static List<Part> parts = new List<Part>();
    
    public List<Part> ReadFile(string file)
    {
        const string sheet = "IMB-현장"; // 원하는 시트 선택
        using (var package = new ExcelPackage(new FileInfo(file)))
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

        return parts;
    }

    public void WriteFile(List<Part> list)
    {
        throw new System.NotImplementedException();
    }
    
    private Part ExtractData(ExcelWorksheet worksheet, int row)
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
    
    private int FindStartingRow(ExcelWorksheet worksheet)
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
}