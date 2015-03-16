using LCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCL
    {
    public class StringConverter : TypeResultAction<String>
        {
        public StringConverter()
            {
            }

        DbSet Query { get; set; }

        public StringConverter(DbSet Query)
            {
            this.Query = Query;
            }

        protected U PerformAction_IConvertible<U>(String In)
            where U : IConvertible
            {
            return In.ConvertTo<U>();
            }

        protected override bool PerformAction_Boolean(string In)
            {
            return PerformAction_IConvertible<Boolean>(In);
            }

        protected override DateTime PerformAction_DateTime(string In)
            {
            return PerformAction_IConvertible<DateTime>(In);
            }

        protected override decimal PerformAction_Decimal(string In)
            {
            return PerformAction_IConvertible<decimal>(In);
            }
        protected override double PerformAction_Double(string In)
            {
            return PerformAction_IConvertible<double>(In);
            }
        protected override Enum PerformAction_Enum(Type EnumType, string In)
            {
            if (String.IsNullOrEmpty(In))
                return null;

            if (EnumType.HasAttribute<FlagsAttribute>())
                {
                if (In.StartsWith(","))
                    {
                    if (In.Length > 1)
                        In = In.Substring(1);
                    else
                        return (Enum)null;
                    }

                return (Enum)Enum.Parse(EnumType, In);
                }
            else
                {
                return In.ParseEnum(EnumType);
                }
            }
        protected override float PerformAction_Float(string In)
            {
            return PerformAction_IConvertible<float>(In);
            }
        protected override int PerformAction_Int(string In)
            {
            return PerformAction_IConvertible<int>(In);
            }
        protected override long PerformAction_Long(string In)
            {
            return PerformAction_IConvertible<long>(In);
            }

        protected override short PerformAction_Short(string In)
            {
            return PerformAction_IConvertible<short>(In);
            }

        protected override string PerformAction_String(string In)
            {
            return In;
            }
        protected override uint PerformAction_UInt(string In)
            {
            return PerformAction_IConvertible<uint>(In);
            }
        protected override ulong PerformAction_ULong(string In)
            {
            return PerformAction_IConvertible<ulong>(In);
            }
        protected override ushort PerformAction_UShort(string In)
            {
            return PerformAction_IConvertible<ushort>(In);
            }

        protected override TimeSpan PerformAction_TimeSpan(string In)
            {
            return TimeSpan.Parse(In);
            }

        protected override IModel PerformAction_IModel(Type t, string In)
            {
            if (Query != null)
                {
                int ID_Int;
                Guid ID_Guid = Guid.Empty;

                if (int.TryParse(In, out ID_Int))
                    return (IModel)Query.Find(ID_Int);

                if (Guid.TryParse(In, out ID_Guid))
                    return (IModel)Query.Find(ID_Guid);
                }
            return null;
            }

        protected override object PerformAction_Object(string In)
            {
            return In;
            }
        }
    }
