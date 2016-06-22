using System;

namespace LCore.Numbers
    {
    public interface INumber<T>
        where T : struct,
            IComparable,
            IComparable<T>,
            IConvertible,
            IEquatable<T>,
            IFormattable
        {
        double Divide(T Value);
        T Multiply(T Value);
        T Subtract(T Value);
        T Add(T Value);
        }

    public class NumberInt : Number<int>
        {
        public static implicit operator NumberInt(int i)
            {
            return new NumberInt(i);
            }
        public static implicit operator int(NumberInt i)
            {
            return i.Value;
            }

        public override int Add(int Value2)
            {
            return this.Value + Value2;
            }
        public override int Subtract(int Value2)
            {
            return this.Value - Value2;
            }
        public override int Multiply(int Value2)
            {
            return this.Value * Value2;
            }
        public override double Divide(int Value2)
            {
            return this.Value / Value2;
            }

        public NumberInt(int Value)
            : base(Value)
            {

            }
        }

    public class NumberByte : Number<byte>
        {
        public static implicit operator NumberByte(byte i)
            {
            return new NumberByte(i);
            }
        public static implicit operator byte(NumberByte i)
            {
            return i.Value;
            }

        public override byte Add(byte Value2)
            {
            return (byte)(this.Value + Value2);
            }
        public override byte Subtract(byte Value2)
            {
            return (byte)(this.Value - Value2);
            }
        public override byte Multiply(byte Value2)
            {
            return (byte)(this.Value * Value2);
            }
        public override double Divide(byte Value2)
            {
            return this.Value / Value2;
            }

        public NumberByte(byte Value)
            : base(Value)
            {

            }
        }

    public class DecimalNumber : Number<decimal>
        {
        public static implicit operator DecimalNumber(decimal i)
            {
            return new DecimalNumber(i);
            }
        public static implicit operator decimal(DecimalNumber i)
            {
            return i.Value;
            }

        public override decimal Add(decimal Value2)
            {
            return this.Value + Value2;
            }
        public override decimal Subtract(decimal Value2)
            {
            return this.Value - Value2;
            }
        public override decimal Multiply(decimal Value2)
            {
            return this.Value * Value2;
            }
        public override double Divide(decimal Value2)
            {
            return (double)(this.Value / Value2);
            }

        public DecimalNumber(decimal Value)
            : base(Value)
            {

            }
        }

    public class DoubleNumber : Number<double>
        {
        public static implicit operator DoubleNumber(double i)
            {
            return new DoubleNumber(i);
            }
        public static implicit operator double(DoubleNumber i)
            {
            return i.Value;
            }

        public override double Add(double Value2)
            {
            return this.Value + Value2;
            }
        public override double Subtract(double Value2)
            {
            return this.Value - Value2;
            }
        public override double Multiply(double Value2)
            {
            return this.Value * Value2;
            }
        public override double Divide(double Value2)
            {
            return this.Value / Value2;
            }

        public DoubleNumber(double Value)
            : base(Value)
            {

            }
        }

    public class FloatNumber : Number<float>
        {
        public static implicit operator FloatNumber(float i)
            {
            return new FloatNumber(i);
            }
        public static implicit operator float(FloatNumber i)
            {
            return i.Value;
            }

        public override float Add(float Value2)
            {
            return this.Value + Value2;
            }
        public override float Subtract(float Value2)
            {
            return this.Value - Value2;
            }
        public override float Multiply(float Value2)
            {
            return this.Value * Value2;
            }
        public override double Divide(float Value2)
            {
            return this.Value / Value2;
            }

        public FloatNumber(float Value)
            : base(Value)
            {

            }
        }

    public class LongNumber : Number<long>
        {
        public static implicit operator LongNumber(long i)
            {
            return new LongNumber(i);
            }
        public static implicit operator long(LongNumber i)
            {
            return i.Value;
            }

        public override long Add(long Value2)
            {
            return this.Value + Value2;
            }
        public override long Subtract(long Value2)
            {
            return this.Value - Value2;
            }
        public override long Multiply(long Value2)
            {
            return this.Value * Value2;
            }
        public override double Divide(long Value2)
            {
            return this.Value / Value2;
            }

        public LongNumber(long Value)
            : base(Value)
            {

            }
        }
    public class SByteNumber : Number<sbyte>
        {
        public static implicit operator SByteNumber(sbyte i)
            {
            return new SByteNumber(i);
            }
        public static implicit operator sbyte(SByteNumber i)
            {
            return i.Value;
            }

        public override sbyte Add(sbyte Value2)
            {
            return (sbyte)(this.Value + Value2);
            }
        public override sbyte Subtract(sbyte Value2)
            {
            return (sbyte)(this.Value - Value2);
            }
        public override sbyte Multiply(sbyte Value2)
            {
            return (sbyte)(this.Value * Value2);
            }
        public override double Divide(sbyte Value2)
            {
            return this.Value / Value2;
            }

        public SByteNumber(sbyte Value)
            : base(Value)
            {

            }
        }

    public class ShortNumber : Number<short>
        {
        public static implicit operator ShortNumber(short i)
            {
            return new ShortNumber(i);
            }
        public static implicit operator short(ShortNumber i)
            {
            return i.Value;
            }

        public override short Add(short Value2)
            {
            return (short)(this.Value + Value2);
            }
        public override short Subtract(short Value2)
            {
            return (short)(this.Value - Value2);
            }
        public override short Multiply(short Value2)
            {
            return (short)(this.Value * Value2);
            }
        public override double Divide(short Value2)
            {
            return this.Value / Value2;
            }

        public ShortNumber(short Value)
            : base(Value)
            {

            }
        }

    public class UIntNumber : Number<uint>
        {
        public static implicit operator UIntNumber(uint i)
            {
            return new UIntNumber(i);
            }
        public static implicit operator uint(UIntNumber i)
            {
            return i.Value;
            }

        public override uint Add(uint Value2)
            {
            return this.Value + Value2;
            }
        public override uint Subtract(uint Value2)
            {
            return this.Value - Value2;
            }
        public override uint Multiply(uint Value2)
            {
            return this.Value * Value2;
            }
        public override double Divide(uint Value2)
            {
            return this.Value / Value2;
            }

        public UIntNumber(uint Value)
            : base(Value)
            {

            }
        }

    public class ULongNumber : Number<ulong>
        {
        public static implicit operator ULongNumber(ulong i)
            {
            return new ULongNumber(i);
            }
        public static implicit operator ulong(ULongNumber i)
            {
            return i.Value;
            }

        public override ulong Add(ulong Value2)
            {
            return this.Value + Value2;
            }
        public override ulong Subtract(ulong Value2)
            {
            return this.Value - Value2;
            }
        public override ulong Multiply(ulong Value2)
            {
            return this.Value * Value2;
            }
        public override double Divide(ulong Value2)
            {
            return this.Value / Value2;
            }

        public ULongNumber(ulong Value)
            : base(Value)
            {

            }
        }


    public class UShortNumber : Number<ushort>
        {
        public static implicit operator UShortNumber(ushort i)
            {
            return new UShortNumber(i);
            }
        public static implicit operator ushort(UShortNumber i)
            {
            return i.Value;
            }

        public override ushort Add(ushort Value2)
            {
            return (ushort)(this.Value + Value2);
            }
        public override ushort Subtract(ushort Value2)
            {
            return (ushort)(this.Value - Value2);
            }
        public override ushort Multiply(ushort Value2)
            {
            return (ushort)(this.Value * Value2);
            }
        public override double Divide(ushort Value2)
            {
            return this.Value / Value2;
            }

        public UShortNumber(ushort Value)
            : base(Value)
            {

            }
        }

    public abstract class Number<T>
        : INumber<T>
        where T : struct,
            IComparable,
            IComparable<T>,
            IConvertible,
            IEquatable<T>,
            IFormattable
        {
        public abstract T Add(T Value2);
        public abstract T Subtract(T Value2);
        public abstract T Multiply(T Value2);
        public abstract double Divide(T Value2);

        public T Value { get; set; }

        protected Number(T Value)
            {
            this.Value = Value;
            }
        }
    /*
    public static class NumberStatic
        {
        public static int[] Combine(int DesiredSum, int[] In)
            {
            In.Sort();

            Boolean[] Include = new Boolean[In.Length];

            int TotalSelected = 0;

            for (int i = 0; i < In.Length; i++)
                {
                if (In[i] == DesiredSum)
                    {
                    return new int[] { In[i] };
                    }

                if (TotalSelected + In[i] == DesiredSum)
                    {
                    return In.SelectI<int>((j, j2) => { return Include[j2] == true; }).Array();
                    }
                }
            }
        }
     * */
    }
