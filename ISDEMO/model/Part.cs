using System;

namespace ISDEMO.model;

public class Part : IComparable<Part>
{
    private string assem, mark, material;
    private int length, num;
    private double weightOne, weightSum, pArea;
    private Description desc;
    
    public Part() {}
    
    public Part(string assem, string mark, Description desc, int length, int num, 
        double weightOne, double weightSum, double pArea, string material)
    {
        this.assem = assem;
        this.mark = mark;
        this.desc = desc;
        this.length = length;
        this.num = num;
        this.weightOne = weightOne;
        this.weightSum = weightSum;
        this.pArea = pArea;
        this.material = material;
    }
    
    public string Assem
    {
        get => assem;
        set => assem = value;
    }

    public string Mark
    {
        get => mark;
        set => mark = value;
    }

    public string Material
    {
        get => material;
        set => material = value;
    }

    public int Length
    {
        get => length;
        set => length = value;
    }

    public int Num
    {
        get => num;
        set => num = value;
    }

    public double WeightOne
    {
        get => weightOne;
        set => weightOne = value;
    }

    public double WeightSum
    {
        get => weightSum;
        set => weightSum = value;
    }

    public double PArea
    {
        get => pArea;
        set => pArea = value;
    }

    public Description Desc
    {
        get => desc;
        set => desc = value;
    }

    /*public override string ToString()
    {
        return assem + " " + mark + " " + desc + " " + length + " " + num + " " + weightOne + " " + weightSum + " " +
               pArea + " " + material;
    }*/

    public Part CloneOne()
    {
        return new Part(assem, mark, desc, length, 1, weightOne, weightSum, pArea, material);
    }
    public override string ToString()
    {
        return assem + "    " + mark + "   " + length + "   " + num;
    }

    public int CompareTo(Part? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return length.CompareTo(other.length);
    }
}