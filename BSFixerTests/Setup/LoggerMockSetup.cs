using BSFixer;
using Moq;

namespace BSFixerTests.Setup
{
   public class LoggerMockSetup
   {
      private readonly Mock<ILogger> mock = new Mock<ILogger>();

      public ILogger Done()
      {
         return mock.Object;
      }

      public Mock<ILogger> DoneMock()
      {
         return mock;
      }
   }
}