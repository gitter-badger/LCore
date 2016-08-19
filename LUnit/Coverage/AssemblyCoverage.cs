using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using JetBrains.Annotations;
using LCore.Extensions;

namespace LCore.LUnit
    {
    /// <summary>
    /// Represents Assembly coverage information, given an Assembly 
    /// to be tested, along with any Test Assemblies covering it.
    /// </summary>
    public class AssemblyCoverage
        {
        /// <summary>
        /// The Assembly being tested
        /// </summary>
        public Assembly CoveringAssembly { get; }

        /// <summary>
        /// The total coverage percent, a uint value from 0 to 100.
        /// </summary>
        public uint TotalCoverage =>
            (uint)this.TypeCoverage.Convert(Member => Member.CoveragePercent).Average().Round();

        /// <summary>
        /// Information about the Type Coverage within the assembly.
        /// </summary>
        public ReadOnlyCollection<TypeCoverage> TypeCoverage { get; }

        private ReadOnlyCollection<Assembly> _TestAssemblies { get; }

        /// <summary>
        /// Creates an AssemblyCoverage from an Assembly  to be tested, 
        /// along with any Test Assemblies covering it.
        /// </summary>
        public AssemblyCoverage(Assembly CoveringAssembly, [CanBeNull]params Assembly[] TestAssemblies)
            {
            this.CoveringAssembly = CoveringAssembly;
            this._TestAssemblies = (TestAssemblies ?? new Assembly[] { }).List().AsReadOnly();

            this.TypeCoverage = CoveringAssembly.GetExportedTypes().List()
                .WithoutAttribute<ExcludeFromCodeCoverageAttribute, Type>()
                .Convert(Type => new TypeCoverage(Type, this._TestAssemblies.Array()))
                .AsReadOnly();
            }
        }
    }