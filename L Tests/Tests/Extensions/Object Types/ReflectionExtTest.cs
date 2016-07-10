
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace L_Tests.Tests.Extensions
    {
    [TestClass]
    public class ReflectionExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(ReflectionExt) };
        }
    }
