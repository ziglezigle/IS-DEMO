using System;

namespace ISDEMO.Test;

public class DManager : EManager
{
    public void read()
    {
        Console.WriteLine("DManager read");
        dd();
    }

    public void write()
    {
        Console.WriteLine("Dmanager write");
    }

    private void dd()
    {
        Console.WriteLine("hello");
    }
}