using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System.Configuration;
using System.IO;

namespace MyClassesTest
{
    [TestClass]
    public  class FileProcessTest
    {
        const string BAD_FILE_NAME = @"C:\BadFileName.bad";
        private static string _GoodFileName;
       
        #region Class Initialize and CleanUp
        [ClassInitialize]
        public static void ClassInitialize(TestContext tc)
        {
            tc.WriteLine("In the class Initialize.");
        }
        [ClassCleanup]
        public static void ClassCleanUp()
        {
           
        }
        #endregion
       
        #region Test |Initialize and CleanUp
        [TestInitialize]
        public  void TestInitialize()
        {
            if (TestContext.TestName.StartsWith( "FileNameDoesExist"))
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Creating File:" + _GoodFileName);
                    File.AppendAllText(_GoodFileName, "Some Text");
                }
            }
        }
        [TestCleanup]
        public  void TestCleanUp()
        {
            if (TestContext.TestName == "FileNameDoesExist")
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Deleting File:" + _GoodFileName);
                    File.Delete(_GoodFileName);
                }
            }
        }

        [TestMethod]
        [DataSource("System.Data.SqlClient","Database=SandBox;Integrated Security=Yes", "tests.FileProcessTest", DataAccessMethod.Sequential)]
        public void FileExistsTestFromDB()
        {
            FileProcess fp = new FileProcess();
            string filename;
            bool expectedValue;
            bool causesException;
            bool fromCall;


            filename = TestContext.DataRow["FileName"].ToString();
            expectedValue = Convert.ToBoolean(TestContext.DataRow["ExpectedValue"]);
            causesException = Convert.ToBoolean(TestContext.DataRow["CausesException"]);

            try
            {
                fromCall = fp.FileExists(filename);
                Assert.AreEqual(expectedValue, fromCall, "File Name: " + filename + " has Failed it's existence test in test: FileExistsTestFromDB()");
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException)
            {
                Assert.IsTrue(causesException);
            }

        }


        [TestMethod]
        public void FileNameDoesExistSimpleMessage()
        {
            FileProcess fp = new FileProcess();
            bool fromcall;
            fromcall = fp.FileExists(_GoodFileName);
            Assert.IsFalse(fromcall, "File Does Not Exist");
        }
        [TestMethod]
        public void FileNameDoesExistSimpleMessageWithFormatting()
        {
            FileProcess fp = new FileProcess();
            bool fromcall;
            fromcall = fp.FileExists(_GoodFileName);
            Assert.IsFalse(fromcall, "File {0} Does Not Exist",_GoodFileName);
        }


        #endregion
        public TestContext TestContext { get; set; }
        [TestMethod]
        [Description("Check to see if a file does exist.")]
        [Owner("Nayden Luiz")]
        [Priority(0)]
        [TestCategory("No Exception")]
        public  void FileNameDoesExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;
            SetGoodFileName();
            //TestContext.WriteLine("Creating the file :" + _GoodFileName);
            //File.AppendAllText(_GoodFileName, "Some Text");
            TestContext.WriteLine("Testing the file :" + _GoodFileName);
            fromCall = fp.FileExists(@"C:\Windows\Regedit.exe");
            //File.Delete(_GoodFileName);
            //TestContext.WriteLine("Deleting the file :" + _GoodFileName);
            Assert.IsTrue(fromCall);

        }
        [TestMethod]
        [Description("Check to see if a file does not exist.")]
        [Owner("Nayden Luiz")]
        [Priority(3)]
        [TestCategory("No Exception")]
        public  void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall = fp.FileExists(BAD_FILE_NAME);
            Assert.IsFalse(fromCall);
           
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Priority(1)]
        [TestCategory("Exception")]
        public  void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            FileProcess fp = new FileProcess();
            fp.FileExists("");
        }

        [TestMethod]
        [Timeout(5000)]
        public void SimulateTImeOut()
        {
            System.Threading.Thread.Sleep(4000);
        }
        private const string FILE_NAME = @"FileToDeploy.txt";
        [TestMethod]
        [Owner("Nayden")]
        [DeploymentItem(FILE_NAME)]
        public void FileNameDoesExistUsingDeploymentItem()
        {
            FileProcess fp = new FileProcess();
            string filename;
            bool fromcall;

            filename = TestContext.DeploymentDirectory + @"\" + FILE_NAME;
            TestContext.WriteLine("Checking file:" + filename);

            fromcall = fp.FileExists(filename);
            Assert.IsTrue(fromcall);

        }

        [TestMethod]
        [Owner("Nayden Luiz")]
        [Priority(2)]
        [TestCategory("Exception")]
        public  void FileNameNullOrEmpty_ThrowsArgumentNullExceptionUsingTryCatch()
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

        public  void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];
            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]", 
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

    }
}
