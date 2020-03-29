using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
namespace MyClassesTest
{
    [TestClass]
    public class StringAssertClassTest
    {
        [TestMethod]
        [Owner("Nayden")]
        public void ContainsTest()
        {
            string str1 = "Nayden Luiz";
            string str2 = "Luiz";
            StringAssert.Contains(str1, str2);
        }

        [TestMethod]
        [Owner("Nayden")]
        public void StartsWithTest()
        {
            string str1 = "All Lower Case";
            string str2 = "All Lower";
            StringAssert.StartsWith(str1, str2);
        }
        [TestMethod]
        [Owner("Nayden")]
        public void IsAllLowerCaseTest()
        {
            Regex r = new Regex(@"^([^A-Z])+$");
            StringAssert.Matches("all lower case", r);
        }
        [TestMethod]
        [Owner("Nayden")]
        public void IsNotAllLowerCaseTest()
        {
            Regex r = new Regex(@"^([^A-Z])+$");
            StringAssert.DoesNotMatch("All Lower case",r);
        }


    }
}
