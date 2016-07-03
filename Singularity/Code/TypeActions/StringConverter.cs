
using LCore.Extensions;
using Singularity.Context;
using Singularity.Models;
using System;
using System.Web;
using System.Web.Mvc;
using Singularity.Extensions;

namespace Singularity.Utilities
    {
    public class StringConverter : TypeResultAction<string>
        {
        public HttpSessionStateBase Session { get; set; }

        public StringConverter()
            {
            }

        public StringConverter(HttpSessionStateBase Session)
            {
            this.Session = Session;
            }

        protected U PerformAction_IConvertible<U>(string In)
            where U : IConvertible
            {
            return In.ConvertTo<U>();
            }

        protected override bool PerformAction_Boolean(string In)
            {
            return this.PerformAction_IConvertible<bool>(In);
            }

        protected override DateTime PerformAction_DateTime(string In)
            {
            return this.PerformAction_IConvertible<DateTime>(In);
            }

        protected override decimal PerformAction_Decimal(string In)
            {
            return this.PerformAction_IConvertible<decimal>(In);
            }
        protected override double PerformAction_Double(string In)
            {
            return this.PerformAction_IConvertible<double>(In);
            }
        protected override Enum PerformAction_Enum(Type EnumType, string In)
            {
            if (string.IsNullOrEmpty(In))
                return null;

            if (EnumType.HasAttribute<FlagsAttribute>(true))
                {
                if (In.StartsWith(","))
                    {
                    if (In.Length > 1)
                        In = In.Substring(1);
                    else
                        return null;
                    }

                return (Enum)Enum.Parse(EnumType, In);
                }
            return In.ParseEnum(EnumType);
            }
        protected override float PerformAction_Float(string In)
            {
            return this.PerformAction_IConvertible<float>(In);
            }
        protected override int PerformAction_Int(string In)
            {
            return this.PerformAction_IConvertible<int>(In);
            }
        protected override long PerformAction_Long(string In)
            {
            return this.PerformAction_IConvertible<long>(In);
            }

        protected override short PerformAction_Short(string In)
            {
            return this.PerformAction_IConvertible<short>(In);
            }

        protected override string PerformAction_String(string In)
            {
            return In;
            }
        protected override uint PerformAction_UInt(string In)
            {
            return this.PerformAction_IConvertible<uint>(In);
            }
        protected override ulong PerformAction_ULong(string In)
            {
            return this.PerformAction_IConvertible<ulong>(In);
            }
        protected override ushort PerformAction_UShort(string In)
            {
            return this.PerformAction_IConvertible<ushort>(In);
            }

        protected override TimeSpan PerformAction_TimeSpan(string In)
            {
            return TimeSpan.Parse(In);
            }

        protected override IModel PerformAction_IModel(Type t, string In)
            {
            if (this.Session != null)
                {
                var Query = ContextProviderFactory.GetCurrent().GetDBSet(this.Session, t);

                if (Query != null)
                    {
                    return (IModel)Query.FindByID(In);
                    }
                }
            return null;
            }

        protected override object PerformAction_Object(string In)
            {
            return In;
            }

        public static bool IsTypeSupported(ModelMetadata Meta)
            {
            return Meta?.IsReadOnly != true &&
                (Meta?.ModelType.HasInterface<IConvertible>() == true ||
                Meta?.ModelType.HasInterface<IModel>() == true);
            }
        }
    }
