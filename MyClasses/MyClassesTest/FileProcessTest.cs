using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        [TestMethod]
        public void FileNameDoesExist()
        {
            Assert.Inconclusive();

        }
        [TestMethod]
        public void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall = fp.FileExists(@"C:\Windows\BadFileName.bad");
            Assert.IsTrue(fromCall);
           
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            FileProcess fp = new FileProcess();
            fp.FileExists("");
        }

        [TestMethod]
        
        public void FileNameNullOrEmpty_ThrowsArgumentNullExceptionUsingTryCatch()
        {
            FileProcess fp = new FileProcess();
            try
            {
                fp.FileExists("");
            }
            catch (ArgumentNullException e)
            {
                //The Test was a success
                return;
            }
            Assert.Fail("Call to FIleExists did Not Throw an ArgumentNullException ");
        }
    }
}
