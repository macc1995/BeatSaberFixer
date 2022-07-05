using System;

namespace BSFixer
{
   public class Logger : ILogger
   {
      public void LogError(string message)
      {
         Log(message,ConsoleColor.Red);
      }

      public void LogWarning(string message)
      {
         Log(message,ConsoleColor.Yellow);
      }

      public void LogSuccess(string message)
      {
         Log(message,ConsoleColor.Green);
      }

      public void Log(string message)
      {
         Log(message,ConsoleColor.White);
      }

      private void Log(string message, ConsoleColor color)
      {
         Console.ForegroundColor = color;
         Console.WriteLine(message);
         Console.ForegroundColor = ConsoleColor.White;
      }
   }
}