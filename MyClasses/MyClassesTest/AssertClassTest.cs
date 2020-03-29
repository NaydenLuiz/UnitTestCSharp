﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    /// <summary>
    /// Summary description for AssertClassTest
    /// </summary>
    [TestClass]
    public class AssertClassTest
    {
        #region AreEqual/AreNotEqual Tests
        [TestMethod]
        [Owner("PaulS")]
        public void AreEqualTest()
        {
            string str1 = "Paul";
            string str2 = "Paul";
            Assert.AreEqual(str1, str2);

        }

        [TestMethod]
        [Owner("JohnK")]
        [ExpectedException(typeof(AssertFailedException))]
        public void AreEqualCaseSensitiveTest()
        {
            string str1 = "Paul";
            string str2 = "paul";
            Assert.AreEqual(str1, str2,false);
        }
        [TestMethod]
        [Owner("JohnK")]   
        public void AreNotEqualTest()
        {
            string str1 = "Paul";
            string str2 = "John";
            Assert.AreNotEqual(str1, str2);
        }

        #endregion
        #region AreSame/AreNotSame Tests
        [TestMethod]
        [Owner("PaulS")]
        public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();
            Assert.AreSame(x,y);

        }
        [TestMethod]
        [Owner("JohnK")]
        public void AreNotSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();
            Assert.AreNotSame(x, y);

        }
        #endregion

        #region IsInstanceOfType Test
        [TestMethod]
        [Owner("PaulS")]
        public void IsInstanceOfTypeTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;
            per = mgr.CreatePerson("Paul", "Sheriff", true);
            Assert.IsInstanceOfType(per, typeof(Supervisor));


        }


        #endregion

        #region IsNull Test
        [TestMethod]
        [Owner("JhonK")]
        public void IsNullTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;
            per = mgr.CreatePerson("","Sheriff",true);
            Assert.IsNull(per);
        }
        #endregion
    }
}
