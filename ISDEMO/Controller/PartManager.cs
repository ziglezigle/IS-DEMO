using System.Collections.Generic;
using System.Text.RegularExpressions;
using ISDEMO.model;

namespace ISDEMO.Controller;

public class PartManager
{
    private List<Part> originalList, taskList;
    private Description desc;

    public PartManager(List<Part> list)
    {
        originalList = list;
        taskList = new List<Part>();
    }

    public List<Part> OriginalList
    {
        get => originalList;
        set => originalList = value;
    }

    public List<Part> TaskList
    {
        get => taskList;
        set => taskList = value;
    }

    public void SelectDescription(string value)
    {
        var type = Regex.Match(value, @"^[^\d]+").Value;
        var size = Regex.Match(value, @"[\d\*\.]+").Value;
        desc = new Description(type, size);
        MakeTask();
    }
    
    private void MakeTask()
    {
        foreach (var part in originalList)
        {
            if (part.Desc.Type.Equals(desc.Type) && part.Desc.Size.Length == desc.Size.Length
                                                 && part.Desc.Size.Equals(desc.Size))
            { 
                taskList.Add(part);
            }
        }
    }

    /*private void MakeTask()
    {
        foreach (var part in originalList)
        {
            if (part.Desc.Type.Equals(desc.Type) && part.Desc.Size.Length == desc.Size.Length
                                                 && part.Desc.Size.Equals(desc.Size))
            {
                if(part.Num > 1)
                {
                    for (int i = 0; i < part.Num; i++)
                    {
                        taskList.Add(part.CloneOne());
                    }
                }else
                    taskList.Add(part);
            }
        }
    }*/
}