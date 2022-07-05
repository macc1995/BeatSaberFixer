namespace BSFixerTests.Setup
{
   public class MockSetup
   {
      public FileSystemAccessMockSetup FileSystemAccess()
      {
         return new FileSystemAccessMockSetup();
      }

      public LoggerMockSetup Logger()
      {
         return new LoggerMockSetup();
      }
   }
}