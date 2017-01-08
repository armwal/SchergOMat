using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowrunEngine.ChummerInterfaces
{
    public interface IFileAccess
    {
        string GetPathFromStartup(string relativePath);
        DateTime GetLastWriteTime(string path);
        IEnumerable<string> GetFilesInDirectory(string directory, string pattern);
    }
}
