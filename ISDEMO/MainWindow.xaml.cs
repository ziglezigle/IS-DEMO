using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ISDEMO.Controller;
using ISDEMO.Excel;
using ISDEMO.model;
using New_IS_Heavy.Models;

namespace ISDEMO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> length_options_rawMaterial = new List<int>() { 6010, 7010, 7510, 8010, 9510, 10010, 12110 };
        List<RowMaterial> raw_materials_used = new List<RowMaterial>();

        public MainWindow()
        {
            InitializeComponent();

            var pm = new PartManager(ExcelDataReader.PartListFromExcel(@"C:\ISProject\forDemo.xlsx"));
            pm.SelectDescription("TB150*100*3.2");
            List<Part> part_list = pm.TaskList;

            part_list.Sort((a, b) => b.Length.CompareTo(a.Length));
            // sort in descending order
            length_options_rawMaterial.Sort((a, b) => b.CompareTo(a));

            RowMaterial raw_material = null;
            int if_count = 0;

            RowMaterial best_of_the_best_combination = null;
            List<RowMaterial> best_combination_list = new List<RowMaterial>();

            List<int> garra_parts = new List<int>() { 2844, 2844 };
            check_leftover_parts(part_list);
            raw_material = garra_creator(part_list, garra_parts, 6010);
            raw_materials_used.Add(raw_material);

            raw_material = garra_creator(part_list, garra_parts, 6010);
            raw_materials_used.Add(raw_material);

            raw_material = garra_creator(part_list, garra_parts, 6010);
            raw_materials_used.Add(raw_material);

            raw_material = garra_creator(part_list, garra_parts, 6010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 2868, 2844 };
            raw_material = garra_creator(part_list, garra_parts, 6010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3393, 3131 };
            raw_material = garra_creator(part_list, garra_parts, 7010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 6669 };
            raw_material = garra_creator(part_list, garra_parts, 7010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 6669 };
            raw_material = garra_creator(part_list, garra_parts, 7010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 6669 };
            raw_material = garra_creator(part_list, garra_parts, 7010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 6669 };
            raw_material = garra_creator(part_list, garra_parts, 7010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3393, 3393 };
            raw_material = garra_creator(part_list, garra_parts, 7010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3394, 3394 };
            raw_material = garra_creator(part_list, garra_parts, 7010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3394, 3394 };
            raw_material = garra_creator(part_list, garra_parts, 7010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3394, 3394 };
            raw_material = garra_creator(part_list, garra_parts, 7010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3394, 3394 };
            raw_material = garra_creator(part_list, garra_parts, 7010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3394, 3394 };
            raw_material = garra_creator(part_list, garra_parts, 7010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3394, 3394 };
            raw_material = garra_creator(part_list, garra_parts, 7010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3394, 3394 };
            raw_material = garra_creator(part_list, garra_parts, 7010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3394, 3394 };
            raw_material = garra_creator(part_list, garra_parts, 7010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3394, 3394 };
            raw_material = garra_creator(part_list, garra_parts, 7010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3394, 3394 };
            raw_material = garra_creator(part_list, garra_parts, 7010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3394, 3394 };
            raw_material = garra_creator(part_list, garra_parts, 7010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3394, 3394 };
            raw_material = garra_creator(part_list, garra_parts, 7010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3394, 3394 };
            raw_material = garra_creator(part_list, garra_parts, 7010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3394, 3394 };
            raw_material = garra_creator(part_list, garra_parts, 7010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3394, 3394 };
            raw_material = garra_creator(part_list, garra_parts, 7010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3581, 3581 };
            raw_material = garra_creator(part_list, garra_parts, 7510);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 4843, 2489 };
            raw_material = garra_creator(part_list, garra_parts, 7510);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3731, 3731 };
            raw_material = garra_creator(part_list, garra_parts, 7510);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3731, 3731 };
            raw_material = garra_creator(part_list, garra_parts, 7510);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3731, 3731 };
            raw_material = garra_creator(part_list, garra_parts, 7510);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3731, 3731 };
            raw_material = garra_creator(part_list, garra_parts, 7510);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3731, 3731 };
            raw_material = garra_creator(part_list, garra_parts, 7510);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 1881, 1881, 1881, 1881 };
            raw_material = garra_creator(part_list, garra_parts, 8010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 2844, 2624, 2331 };
            raw_material = garra_creator(part_list, garra_parts, 8010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 5479, 2331 };
            raw_material = garra_creator(part_list, garra_parts, 8010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 4682, 4682 };
            raw_material = garra_creator(part_list, garra_parts, 9510);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3131, 3131, 3131 };
            raw_material = garra_creator(part_list, garra_parts, 9510);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3131, 3131, 3131 };
            raw_material = garra_creator(part_list, garra_parts, 9510);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3131, 3131, 3131 };
            raw_material = garra_creator(part_list, garra_parts, 9510);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3131, 3131, 3131 };
            raw_material = garra_creator(part_list, garra_parts, 9510);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3131, 3131, 3131 };
            raw_material = garra_creator(part_list, garra_parts, 9510);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 4832, 4832 };
            raw_material = garra_creator(part_list, garra_parts, 10010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 4832, 4832 };
            raw_material = garra_creator(part_list, garra_parts, 10010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 4832, 4832 };
            raw_material = garra_creator(part_list, garra_parts, 10010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 4832, 4832 };
            raw_material = garra_creator(part_list, garra_parts, 10010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 4843, 4843 };
            raw_material = garra_creator(part_list, garra_parts, 10010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3231, 3231, 3231 };
            raw_material = garra_creator(part_list, garra_parts, 10010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3231, 3231, 3231 };
            raw_material = garra_creator(part_list, garra_parts, 10010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3231, 3231, 3231 };
            raw_material = garra_creator(part_list, garra_parts, 10010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 9705 };
            raw_material = garra_creator(part_list, garra_parts, 10010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 2487, 2487, 2487, 2487 };
            raw_material = garra_creator(part_list, garra_parts, 10010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 2487, 2487, 2487, 2487 };
            raw_material = garra_creator(part_list, garra_parts, 10010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 2487, 2487, 2487, 2487 };
            raw_material = garra_creator(part_list, garra_parts, 10010);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 10137 };
            raw_material = garra_creator(part_list, garra_parts, 12110);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 10504 };
            raw_material = garra_creator(part_list, garra_parts, 12110);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 10604 };
            raw_material = garra_creator(part_list, garra_parts, 12110);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 11304 };
            raw_material = garra_creator(part_list, garra_parts, 12110);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 12004 };
            raw_material = garra_creator(part_list, garra_parts, 12110);
            raw_materials_used.Add(raw_material);

            garra_parts = new List<int>() { 3731, 3581 };
            raw_material = garra_creator(part_list, garra_parts, 7510);
            raw_materials_used.Add(raw_material);

            check_leftover_parts(part_list);


            // print_info_after_arrangement(part_list, raw_materials_used);

            raw_materials_used.Sort((a, b) => a.Length.CompareTo(b.Length));
            // ExcelDataLoader.ExportDataToExcel(raw_materials_used, "/Users/suchacoolguy/Documents/garra.xlsx");

            /*ExcelDataWriter.Write(raw_materials_used);
            ExcelDataWriter.OpenFile();*/

            int lenSum = 0;
            int scrapSum = 0;
            double weightSum = 0;
            int numOfPart = 0;
            foreach (var rowMaterial in raw_materials_used)
            {
                lenSum += rowMaterial.Length;
                scrapSum += rowMaterial.get_remaining_length();
                foreach (var part in rowMaterial.parts_inside)
                {
                    weightSum += part.WeightOne;
                    numOfPart++;
                }
            }
            Console.WriteLine($"Total length : {lenSum} " +
                              $"TotalScrap : {scrapSum}" +
                              $"Number of parts : {numOfPart}" +
                              $"PartWeight Sum : {weightSum}");


        }

        Part find_last_part(List<Part> part_list)
        {
            Part res = null;
            foreach (var part in part_list)
            {
                if (part.Num > 0)
                    res = part;
            }

            return res;
        }

        public RowMaterial garra_creator(List<Part> part_list, List<int> part_length, int raw_length)
        {
            RowMaterial raw = new RowMaterial(raw_length);
            int trial = part_length.Count;

            foreach (var part in part_list)
            {
                foreach (var required_len in part_length)
                {
                    if (part.Length == required_len && part.Num > 0 && trial > 0)
                    {
                        raw.add_part(part);
                        part.Num--;
                        trial--;
                    }
                }
            }

            return raw;
        }

        public void print_info_before_arrangement(List<Part> part_list)
        {
            int part_count = 0;
            int total_parts_length_before_arrangement = 0;
            foreach (var part in part_list)
            {
                int num_of_parts = part.Num;
                while (num_of_parts > 0)
                {
                    total_parts_length_before_arrangement += part.Length;
                    num_of_parts--;
                    part_count++;
                }
            }

            Console.WriteLine("=======================================================");
            Console.WriteLine("Total Parts Length before arrangement: " + total_parts_length_before_arrangement);
            Console.WriteLine("Length of Part List: " + part_list.Count);
            Console.WriteLine("Total Number of Parts: " + part_count);
            Console.WriteLine("=======================================================");
        }

        public void print_info_after_arrangement(List<Part> part_list, List<RowMaterial> raw_materials_used)
        {
            int raw_number = 1;
            int scrap_sum = 0;
            int part_count = 0;
            int num_parts = 0;
            int the_shortest_part = part_list[part_list.Count - 1].Length;
            int the_longest_part = part_list[0].Length;

            Console.WriteLine("the longest part: " + the_longest_part);
            Console.WriteLine("the shortest part: " + the_shortest_part);
            Console.WriteLine("num of raw materials used:" + raw_materials_used.Count);
            Console.WriteLine("=======================================================");

            foreach (var raw in raw_materials_used)
            {
                Console.Write(raw_number + ". ");
                Console.WriteLine(raw + "\n");
                raw_number++;
                num_parts += raw.get_parts_inside().Count;
                scrap_sum += raw.get_remaining_length();
            }

            foreach (var part in part_list)
            {
                int num_of_parts = part.Num;
                while (num_of_parts > 0)
                {
                    num_of_parts--;
                    part_count++;
                }
            }

            Console.WriteLine("=======================================================");
            Console.WriteLine("Remaining Parts: " + part_count);
            Console.WriteLine("Number of Parts Used: " + num_parts);
            Console.WriteLine("Number of Raw Materials Used: " + raw_materials_used.Count);
            Console.WriteLine("Scrap Sum: " + scrap_sum);
        }

        public void check_leftover_parts(List<Part> part_list)
        {
            Console.WriteLine("=======================================================");
            Console.WriteLine("Leftover Parts:");
            foreach (var part in part_list)
            {
                Console.WriteLine("length: " + part.Length);
                Console.WriteLine("num: " + part.Num);
            }

            Console.WriteLine("=======================================================");

        }
    }
}































