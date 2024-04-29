namespace ISDEMO.model;

public class PreArrangementInfo
{
    public PreArrangementInfo(string material, string size, string type)
    {
        Material = material;
        Size = size;
        Type = type;
    }

    public string Material { get; set; }
    public string Size { get; set; }
    public string Type { get; set; }
}