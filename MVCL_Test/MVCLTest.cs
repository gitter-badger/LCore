﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singularity.Controllers;
using System.Web.Mvc;

namespace Singularity_Test
    {
    [TestClass]
    public class SingularityTest
        {
        [TestMethod]
        public void TestController()
            {
            TestController Test = new TestController();
            }

        public void TestController_JavascriptTest()
            {
            TestController Test = new TestController();

            Assert.AreEqual(Test.JavascriptTest() is ActionResult, true);
            }
        }
    }
