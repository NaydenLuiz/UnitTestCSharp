using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyClassesTest
{
    /// <summary>
    /// Assembly Initialize and Cleanup  Methods
    /// </summary>
    [TestClass]
    public class MyClaessesTestInitialization
    {
      [AssemblyInitialize]
      public static void AssemblyInitialize(TestContext tc)
        {
            tc.WriteLine("In the Assembly Intialize Method.");
            //TODO: Create Resources Needed for your tests.

        }
        [AssemblyCleanup]
        public static void AssemblyCleanUo()
        {
            //TODO: Clean Up any resources used by your tests.
        }

     
    }
}
