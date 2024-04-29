namespace ISDEMO.model;

public class PartArrangementInfo
{
    PartArrangementInfo()
    {}
    
    public PartArrangementInfo(int length, int number)
    {
        Length = length;
        Number = number;
    }
    

    public int Length { get; set; }
    public int Number { get; set; }
}