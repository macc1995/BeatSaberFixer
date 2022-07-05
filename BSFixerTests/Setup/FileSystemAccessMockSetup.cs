using System.Collections.Generic;
using BSFixer;
using Moq;

namespace BSFixerTests.Setup
{
   public class FileSystemAccessMockSetup
   {
      private readonly Mock<IFileSystemAccess> mock = new Mock<IFileSystemAccess>();

      public IFileSystemAccess Done()
      {
         return mock.Object;
      }

      public Mock<IFileSystemAccess> DoneMock()
      {
         return mock;
      }

      public FileSystemAccessMockSetup WithReadAllLines(IEnumerable<string> result)
      {
         mock.Setup(x => x.ReadAllLines(It.IsAny<string>())).Returns(result);
         return this;
      }


      public FileSystemAccessMockSetup WithEnumerateDirectories(IEnumerable<string> result)
      {
         mock.Setup(x => x.EnumerateDirectories(It.IsAny<string>())).Returns(result);
         return this;
      }

      public FileSystemAccessMockSetup WithEnumerateFiles(IEnumerable<string> result)
      {
         mock.Setup(x => x.EnumerateFiles(It.IsAny<string>())).Returns(result);
         return this;
      }
   }
}