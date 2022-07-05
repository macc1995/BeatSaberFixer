using System.Collections.Generic;
using System.IO;

namespace BSFixer
{
   public class FileSystemAccess : IFileSystemAccess {
      public IEnumerable<string> EnumerateDirectories(string path)
      {
         return Directory.EnumerateDirectories(path);
      }

      public IEnumerable<string> EnumerateFiles(string path)
      {
         return Directory.EnumerateFiles(path);
      }

      public IEnumerable<string> ReadAllLines(string path)
      {
         return File.ReadAllLines(path);
      }

      public void WriteAllLines(string path, IEnumerable<string> content)
      {
         File.WriteAllLines(path,content);
      }
   }
}