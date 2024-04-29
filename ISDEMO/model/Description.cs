using System.Text.RegularExpressions;

namespace ISDEMO.model;

public class Description
{
    private string type;
    private string size;
    private double[] sizeParts;

    public Description(string type, string size)
    {
        this.type = type;
        this.size = size;
        SizePartsMaker(size);
    }

    public string Type
    {
        get => type;
        set => type = value;
    }

    public string Size
    {
        get => size;
        set => size = value;
    }

    public double[] SizeParts
    {
        get => sizeParts;
        set => sizeParts = value;
    }

    public override string ToString()
    {
        return type + size;
    }

    private double[] SizePartsMaker(string value)
    {
        string[] parts = value.Split("*");
        sizeParts = new double[parts.Length];
        for (int i = 0; i < sizeParts.Length; i++)
        {
            if (int.TryParse(parts[i], out int intValue))
            {
                sizeParts[i] = intValue;
            }
        }

        return sizeParts;
    }
}

