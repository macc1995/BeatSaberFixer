using System.Collections.Generic;

namespace BSFixer
{
   public interface IFileSystemAccess
   {
      IEnumerable<string> EnumerateDirectories(string path);
      IEnumerable<string> EnumerateFiles(string path);
      IEnumerable<string> ReadAllLines(string path);
      void WriteAllLines(string path, IEnumerable<string> content);
   }
}