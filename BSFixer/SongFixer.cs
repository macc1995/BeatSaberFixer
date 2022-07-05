using System;
using System.IO;
using System.Linq;

namespace BSFixer
{
   public interface ISongFixer
   {
      void FixSongs(string[] args);
   }

   public class SongFixer : ISongFixer
   {
      private readonly ILogger logger;

      private readonly IFileSystemAccess fileSystemAccess;

      public SongFixer(ILogger logger, IFileSystemAccess fileSystemAccess)
      {
         this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
         this.fileSystemAccess = fileSystemAccess ?? throw new ArgumentNullException(nameof(fileSystemAccess));
      }

      public void FixSongs(string[] args)
      {
         if (!args.Any())
         {
            logger.LogError("Pull a folder on the exe DUMBASS");
            Console.ReadLine();
            return;
         }

         var directories = fileSystemAccess.EnumerateDirectories(args[0]).ToList();
         if (!directories.Any())
         {
            logger.LogError("The folder is empty..");
         }

         var count = 0;
         foreach (var directory in directories)
         {
            var files = fileSystemAccess.EnumerateFiles(directory).Where(x=>Path.GetExtension(x) == ".dat");
            foreach (var file in files)
            {
               var lines = fileSystemAccess.ReadAllLines(file).ToList();
               var hasChange = false;
               for (var i = 0; i < lines.Count; i++)
               {
                  var line = lines[i].ToLowerInvariant();
                  if (line.Contains("version\"") && (line.Contains(" :") || line.Contains(": ")))
                  {
                     lines[i] = line.Replace(" :", ":").Replace(": ", ":");
                     hasChange = true;
                     count++;
                  }

               }

               if (hasChange)
               {
                  fileSystemAccess.WriteAllLines(file,lines);
               }

            }
         }

         if (count > 0)
         {
            logger.LogSuccess($"Success! {count} files fixed! have fun!");
         }
         else { logger.LogWarning("no files were fixed");}

      }
   }
}