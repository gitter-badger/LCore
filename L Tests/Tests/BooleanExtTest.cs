
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace L_Tests
    {
    [TestClass]
    public class BooleanExtTest
        {
        public BooleanExtTest(TestContext TestContext)
            {
            }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestMethod]
        public void BooleanExtTests()
            {

            Func<DayOfWeek, int> DateTime_GetDayNumber = L.F<DayOfWeek, int>()
                    .Case(DayOfWeek.Sunday, 0)
                    .Case(DayOfWeek.Monday, 1)
                    .Case(DayOfWeek.Tuesday, 2)
                    .Case(DayOfWeek.Wednesday, 3)
                    .Case(DayOfWeek.Thursday, 4)
                    .Case(DayOfWeek.Friday, 5)
                    .Case(DayOfWeek.Saturday, 6)
                    .Else(Logic.Fail).Debug();

            DateTime_GetDayNumber(DayOfWeek.Sunday);

            Debug.Write("BooleanExt Tests Running \r\n");
            typeof(BooleanExt).RunTypeTests();
            }
        }
    }
