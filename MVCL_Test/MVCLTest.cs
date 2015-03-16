using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCL.Controllers;
using System.Web.Mvc;

namespace MVCL_Test
{
    [TestClass]
    public class MVCLTest
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
