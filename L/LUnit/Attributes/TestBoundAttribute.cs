using System;
using System.Collections.Generic;
using LCore.Extensions;
using JetBrains.Annotations;
// ReSharper disable RedundantCast

namespace LCore.LUnit
    {
    /// <summary>
    /// Applies a maximum and/or minimum bound to the parameter at the specified index.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
    public class TestBoundAttribute : Attribute, ITestBoundAttribute
        {
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
        /// values used for the parameter.
        /// </summary>
        public TestBoundAttribute(int Minimum, int Maximum) : this((object)Minimum, (object)Maximum)
            {
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for the parameter.
        /// 
        /// </summary>
        public TestBoundAttribute(uint Minimum, uint Maximum) : this((object)Minimum, (object)Maximum)
            {
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for the parameter.
        /// </summary>
        public TestBoundAttribute(long Minimum, long Maximum) : this((object)Minimum, (object)Maximum)
            {
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for the parameter.
        /// </summary>
        public TestBoundAttribute(ulong Minimum, ulong Maximum) : this((object)Minimum, (object)Maximum)
            {
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for the parameter.
        /// </summary>
        public TestBoundAttribute(short Minimum, short Maximum) : this((object)Minimum, (object)Maximum)
            {
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for the parameter.
        /// </summary>
        public TestBoundAttribute(ushort Minimum, ushort Maximum) : this((object)Minimum, (object)Maximum)
            {
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for the parameter.
        /// </summary>
        public TestBoundAttribute(byte Minimum, byte Maximum) : this((object)Minimum, (object)Maximum)
            {
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for the parameter.
        /// </summary>
        public TestBoundAttribute(sbyte Minimum, sbyte Maximum) : this((object)Minimum, (object)Maximum)
            {
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for the parameter.
        /// </summary>
        public TestBoundAttribute(decimal Minimum, decimal Maximum) : this((object)Minimum, (object)Maximum)
            {
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for the parameter.
        /// </summary>
        public TestBoundAttribute(double Minimum, double Maximum) : this((object)Minimum, (object)Maximum)
            {
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for the parameter.
        /// </summary>
        public TestBoundAttribute(float Minimum, float Maximum) : this((object)Minimum, (object)Maximum)
            {
            }

        /// <summary>
        /// Sets the <paramref name="Minimum"/> and <paramref name="Minimum"/> 
        /// values used for the parameter.
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