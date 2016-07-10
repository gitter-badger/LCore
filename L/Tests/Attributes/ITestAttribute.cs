using System;
using System.Reflection;
using LCore.Extensions;
using LCore.Interfaces;

namespace LCore.Tests
    {
    /// <summary>
    /// Interface denotes a test attribute. 
    /// Used to determine which methods are tested and untested.
    /// </summary>
    public interface ITestAttribute : ITopLevelAttribute, IReverseAttributeOrder
        {
        /// <summary>
        /// Attempts to resolve parameter types for a method test.
        /// This corrects parameter types, converts arrays to lists if needed.
        /// </summary>
        void FixParameterTypes(MethodInfo Method);
        /// <summary>
        /// Implement this method to execute the test.
        /// Make assertions here.
        /// </summary>
        void RunTest(MethodInfo Method);
        /// <summary>
        /// Generic types defined on the current method
        /// </summary>
        Type[] GenericTypes { get; set; }
        }
    }