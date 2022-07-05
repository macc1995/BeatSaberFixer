using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;


namespace BSFixerTests.SongFixer
{
   using BSFixerTests.Setup;
   [TestClass]
   public class FixSongsTests
   {
      [TestMethod]
      public void FixSongs_WhenNoArgumentIsGiven_ShouldLogError()
      {
         var fileSystemAccess = Setup.MockFor().FileSystemAccess().DoneMock();
         var logger = Setup.MockFor().Logger().DoneMock();
         var classUnderTest = new BSFixer.SongFixer(logger.Object, fileSystemAccess.Object);

         //classUnderTest.FixSongs(new string[0]);
         //logger.Verify(x=>x.LogError("Pull a folder on the exe DUMBASS"), Times.Once);
         //TODO refactor Console.Readline...
      }
   }
}
