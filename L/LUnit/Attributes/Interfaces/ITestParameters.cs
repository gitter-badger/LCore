using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;

namespace LCore.LUnit
    {
    public interface ITestParameters: ILUnitAttribute
        {
        /// <summary>
        /// Parameters for the current test
        /// </summary>
        object[] Parameters { get; }
        }
    }