
using LCore.Extensions;
using LMVC.Models;
using System;
using System.Web;
using System.Web.Mvc;
using JetBrains.Annotations;
using LMVC.Context;
using LMVC.Extensions;

namespace LMVC.Utilities
    {
    public class StringConverter : TypeResultAction<string>
        {
        public HttpSessionStateBase Session { get; }

        public StringConverter()
            {
            }

        public StringConverter(HttpSessionStateBase Session)
            {
            this.Session = Session;
            }

        // ReSharper disable once InconsistentNaming
        protected U? PerformAction_IConvertible<U>(string In)
            where U : struct, IConvertible
            {
            return In.ConvertTo<U>();
            }

        protected override bool? PerformAction_Boolean(string In)
            {
            return this.PerformAction_IConvertible<bool>(In);
            }

        protected override DateTime? PerformAction_DateTime(string In)
            {
            return this.PerformAction_IConvertible<DateTime>(In);
            }

        protected override decimal? PerformAction_Decimal(string In)
            {
            return this.PerformAction_IConvertible<decimal>(In);
            }
        protected override double? PerformAction_Double(string In)
            {
            return this.PerformAction_IConvertible<double>(In);
            }

        /// <exception cref="ArgumentNullException"><paramref name="Type" /> or <paramref name="In" /> is null. </exception>
        /// <exception cref="OverflowException"><paramref name="In" /> is outside the range of the underlying type of <paramref name="Type" />.</exception>

        [CanBeNull]
        protected override Enum PerformAction_Enum([CanBeNull]Type Type, string In)
            {
            if (string.IsNullOrEmpty(In))
                return null;

            if (Type.HasAttribute<FlagsAttribute>(true))
                {
                if (In.StartsWith(","))
                    {
                    if (In.Length > 1)
                        In = In.Substring(1);
                    else
                        return null;
                    }

                return (Enum)Enum.Parse(Type, In);
                }
            return In.ParseEnum(Type);
            }
        protected override float? PerformAction_Float(string In)
            {
            return this.PerformAction_IConvertible<float>(In);
            }
        protected override int? PerformAction_Int(string In)
            {
            return this.PerformAction_IConvertible<int>(In);
            }
        protected override long? PerformAction_Long(string In)
            {
            return this.PerformAction_IConvertible<long>(In);
            }

        protected override short? PerformAction_Short(string In)
            {
            return this.PerformAction_IConvertible<short>(In);
            }
        [CanBeNull]
        protected override string PerformAction_String(string In)
            {
            return In;
            }
        protected override uint? PerformAction_UInt(string In)
            {
            return this.PerformAction_IConvertible<uint>(In);
            }
        protected override ulong? PerformAction_ULong(string In)
            {
            return this.PerformAction_IConvertible<ulong>(In);
            }
        protected override ushort? PerformAction_UShort(string In)
            {
            return this.PerformAction_IConvertible<ushort>(In);
            }

        /// <exception cref="ArgumentNullException">
        ///         <paramref name="In" /> is null. </exception>
        /// <exception cref="FormatException">
        ///         <paramref name="In" /> has an invalid format. </exception>
        /// <exception cref="OverflowException">
        ///         <paramref name="In" /> represents a number that is less than <see cref="F:System.TimeSpan.MinValue" /> or greater than <see cref="F:System.TimeSpan.MaxValue" />.-or- At least one of the days, hours, minutes, or seconds components is outside its valid range. </exception>
        protected override TimeSpan? PerformAction_TimeSpan(string In)
            {
            return TimeSpan.Parse(In);
            }

        [CanBeNull]
        protected override IModel PerformAction_IModel(Type Type, string In)
            {
            if (this.Session != null)
                {
                var Query = ContextProviderFactory.GetCurrent().GetDBSet(this.Session, Type);

                if (Query != null)
                    {
                    return (IModel)Query.FindByID(In);
                    }
                }
            return null;
            }

        [CanBeNull]
        protected override object PerformAction_Object(string In)
            {
            return In;
            }

        public static bool IsTypeSupported([CanBeNull]ModelMetadata Meta)
            {
            return Meta?.IsReadOnly != true &&
                (Meta?.ModelType.HasInterface<IConvertible>() == true ||
                Meta?.ModelType.HasInterface<IModel>() == true);
            }
        }
    }
