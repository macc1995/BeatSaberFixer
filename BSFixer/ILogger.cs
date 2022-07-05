namespace BSFixer
{
   public interface ILogger
   {
      void LogError(string message);
      void LogWarning(string message);
      void LogSuccess(string message);
      void Log(string message);
   }
}