
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace L_Tests
{
    [TestClass]
    public class InterfaceExtTest : ExtensionTester
        {
        protected override Type TestType => typeof(InterfaceExt);
        }
    }
