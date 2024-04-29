using System.Collections.Generic;

namespace ISDEMO.Controller
{
    public interface FileManager<T>
    {
        public List<T> ReadFile(string file);
        public void WriteFile(List<T> list);
    }
}

