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
    public class AssemblyCoverage
        {
        public Assembly CoveringAssembly { get; }

        public uint TotalCoverage =>
            (uint)this.TypeCoverage.Convert(Member => Member.CoveragePercent).Average().Round();


        public ReadOnlyCollection<TypeCoverage> TypeCoverage { get; }


        private ReadOnlyCollection<Assembly> _TestAssemblies { get; }

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