/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using ISDEMO.Controller;
using ISDEMO.Excel;
using ISDEMO.model;
using New_IS_Heavy.Models;

namespace ISDEMO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /*var parts = ExcelDataReader.PartListFromExcel(@"C:\ISProject\forDemo.xlsx");
            Console.WriteLine(parts.Count);
            foreach (var part in parts)
            {
                Console.WriteLine(part);
            }#1#

            /*var list = FileManager.ReadStandardInfos();
            foreach (var data in list)
            {
                Console.WriteLine(data);
            }#1#

            /*var pm = new PartManager(ExcelDataReader.PartListFromExcel(@"C:\ISProject\forDemo.xlsx"));
            pm.SelectDescription("TB150*100*3.2");
            List<Part> list = pm.TaskList;
            int i = 0;
            int len = 0;
            list.Sort();//오름차순 정렬
            list.Sort((a, b) => b.Length.CompareTo(a.Length));//내림차순 정렬
            foreach (var part in list)
            {
                Console.WriteLine(part);
                i++;
                len += part.Length;
            }
            Console.WriteLine(i);
            Console.WriteLine("len = " + len);#1#

            //더미데이터
            /*List<Part> list = new List<Part>();
            Description desc = new Description("TB", "150*100*3.2");
            list.Add(new Part("hhhh", "IOT_07", desc, 5000, 1, 10, 10, 11, "sssss"));
            list.Add(new Part("hhhh", "IOT_08", desc, 3000, 1, 10, 10, 11, "sssss"));
            list.Add(new Part("hhhh", "IOT_09", desc, 350, 1, 10, 10, 11, "sssss"));
            var bom = new BOM(12000, list);

            List<BOM> bomList= new List<BOM>();
            bomList.Add(bom);
            for (int i = 0; i < 10; i++)
            {
                bomList.Add(new BOM(11000 - i*100, list));
            }#1#

            var pm = new PartManager(ExcelDataReader.PartListFromExcel(@"C:\ISProject\forDemo.xlsx"));
            pm.SelectDescription("TB150*100*3.2");
            List<Part> list = pm.TaskList;
            list.Sort((a, b) => b.Length.CompareTo(a.Length));//내림차순 정렬

            foreach (var part in list)
            {
                Console.WriteLine(part);
            }

            ExcelDataWriter.Write(bomList);
            ExcelDataWriter.OpenFile();
        }


        /*public static List<BOM> CuttingPlan(List<Part> list)
        {
            int[] standards = { 6010, 6510, 7010, 8210, 10010, 10110, 10610, 11310, 12310, 12910 };
            var bomList = new List<BOM>();
            FindOneMax(bomList, list, standards[standards.Length - 1]);
            FindBestBOM(bomList, list, standards);
            return bomList;
        }

        private static void FindOneMax(List<BOM> bomList, List<Part> parts, int maxStandard)
        {
            if (parts.First().Length + parts.Last().Length <= maxStandard) return;

            var bom = new BOM(maxStandard);
            bom.FillPart(parts.First());
            bomList.Add(bom);
            parts.Remove(parts.First());
            FindOneMax(bomList, parts, maxStandard);
        }

        private static void FindBestBOM(List<BOM> bomList, List<Part> parts, int[] standards)
        {
            var tempBomList = new List<BOM>();
            while (parts.Count > 0)
            {
                foreach (var standard in standards)
                    tempBomList.Add(new BOM(standard, FindBestFit(MakeBOMs(parts, standard))));
                if (tempBomList.Count != 0)
                {
                    var bestFitBom = FindMinScrap(tempBomList);
                    bomList.Add(bestFitBom);
                    foreach (var part in bestFitBom.Parts)
                    {
                        parts.Remove(part);
                    }
                }
            }
        }

        //휴리스틱
        private static List<BOM> MakeBOMs(List<Part> parts, int limit)
        {
            List<BOM> boms = new List<BOM>();
            var tempParts = new List<Part>();
            BOM buffer = new BOM(limit);
            bool used = false;

            foreach (var part in parts)
            {
                foreach (var bom in boms)
                {
                    if (bom.Scrap > part.Length)
                    {
                        bom.FillPart(part);
                        break;
                    }
                }

                if (used)
                    used = !used;
                else if (buffer.Scrap > part.Length)
                    buffer.FillPart(part);
                else
                {
                    boms.Add(buffer);
                    buffer = new BOM(limit);
                }
            }
            return boms;
        }

        private static List<Part> FindBestFit(List<BOM> bomList)
        {
            // 가장 작은 scrap을 가진 BOM을 찾기 위한 초기화
            BOM smallestScrapBom = bomList[0];
            foreach (var bom in bomList)
            {
                if (bom.Scrap < smallestScrapBom.Scrap)
                {
                    smallestScrapBom = bom;
                }
            }

            // 가장 작은 scrap을 가진 BOM의 parts 반환
            return smallestScrapBom.Parts;
        }


        /*public static List<Part> FindBestFit(List<Part> parts, int standard)
        {
            List<Part> bestFit = new List<Part>();
            FindFit(parts, standard, new List<Part>(), ref bestFit);
            return bestFit;
        }#2#


        /*private void FindFit(List<Part> parts, int remainingLength, List<Part> currentCombination, ref List<Part> longestCombination)
        {
            if (remainingLength < 0)
                return;

            if (currentCombination.Sum(part => part.Length) > longestCombination.Sum(part => part.Length))
                longestCombination = new List<Part>(currentCombination);

            foreach (var part in parts)
            {
                List<Part> updatedCombination = new List<Part>(currentCombination);
                updatedCombination.Add(part);
                FindFit(parts, remainingLength - part.Length, updatedCombination, ref longestCombination);
            }
        }#2#

        private static BOM FindMinScrap(List<BOM> list)
        {
            if (list == null || list.Count == 0)
                return null;

            BOM minScrapBom = list[0]; // 초기화
            foreach (var bom in list)
            {
                if (bom.Scrap < minScrapBom.Scrap)
                    minScrapBom = bom; // scrap이 더 작은 경우 업데이트
            }
            return minScrapBom;
        }#1#
    }
}*/