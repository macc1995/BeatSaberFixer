using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSFixer
{
   class Program
   {
      static void Main(string[] args)
      {
         
         var logger = new Logger();
         logger.Log("press enter to start");
         Console.ReadLine();
         var fixer = new SongFixer(logger);
         fixer.FixSongs(args);
         logger.Log("Press enter to close");
         Console.ReadLine();
      }

      
   }

   public class SongFixer
   {
      private readonly ILogger logger;

      public SongFixer(ILogger logger)
      {
         this.logger = logger;
      }

      public void FixSongs(string[] args)
      {
         if (!args.Any())
         {
            logger.LogError("Pull a folder on the exe DUMBASS");
            Console.ReadLine();
            return;
         }

         var directories = Directory.EnumerateDirectories(args[0]).ToList();
         if (!directories.Any())
         {
            logger.LogError("The folder is empty..");
         }

         var count = 0;
         foreach (var directory in directories)
         {
            var files = Directory.EnumerateFiles(directory).Where(x=>Path.GetExtension(x) == ".dat");
            foreach (var file in files)
            {
               var lines = File.ReadAllLines(file);
               var hasChange = false;
               for (var i = 0; i < lines.Length; i++)
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
                  File.WriteAllLines(file,lines);
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
