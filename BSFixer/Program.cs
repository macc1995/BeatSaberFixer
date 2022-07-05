using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BSFixer
{
   class Program
   {
      static void Main(string[] args)
      {
         
         var logger = new Logger();
         var fileSystemAccess = new FileSystemAccess();
         logger.Log("press enter to start");
         Console.ReadLine();
         var fixer = new SongFixer(logger,fileSystemAccess);
         fixer.FixSongs(args);
         logger.Log("Press enter to close");
         Console.ReadLine();
      }

      
   }
}
