using System;
using System.Collections.Generic;
using LCore.Extensions;
using System.Reflection;

namespace LCore.Tests
    {
    public class TestBoundAttribute : TestAttribute
        {
        public readonly uint ParameterIndex;
        public readonly object Minimum;
        public readonly object Maximum;
        public readonly bool TestBounds;

        public TestBoundAttribute(uint ParameterIndex,
            object Minimum,
            object Maximum,
            bool TestBounds = true)
            {
            this.ParameterIndex = ParameterIndex;
            this.Minimum = Minimum;
            this.Maximum = Maximum;
            this.TestBounds = TestBounds;
            }

        public override void RunTest(MethodInfo Method)
            {
            var Attributes = new List<TestBoundAttribute>();

            Attributes.Sort(Attr => Attr.ParameterIndex);

            ParameterInfo[] MethodParameters = Method.GetParameters();

            var PassedParameters = new object[MethodParameters.Length];


            Attributes.Each(Attr => 
                PassedParameters[Attr.ParameterIndex] = 
                    L.Ref.NewRandom(MethodParameters[Attr.ParameterIndex].ParameterType, Attr.Minimum, Attr.Maximum));


            }
        }
    }