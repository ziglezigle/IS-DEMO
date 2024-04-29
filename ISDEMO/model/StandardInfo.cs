using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Documents;

namespace ISDEMO.model;

public class StandardInfo
{
    private Description desc;
    private int unitWeight;
    private List<double> length;
    
    public StandardInfo() {}

    public StandardInfo(Description desc, int weight, List<double> length)
    {
        this.desc = desc;
        unitWeight = weight;
        this.length = length;
    }
    
    

    public static StandardInfo StringToStandardInfo(string line)
    {
        string[] data = line.Split(" ");
        var type = Regex.Match(data[0], @"^[^\d]+").Value;
        var size = Regex.Match(data[0], @"[\d\*]+").Value;
        var desc = new Description(type, size);
        
        // Unit Weight 파싱
        var unitWeight = int.Parse(data[1]);

        // Lengths 파싱
        var lengthsData = data[2].Split(",");
        var lengths = new List<double>();
        foreach (var lengthStr in lengthsData)
        {
            lengths.Add(double.Parse(lengthStr));
        }
        return new StandardInfo(desc, unitWeight, lengths);
    }

    public override string ToString()
    {
        var result = desc + " " + unitWeight + " ";
        result += string.Join(",", length.Select(x => x.ToString()));

        return result;
    }
}