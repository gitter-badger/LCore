using System;
using System.Collections.Generic;
using LCore.Extensions;
using System.Reflection;
using JetBrains.Annotations;

namespace LCore.Tests
    {
    /// <summary>
    /// Applies a maximum and/or minimum bound to the parameter at the specified index.
    /// </summary>
    public class TestBoundAttribute : TestAttribute
        {
        /// <summary>
        /// The 0-based index of the parameter you're applying a bound to.
        /// </summary>
        public uint ParameterIndex { get; }

        /// <summary>
        /// The Minimum bound for this parameter (optional)
        /// </summary>
        public object Minimum { get; }

        /// <summary>
        /// The Maximum bound for this parameter (optional)
        /// </summary>
        public object Maximum { get; }

        /// <summary>
        /// The type of value used for the Minimum and Maximum
        /// </summary>
        public Type ValueType { get; }


        /// <summary>
        /// Tests the method this many times with random data in addition to ensuring 
        /// the bound values don't fail.
        /// </summary>
        public uint TestWithinBounds { get; set; }

        /// <summary>
        /// Implement this method to execute the test.
        /// Make assertions here.
        /// </summary>
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

        #region Constructors



        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for <paramref name="ParameterIndex"/> (0-based index of parameter)
        /// 
        /// </summary>
        public TestBoundAttribute(uint ParameterIndex,
            int Minimum,
            int Maximum) : this(Minimum, Maximum)
            {
            this.ParameterIndex = ParameterIndex;
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for <paramref name="ParameterIndex"/> (0-based index of parameter)
        /// 
        /// </summary>
        public TestBoundAttribute(uint ParameterIndex,
            uint Minimum,
            uint Maximum) : this(Minimum, Maximum)
            {
            this.ParameterIndex = ParameterIndex;
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for <paramref name="ParameterIndex"/> (0-based index of parameter)
        /// 
        /// </summary>
        public TestBoundAttribute(uint ParameterIndex,
            long Minimum,
            long Maximum) : this(Minimum, Maximum)
            {
            this.ParameterIndex = ParameterIndex;
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for <paramref name="ParameterIndex"/> (0-based index of parameter)
        /// 
        /// </summary>
        public TestBoundAttribute(uint ParameterIndex,
            ulong Minimum,
            ulong Maximum) : this(Minimum, Maximum)
            {
            this.ParameterIndex = ParameterIndex;
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for <paramref name="ParameterIndex"/> (0-based index of parameter)
        /// 
        /// </summary>
        public TestBoundAttribute(uint ParameterIndex,
            short Minimum,
            short Maximum) : this(Minimum, Maximum)
            {
            this.ParameterIndex = ParameterIndex;
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for <paramref name="ParameterIndex"/> (0-based index of parameter)
        /// 
        /// </summary>
        public TestBoundAttribute(uint ParameterIndex,
            ushort Minimum,
            ushort Maximum) : this(Minimum, Maximum)
            {
            this.ParameterIndex = ParameterIndex;
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for <paramref name="ParameterIndex"/> (0-based index of parameter)
        /// 
        /// </summary>
        public TestBoundAttribute(uint ParameterIndex,
            byte Minimum,
            byte Maximum) : this(Minimum, Maximum)
            {
            this.ParameterIndex = ParameterIndex;
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for <paramref name="ParameterIndex"/> (0-based index of parameter)
        /// 
        /// </summary>
        public TestBoundAttribute(uint ParameterIndex,
            sbyte Minimum,
            sbyte Maximum) : this(Minimum, Maximum)
            {
            this.ParameterIndex = ParameterIndex;
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for <paramref name="ParameterIndex"/> (0-based index of parameter)
        /// 
        /// </summary>
        public TestBoundAttribute(uint ParameterIndex,
            decimal Minimum,
            decimal Maximum) : this(Minimum, Maximum)
            {
            this.ParameterIndex = ParameterIndex;
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for <paramref name="ParameterIndex"/> (0-based index of parameter)
        /// 
        /// </summary>
        public TestBoundAttribute(uint ParameterIndex,
            double Minimum,
            double Maximum) : this(Minimum, Maximum)
            {
            this.ParameterIndex = ParameterIndex;
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for <paramref name="ParameterIndex"/> (0-based index of parameter)
        /// 
        /// </summary>
        public TestBoundAttribute(uint ParameterIndex,
            float Minimum,
            float Maximum) : this(Minimum, Maximum)
            {
            this.ParameterIndex = ParameterIndex;
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for <paramref name="ParameterIndex"/> (0-based index of parameter)
        /// 
        /// </summary>
        public TestBoundAttribute(uint ParameterIndex,
            [CanBeNull]object Minimum,
            [CanBeNull]object Maximum) : this(Minimum, Maximum)
            {
            this.ParameterIndex = ParameterIndex;
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for ParameterIndex (0-based index of parameter)
        /// 
        /// </summary>
        protected TestBoundAttribute([CanBeNull]object Minimum, [CanBeNull]object Maximum)
            {
            this.Minimum = Minimum;
            this.Maximum = Maximum;
            this.ValueType = (Minimum ?? Maximum)?.GetType();
            }
        #endregion
        }
    }