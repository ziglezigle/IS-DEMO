﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;

namespace New_IS_Heavy.Models
{
    public class ExcelDataWriter
    {
        private static string folderPath = @"C:Report";
        private static string filePath = $"{DateTime.Now:yyyy.MM.dd} 우전 GNF C1.xlsx";
        private static int row = 13;
        public static void Write(List<RowMaterial> bomList)
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                DirectoryCheck();
                // Excel 시트 생성
                var worksheet = package.Workbook.Worksheets.Add("각관 150*100*3.2");

                MakeHeader(worksheet);
                
                MakeChart(worksheet, bomList);
                // Excel 파일 저장
                package.SaveAs(new FileInfo(filePath));
            }

            Console.WriteLine("Excel 파일이 생성되고 열렸습니다.");
        }

        public static void OpenFile()
        {
            Process.Start(new ProcessStartInfo { FileName = filePath, UseShellExecute = true });
        }

        private static void DirectoryCheck()
        {
            try
            {
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("오류: " + ex.Message);
            }
        }

        private static void MakeHeader(ExcelWorksheet worksheet)
        {
                // 엑셀 세로 폭 설정
                worksheet.Row(3).Height = worksheet.DefaultRowHeight / 2;
                worksheet.Row(4).Height = worksheet.DefaultRowHeight / 2;
                worksheet.Row(9).Height = worksheet.DefaultRowHeight / 2;
                worksheet.Row(10).Height = worksheet.DefaultRowHeight / 2;
                
                MakeUnderLine(worksheet, 3);
                MakeUnderLine(worksheet, 9);
                
                // 첫 행 데이터 추가
                worksheet.Cells[1, 1].Value = "NAME";
                worksheet.Cells[1, 3].Value = "DESCRIPTION";
                worksheet.Cells[1, 5].Value = "MATERIAL";
                worksheet.Cells[1, 7].Value = "UNIT WEIGHT";
                
                worksheet.Cells[2, 1].Value = "각관";
                worksheet.Cells[2, 3].Value = "150*100*3.2";
                worksheet.Cells[2, 5].Value = "SS275";
                worksheet.Cells[2, 7].Value = "20.1";
                worksheet.Cells[2, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells[2, 8].Value = "kg/m";
                worksheet.Cells[2, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                worksheet.Cells[5, 1].Value = "NUMBER OF PART TYPE : ";
                worksheet.Cells[5, 4].Value = 1;
                worksheet.Cells[5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells[5, 6].Value = "TOTAL NUMBER OF PART : ";
                worksheet.Cells[5, 9].Value = 14;
                worksheet.Cells[5, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                worksheet.Cells[6, 1].Value = "TOTAL STOCK WEIGHT = ";
                worksheet.Cells[6, 4].Value = 242 + " [ Kg]";
                worksheet.Cells[6, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells[6, 6].Value = "TOTAL PART WEIGHT = ";
                worksheet.Cells[6, 9].Value = 201 + " [ Kg]";
                worksheet.Cells[6, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                worksheet.Cells[7, 1].Value = "TOTAL RESIDUAL WEIGHT = ";
                worksheet.Cells[7, 6].Value = "TOTAL SCRAP WEIGHT = ";
                worksheet.Cells[7, 9].Value = 40 + " [ Kg]";
                worksheet.Cells[7, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                
                worksheet.Cells[8, 1].Value = "TOTAL BAR USAGE : ";
                worksheet.Cells[8, 4].Value = 83 + "%";
                worksheet.Cells[8, 6].Value = "PRINT DATE : ";
                worksheet.Cells[8, 8].Value = $"{DateTime.Now:yyyy.MM.dd hh:mm}";
                
                worksheet.Cells[11, 1].Value = "NO.";
                worksheet.Cells[11, 2].Value = "STOCK";
                worksheet.Cells[11, 5].Value = "CUTTING PARTS";
                worksheet.Cells[11, 9].Value = "SCRAP";
        }

        //헤더의 경계선 
        private static void MakeUnderLine(ExcelWorksheet worksheet, int row)
        {
            // 1열부터 9열까지 아래쪽 테두리 설정
            for (int col = 1; col <= 9; col++)
            {
                var range = worksheet.Cells[row, col];
                var border = range.Style.Border;
                border.Bottom.Style = ExcelBorderStyle.Thick;
            }
        }

        //원자재 테두리 
        private static void MakeBorder(ExcelWorksheet worksheet, int row)
        {
            
            // 병합할 범위 선택
            var mergedCells = worksheet.Cells[row, 3, row, 8];
            // 셀 병합
            mergedCells.Merge = true;
            
            // 테두리 설정할 셀 범위 선택 (3열부터 8열까지, 1행부터 10행까지)
            var range = worksheet.Cells[row, 3, row, 8];

            // 테두리 스타일 설정
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        }
        
        private static void InsertImage(ExcelWorksheet worksheet, Bitmap image, int row)
        {
            string tempImagePath = Path.Combine(Path.GetTempPath(), $"BarChartImage{row}.png");
            image.Save(tempImagePath, ImageFormat.Png);

            // Excel에 이미지 삽입
            ExcelPicture picture = worksheet.Drawings.AddPicture($"BarChart{row}", new FileInfo(tempImagePath));
    
            // 이미지 위치 설정
            picture.SetPosition(row -1 , 0, 3 - 1, 0);
        }


        private static void MakeChart(ExcelWorksheet worksheet, List<RowMaterial> list)
        {
            var i = 1;
            foreach (var bom in list)
            {
                worksheet.Cells[row, 1].Value = i;
                worksheet.Cells[row, 2].Value = bom.Length;
                worksheet.Cells[row, 9].Value = bom.get_remaining_length();
                worksheet.Cells[row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells[row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells[row, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                MakeBorder(worksheet, row);
                InsertImage(worksheet, bom.GenerateBarChartImage(), row);
                i++;
                row++;
                
                int j = 1;
                foreach (var part in bom.parts_inside)
                {
                    worksheet.Cells[row, 2].Value = j;
                    worksheet.Cells[row, 3].Value = "BlockMark:";
                    worksheet.Cells[row, 4].Value = part.Mark;
                    worksheet.Cells[row, 5].Value = "DWGNo:";
                    worksheet.Cells[row, 6].Value = part.Assem;
                    worksheet.Cells[row, 7].Value = "Length:";
                    worksheet.Cells[row, 8].Value = part.Length;
                    j++;
                    row++;
                }

                row++;
            }
        }
    }
}
 
 
 
 
 

/*using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ISDEMO.model;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;

namespace ISDEMO.Excel
{
    public class ExcelDataWriter
    {
        private static string folderPath = @"C:\Report";
        private static string filePath = $"{DateTime.Now:yyyy.MM.dd} 우전 GNF C1.xlsx";
        private static int row = 13;
        public static void Write(List<BOM> bomList)
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                DirectoryCheck();
                // Excel 시트 생성
                var worksheet = package.Workbook.Worksheets.Add("각관 150*100*3.2");

                MakeHeader(worksheet);
                
                MakeChart(worksheet, bomList);
                // Excel 파일 저장
                package.SaveAs(new FileInfo(filePath));
            }

            Console.WriteLine("Excel 파일이 생성되고 열렸습니다.");
        }

        public static void OpenFile()
        {
            Process.Start(new ProcessStartInfo { FileName = filePath, UseShellExecute = true });
        }

        private static void DirectoryCheck()
        {
            try
            {
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("오류: " + ex.Message);
            }
        }

        private static void MakeHeader(ExcelWorksheet worksheet)
        {
                // 엑셀 세로 폭 설정
                worksheet.Row(3).Height = worksheet.DefaultRowHeight / 2;
                worksheet.Row(4).Height = worksheet.DefaultRowHeight / 2;
                worksheet.Row(9).Height = worksheet.DefaultRowHeight / 2;
                worksheet.Row(10).Height = worksheet.DefaultRowHeight / 2;
                
                MakeUnderLine(worksheet, 3);
                MakeUnderLine(worksheet, 9);
                
                // 첫 행 데이터 추가
                worksheet.Cells[1, 1].Value = "NAME";
                worksheet.Cells[1, 3].Value = "DESCRIPTION";
                worksheet.Cells[1, 5].Value = "MATERIAL";
                worksheet.Cells[1, 7].Value = "UNIT WEIGHT";
                
                worksheet.Cells[2, 1].Value = "각관";
                worksheet.Cells[2, 3].Value = "150*100*3.2";
                worksheet.Cells[2, 5].Value = "SS275";
                worksheet.Cells[2, 7].Value = "20.1";
                worksheet.Cells[2, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells[2, 8].Value = "kg/m";
                worksheet.Cells[2, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                worksheet.Cells[5, 1].Value = "NUMBER OF PART TYPE : ";
                worksheet.Cells[5, 4].Value = 1;
                worksheet.Cells[5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells[5, 6].Value = "TOTAL NUMBER OF PART : ";
                worksheet.Cells[5, 9].Value = 14;
                worksheet.Cells[5, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                worksheet.Cells[6, 1].Value = "TOTAL STOCK WEIGHT = ";
                worksheet.Cells[6, 4].Value = 242 + " [ Kg]";
                worksheet.Cells[6, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells[6, 6].Value = "TOTAL PART WEIGHT = ";
                worksheet.Cells[6, 9].Value = 201 + " [ Kg]";
                worksheet.Cells[6, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                worksheet.Cells[7, 1].Value = "TOTAL RESIDUAL WEIGHT = ";
                worksheet.Cells[7, 6].Value = "TOTAL SCRAP WEIGHT = ";
                worksheet.Cells[7, 9].Value = 40 + " [ Kg]";
                worksheet.Cells[7, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                
                worksheet.Cells[8, 1].Value = "TOTAL BAR USAGE : ";
                worksheet.Cells[8, 4].Value = 83 + "%";
                worksheet.Cells[8, 6].Value = "PRINT DATE : ";
                worksheet.Cells[8, 8].Value = $"{DateTime.Now:yyyy.MM.dd hh:mm}";
                
                worksheet.Cells[11, 1].Value = "NO.";
                worksheet.Cells[11, 2].Value = "STOCK";
                worksheet.Cells[11, 5].Value = "CUTTING PARTS";
                worksheet.Cells[11, 9].Value = "SCRAP";
        }

        //헤더의 경계선 
        private static void MakeUnderLine(ExcelWorksheet worksheet, int row)
        {
            // 1열부터 9열까지 아래쪽 테두리 설정
            for (int col = 1; col <= 9; col++)
            {
                var range = worksheet.Cells[row, col];
                var border = range.Style.Border;
                border.Bottom.Style = ExcelBorderStyle.Thick;
            }
        }

        //원자재 테두리 
        private static void MakeBorder(ExcelWorksheet worksheet, int row)
        {
            
            // 병합할 범위 선택
            var mergedCells = worksheet.Cells[row, 3, row, 8];
            // 셀 병합
            mergedCells.Merge = true;
            
            // 테두리 설정할 셀 범위 선택 (3열부터 8열까지, 1행부터 10행까지)
            var range = worksheet.Cells[row, 3, row, 8];

            // 테두리 스타일 설정
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        }
        
        private static void InsertImage(ExcelWorksheet worksheet, Bitmap image, int row)
        {
            string tempImagePath = Path.Combine(Path.GetTempPath(), $"BarChartImage{row}.png");
            image.Save(tempImagePath, ImageFormat.Png);

            // Excel에 이미지 삽입
            ExcelPicture picture = worksheet.Drawings.AddPicture($"BarChart{row}", new FileInfo(tempImagePath));
    
            // 이미지 위치 설정
            picture.SetPosition(row -1 , 0, 3 - 1, 0);
        }


        private static void MakeChart(ExcelWorksheet worksheet, List<BOM> list)
        {
            var i = 1;
            foreach (var bom in list)
            {
                worksheet.Cells[row, 1].Value = i;
                worksheet.Cells[row, 2].Value = bom.Length;
                worksheet.Cells[row, 9].Value = bom.Scrap;
                worksheet.Cells[row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells[row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells[row, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                MakeBorder(worksheet, row);
                InsertImage(worksheet, bom.GenerateBarChartImage(), row);
                i++;
                row++;
                
                int j = 1;
                foreach (var part in bom.Parts)
                {
                    worksheet.Cells[row, 2].Value = j;
                    worksheet.Cells[row, 3].Value = "BlockMark:";
                    worksheet.Cells[row, 4].Value = part.Mark;
                    worksheet.Cells[row, 5].Value = "DWGNo:";
                    worksheet.Cells[row, 6].Value = part.Assem;
                    worksheet.Cells[row, 7].Value = "Length:";
                    worksheet.Cells[row, 8].Value = part.Length;
                    j++;
                    row++;
                }

                row++;
            }
        }
    }
}*/