using System.Reflection;
using LCore.Extensions;

namespace LCore.Tests
    {
    /// <summary>
    /// Interface denotes a test attribute. 
    /// Used to determine which methods are tested and untested.
    /// </summary>
    public interface ITestAttribute : ITopLevelAttribute
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
        }
    }