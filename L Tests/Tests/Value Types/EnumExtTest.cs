﻿
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace L_Tests
    {
    [TestClass]
    public class EnumExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(EnumExt) };
        }
    }
