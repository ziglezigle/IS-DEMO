namespace ISDEMO.model;

public class ReportInfo
{
    public ReportInfo(string assem, string mark, double weightOne, double weightSum, double perArea)
    {
        Assem = assem;
        Mark = mark;
        WeightOne = weightOne;
        WeightSum = weightSum;
        PerArea = perArea;
    }

    public string Assem { get; set; }
    public string Mark { get; set; }
    public double WeightOne { get; set; }
    public double WeightSum { get; set; }
    public double PerArea { get; set; }
}