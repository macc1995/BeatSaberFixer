using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSFixer;
using FluentAssertions;
using Moq;

namespace BSFixerTests.SongFixer
{
   [TestClass]
   public class CtorTests
   {
      [TestMethod]
      public void Ctor_WhenLoggerIsNull_ShouldThrowException()
      {
         Action act = () => new BSFixer.SongFixer(null, new Mock<IFileSystemAccess>().Object);

         act.Should().Throw<ArgumentNullException>().WithParameterName("logger");
      }

      [TestMethod]
      public void Ctor_WhenFileSystemAccessIsNull_ShouldThrowException()
      {
         Action act = () => new BSFixer.SongFixer(new Mock<ILogger>().Object, null);

         act.Should().Throw<ArgumentNullException>().WithParameterName("fileSystemAccess");
      }

   }
}
