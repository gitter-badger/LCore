using System;
using System.Collections.Generic;
using LCore.Extensions;
using JetBrains.Annotations;

namespace LCore.LUnit
    {
    /// <summary>
    /// Applies a maximum and/or minimum bound to the parameter at the specified index.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class TestBoundAttribute : Attribute, ITestBoundAttribute
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
            [CanBeNull] object Minimum,
            [CanBeNull] object Maximum) : this(Minimum, Maximum)
            {
            this.ParameterIndex = ParameterIndex;
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for ParameterIndex (0-based index of parameter)
        /// 
        /// </summary>
        protected TestBoundAttribute([CanBeNull] object Minimum, [CanBeNull] object Maximum)
            {
            this.Minimum = Minimum;
            this.Maximum = Maximum;
            this.ValueType = (Minimum ?? Maximum)?.GetType();
            }

        #endregion
        }
    }