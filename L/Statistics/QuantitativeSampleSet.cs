using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using LCore.Extensions;
// ReSharper disable UnusedVariable
// ReSharper disable VirtualMemberNeverOverriden.Global

namespace LCore.Statistics
    {
    [ExcludeFromCodeCoverage]
    internal abstract class QuantitativeSampleSet<T> : SampleSet
        where T : struct,
            IComparable,
            IComparable<T>,
            IConvertible,
            IEquatable<T>,
            IFormattable
        {
        protected T[] DataSet { get; set; }

        protected T[] DataSetSorted { get; set; }

        protected double[] _DataDeviation { get; set; }
        protected double _TotalDeviation { get; set; }

        protected double[] _DataVariance { get; set; }
        protected double _TotalVariance { get; set; }


        protected T[] _LowerOutliers { get; set; }
        protected T[] _UpperOutliers { get; set; }
        protected T[] _Outliers { get; set; }

        protected T _Total;
        protected T _Minimum;
        protected T _Maximum;
        protected T _Range;
        protected double _MidRange = default(double);
        protected double _Mean = default(double);
        protected double _Median = default(double);
        protected double _Quartile1 = default(double);
        protected double _Quartile3 = default(double);

        protected double _InterQuartileRange = default(double);

        protected double _LowerFence = default(double);
        protected double _UpperFence = default(double);

        protected T[] _Mode = { };
        protected long _ModeFrequency = default(long);
        protected double _StandardDeviation = default(double);
        protected double _ApproximateStandardDeviation = default(double);
        protected Dictionary<T, long> _Frequency = new Dictionary<T, long>();
        protected Dictionary<T, float> _RelativeFrequency = new Dictionary<T, float>();

        protected double _GeometricMean = default(double);
        protected double _HarmonicMean = default(double);

        protected double _SampleVariance = default(double);


        protected virtual T Convert(IConvertible In)
            {
            if (In is T)
                return (T)In;

            return (T)In.ConvertTo(typeof(T));
            }

        public abstract bool Equals(T X1, T X2);

        public abstract T Add(T X1, T X2);
        public abstract T Subtract(T X1, T X2);
        public abstract T Multiply(T X1, T X2);
        public abstract double Divide(T X1, T X2);

        public virtual bool GreaterThan(T X1, T X2)
            {
            return X1.CompareTo(X2) > 0;
            }
        public virtual bool GreaterThanOrEqual(T X1, T X2)
            {
            return X1.CompareTo(X2) >= 0;
            }
        public virtual bool LessThan(T X1, T X2)
            {
            return X1.CompareTo(X2) < 0;
            }
        public virtual bool LessThanOrEqual(T X1, T X2)
            {
            return X1.CompareTo(X2) <= 0;
            }


        public virtual T Total()
            {
            this.ParseData();
            return this._Total;
            }
        public virtual T Minimum()
            {
            this.ParseData();
            return this._Minimum;
            }
        public virtual T Maximum()
            {
            this.ParseData();
            return this._Maximum;
            }
        public virtual T Range()
            {
            this.ParseData();
            return this._Range;
            }
        public virtual double MidRange()
            {
            this.ParseData();
            return this._MidRange;
            }
        public virtual double Mean()
            {
            this.ParseData();
            return this._Mean;
            }
        public virtual double GeometricMean()
            {
            this.ParseData();
            return this._GeometricMean;
            }
        public virtual double HarmonicMean()
            {
            this.ParseData();
            return this._HarmonicMean;
            }

        public virtual double LowerFence()
            {
            this.ParseData();
            return this._LowerFence;
            }
        public virtual double UpperFence()
            {
            this.ParseData();
            return this._UpperFence;
            }

        public virtual T[] Mode()
            {
            this.ParseDataFrequency();
            return this._Mode;
            }
        public virtual long ModeFrequency()
            {
            this.ParseDataFrequency();
            return this._ModeFrequency;
            }
        public virtual double StandardDeviation()
            {
            this.ParseDataComplex();
            return this._StandardDeviation;
            }
        public virtual double ApproximateStandardDeviation()
            {
            this.ParseData();
            return this._ApproximateStandardDeviation;
            }
        public virtual double[] DataDeviations()
            {
            this.ParseDataComplex();
            return this._DataDeviation;
            }
        public virtual double DataTotalDeviation()
            {
            this.ParseDataComplex();
            return this._TotalDeviation;
            }
        public virtual double[] DataVariance()
            {
            this.ParseDataComplex();
            return this._DataVariance;
            }
        public virtual double DataTotalVariance()
            {
            this.ParseDataComplex();
            return this._TotalVariance;
            }
        public virtual Dictionary<T, long> GetFrequency()
            {
            this.ParseDataFrequency();
            return this._Frequency;
            }
        public virtual double Quartile1()
            {
            this.ParseData();
            return this._Quartile1;
            }
        public virtual double Quartile3()
            {
            this.ParseData();
            return this._Quartile3;
            }
        public virtual double InterQuartileRange()
            {
            this.ParseData();
            return this._InterQuartileRange;
            }

        public virtual T[] LowerOutliers()
            {
            this.ParseData();
            return this._LowerOutliers;
            }
        public virtual T[] UpperOutliers()
            {
            this.ParseData();
            return this._UpperOutliers;
            }
        public virtual T[] Outliers()
            {
            this.ParseData();
            return this._Outliers;
            }

        public virtual double[] GetBoxPlot()
            {
            this.ParseData();
            return new[] { this._Minimum.ConvertTo<double>(), this._Quartile1, this._Median, this._Quartile3, this._Maximum.ConvertTo<double>() };
            }

        protected bool Parsed;
        protected virtual void ParseData()
            {
            if (!this.Parsed)
                {
                var Total = default(T);
                var Minimum = default(T);
                var Maximum = default(T);

                var LowerOutliers = new List<T>();
                var UpperOutliers = new List<T>();
                var Outliers = new List<T>();

                this._GeometricMean = 1;
                double GeometricRatio = 1 / this.SampleSize;

                this._HarmonicMean = 0;

                this.DataSetSorted = this.DataSet.Array();
                this.DataSetSorted.Sort();

                #region Median
                bool EvenSampleSize = this.SampleSize.IsEven();

                if (EvenSampleSize)
                    {
                    var Median1 = this.DataSetSorted[(int)Math.Ceiling((double)(this.SampleSize / 2)) - 1];
                    var Median2 = this.DataSetSorted[(int)Math.Ceiling((double)(this.SampleSize / 2))];

                    this._Median = this.Divide(this.Add(Median1, Median2), this.Convert(2));
                    }
                else
                    {
                    this._Median = this.DataSetSorted[(int)Math.Ceiling((double)(this.SampleSize / 2)) - 1].ConvertTo<double>();
                    }
                #endregion

                #region Quartiles
                int Q1Index = (int)Math.Floor((double)(this.SampleSize / 4));

                var Q1_1 = this.DataSetSorted[(int)Math.Ceiling((double)(this.SampleSize / 2)) - 1];
                var Q1_2 = this.DataSetSorted[(int)Math.Ceiling((double)(this.SampleSize / 2))];


                int Q3Index = (int)Math.Floor((double)(this.SampleSize * 3 / 4));

                var Q3_1 = this.DataSetSorted[(int)Math.Ceiling((double)(this.SampleSize / 2)) - 1];
                var Q3_2 = this.DataSetSorted[(int)Math.Ceiling((double)(this.SampleSize / 2))];

                double QuartileRatio1;
                double QuartileRatio2;

                if (this.SampleSize % 4 == 1)
                    {
                    QuartileRatio1 = 0.25;
                    QuartileRatio2 = 0.75;
                    }
                else if (this.SampleSize % 4 == 3)
                    {
                    QuartileRatio1 = 0.75;
                    QuartileRatio2 = 0.25;
                    }
                else
                    {
                    QuartileRatio1 = 0.50;
                    QuartileRatio2 = 0.50;
                    }

                this._Quartile1 = Q1_1.ConvertTo<double>() * QuartileRatio1 + Q1_1.ConvertTo<double>() * QuartileRatio2;
                this._Quartile3 = Q3_1.ConvertTo<double>() * QuartileRatio2 + Q3_1.ConvertTo<double>() * QuartileRatio1;

                this._InterQuartileRange = this._Quartile3 - this._Quartile1;

                this._LowerFence = this._Median - 1.5 * this._InterQuartileRange;
                this._UpperFence = this._Median + 1.5 * this._InterQuartileRange;
                #endregion

                #region Basic Stats

                this.DataSetSorted.Each((i, x) =>
            {
                if (i == 0)
                    Minimum = x;

                Maximum = x;

                Total = this.Add(Total, x);

                this._GeometricMean *= Math.Pow(x.ConvertTo<double>(), GeometricRatio);

                this._HarmonicMean += 1 / x.ConvertTo<double>();

                if (x.ConvertTo<double>() < this._LowerFence)
                    {
                    LowerOutliers.Add(x);
                    Outliers.Add(x);
                    }
                else if (x.ConvertTo<double>() > this._UpperFence)
                    {
                    UpperOutliers.Add(x);
                    Outliers.Add(x);
                    }
            });

                this._Total = Total;
                this._Minimum = Minimum;
                this._Maximum = Maximum;
                this._Range = this.Subtract(Maximum, Minimum);

                this._MidRange = this.Divide(this.Add(Maximum, Minimum), this.Convert(2));

                this._Mean = this.Divide(Total, this.Convert(this.SampleSize));

                this._HarmonicMean = this.SampleSize / this._HarmonicMean;

                this._ApproximateStandardDeviation = this._Range.ConvertTo<double>() / 4;

                this._LowerOutliers = LowerOutliers.Array();
                this._UpperOutliers = UpperOutliers.Array();
                this._Outliers = Outliers.Array();
                #endregion

                this.Parsed = true;

                }
            }

        protected bool ParsedFrequency = false;
        protected virtual void ParseDataFrequency()
            {
            this.ParseData();

            if (!this.ParsedFrequency)
                {
                var MostFrequent = new List<T>();
                long MostFrequentCount = 0;

                this.DataSetSorted.Each((i, x) =>
            {
                #region Frequency
                if (!this._Frequency.ContainsKey(x))
                    {
                    this._Frequency.Add(x, 1);

                    if (MostFrequentCount == 0 || MostFrequentCount == 1)
                        {
                        MostFrequentCount = 1;
                        MostFrequent.Add(x);
                        }
                    }
                else
                    {
                    long Count = this._Frequency[x] + 1;

                    if (Count == MostFrequentCount)
                        {
                        MostFrequent.Add(x);
                        }
                    else if (Count > MostFrequentCount)
                        {
                        MostFrequent.Clear();
                        MostFrequent.Add(x);
                        MostFrequentCount = Count;
                        }

                    this._Frequency[x]++;
                    }
                #endregion

                #region RelativeFrequency

                this._Frequency.Keys.Each(x2 =>
            {
                this._RelativeFrequency[x2] = this._Frequency[x2] / this.SampleSize;
            });
                #endregion

                #region FrequencyClasses

                this._Frequency.Keys.Each(x2 =>
            {
                int ClassCount = StatsExt.GetOptimumClassCount(this.SampleSize);

                var Divisions = new T[ClassCount + 1];

                for (int j = 0; j < Divisions.Length; j++)
                    {
                    double Difference = this.Divide(this._Range, this.Convert(ClassCount));
                    var Value = this.Add(this._Minimum, this.Convert(Difference * j));
                    Divisions[j] = Value;
                    }
            });
                #endregion
            });

                this._Mode = MostFrequent.Array();
                this._ModeFrequency = MostFrequentCount;
                }
            }

        protected bool ParsedComplex;
        protected virtual void ParseDataComplex()
            {
            this.ParseData();

            if (!this.ParsedComplex)
                {
                this._DataDeviation = new double[this.DataSet.Length];
                this._DataVariance = new double[this.DataSet.Length];

                this._TotalDeviation = 0;
                this._TotalVariance = 0;

                this.DataSet.Each((i, x) =>
            {
                double d = this.GetValueDeviation(x);
                double v = this.GetValueVariance(x);

                this._DataDeviation[i] = d;
                this._DataVariance[i] = v;

                this._TotalDeviation += d;
                this._TotalVariance += v;
            });

                if (this.IsSample)
                    {
                    this._SampleVariance = this._TotalVariance / (this.SampleSize - 1);
                    }
                else
                    {
                    this._SampleVariance = this._TotalVariance / this.SampleSize;
                    }

                this._StandardDeviation = Math.Sqrt(this._SampleVariance);

                this.ParsedComplex = true;
                }
            }

        public double GetValueDeviation(T x)
            {
            return x.ConvertTo<double>() - this.Mean();
            }

        public double GetValueVariance(T x)
            {
            return Math.Pow(x.ConvertTo<double>() - this.Mean(), 2);
            }

        public double GetValueZScore(T x)
            {
            return (x.ConvertTo<double>() - this.Mean()) / this.StandardDeviation();
            }

        /// <summary>
        /// Returns a positive or negative number representing the distance (in standard deviations) from the mean of the data.
        /// </summary>
        /// <param name="DataPoint">Value in relation to the sample set</param>
        /// <returns>Returns a positive or negative number representing the distance (in standard deviations) from the mean of the data.</returns>
        public double GetStandardDeviationLine(T DataPoint)
            {
            double Distance = DataPoint.ConvertTo<double>() - this._Mean;

            double Result = Distance / this._StandardDeviation;

            return Result;
            }

        protected QuantitativeSampleSet(IEnumerable<T> Data, long PopulationSize = 0)
            {
            Data = Data ?? new T[] { };

            this.DataSet = Data.Array();

            this.SampleSize = this.DataSet.Length;
            this.PopulationSize = PopulationSize <= 0 ? this.DataSet.Length : PopulationSize;

            if (PopulationSize < this.SampleSize)
                throw new Exception("Population size can not be smaller than the Sample size.");
            }

        protected QuantitativeSampleSet(IEnumerable Data, long PopulationSize = 0)
            {
            Data = Data ?? new T[] { };

            this.DataSet = Data.Array().Convert(x =>
            {
                if (x is T)
                    {
                    return (T)x;
                    }
                var @in = x as IConvertible;
                if (@in != null)
                    {
                    return this.Convert(@in);
                    }
                throw new Exception($"Could not convert to {typeof(T).FullName}: {(x ?? "[null]").ToString()}");
            });

            this.SampleSize = this.DataSet.Length;
            this.PopulationSize = PopulationSize <= 0 ? this.DataSet.Length : PopulationSize;

            if (PopulationSize < this.SampleSize)
                throw new Exception("Population size can not be smaller than the Sample size.");
            }
        }

    #region Implementations
    [ExcludeFromCodeCoverage]
    internal class SampleSetInt : QuantitativeSampleSet<int>
        {
        public override bool Equals(int X1, int X2)
            {
            return X1 == X2;
            }
        public override int Add(int X1, int X2)
            {
            return X1 + X2;
            }
        public override int Subtract(int X1, int X2)
            {
            return X1 - X2;
            }
        public override int Multiply(int X1, int X2)
            {
            return X1 * X2;
            }
        public override double Divide(int X1, int X2) => X1 / X2;


        public SampleSetInt(IEnumerable<int> Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }

        public SampleSetInt(IEnumerable Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }
        }

    [ExcludeFromCodeCoverage]
    internal class SampleSetByte : QuantitativeSampleSet<byte>
        {
        public override bool Equals(byte X1, byte X2)
            {
            return X1 == X2;
            }
        public override byte Add(byte X1, byte X2)
            {
            return (byte)(X1 + X2);
            }
        public override byte Subtract(byte X1, byte X2)
            {
            return (byte)(X1 - X2);
            }
        public override byte Multiply(byte X1, byte X2)
            {
            return (byte)(X1 * X2);
            }
        public override double Divide(byte X1, byte X2) => X1 / X2;


        public SampleSetByte(IEnumerable<byte> Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }

        public SampleSetByte(IEnumerable Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }
        }

    [ExcludeFromCodeCoverage]
    internal class DecimalSampleSet : QuantitativeSampleSet<decimal>
        {
        public override bool Equals(decimal X1, decimal X2)
            {
            return X1 == X2;
            }
        public override decimal Add(decimal X1, decimal X2)
            {
            return X1 + X2;
            }
        public override decimal Subtract(decimal X1, decimal X2)
            {
            return X1 - X2;
            }
        public override decimal Multiply(decimal X1, decimal X2)
            {
            return X1 * X2;
            }
        public override double Divide(decimal X1, decimal X2)
            {
            return (double)(X1 / X2);
            }


        public DecimalSampleSet(IEnumerable<decimal> Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }

        public DecimalSampleSet(IEnumerable Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }
        }

    [ExcludeFromCodeCoverage]
    internal class DoubleSampleSet : QuantitativeSampleSet<double>
        {
        public override bool Equals(double X1, double X2)
            {
            return X1 == X2;
            }
        public override double Add(double X1, double X2)
            {
            return X1 + X2;
            }
        public override double Subtract(double X1, double X2)
            {
            return X1 - X2;
            }
        public override double Multiply(double X1, double X2)
            {
            return X1 * X2;
            }
        public override double Divide(double X1, double X2)
            {
            return X1 / X2;
            }


        public DoubleSampleSet(IEnumerable<double> Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }

        public DoubleSampleSet(IEnumerable Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }
        }

    [ExcludeFromCodeCoverage]
    internal class FloatSampleSet : QuantitativeSampleSet<float>
        {
        public override bool Equals(float X1, float X2)
            {
            return X1 == X2;
            }
        public override float Add(float X1, float X2)
            {
            return X1 + X2;
            }
        public override float Subtract(float X1, float X2)
            {
            return X1 - X2;
            }
        public override float Multiply(float X1, float X2)
            {
            return X1 * X2;
            }
        public override double Divide(float X1, float X2)
            {
            return X1 / X2;
            }


        public FloatSampleSet(IEnumerable<float> Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }

        public FloatSampleSet(IEnumerable Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }
        }

    [ExcludeFromCodeCoverage]
    internal class LongSampleSet : QuantitativeSampleSet<long>
        {
        public override bool Equals(long X1, long X2)
            {
            return X1 == X2;
            }
        public override long Add(long X1, long X2)
            {
            return X1 + X2;
            }
        public override long Subtract(long X1, long X2)
            {
            return X1 - X2;
            }
        public override long Multiply(long X1, long X2)
            {
            return X1 * X2;
            }
        public override double Divide(long X1, long X2) => X1 / X2;


        public LongSampleSet(IEnumerable<long> Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }

        public LongSampleSet(IEnumerable Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }
        }
    [ExcludeFromCodeCoverage]
    internal class SByteSampleSet : QuantitativeSampleSet<sbyte>
        {
        public override bool Equals(sbyte X1, sbyte X2)
            {
            return X1 == X2;
            }
        public override sbyte Add(sbyte X1, sbyte X2)
            {
            return (sbyte)(X1 + X2);
            }
        public override sbyte Subtract(sbyte X1, sbyte X2)
            {
            return (sbyte)(X1 - X2);
            }
        public override sbyte Multiply(sbyte X1, sbyte X2)
            {
            return (sbyte)(X1 * X2);
            }
        public override double Divide(sbyte X1, sbyte X2) => X1 / X2;


        public SByteSampleSet(IEnumerable<sbyte> Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }

        public SByteSampleSet(IEnumerable Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }
        }

    [ExcludeFromCodeCoverage]
    internal class ShortSampleSet : QuantitativeSampleSet<short>
        {
        public override bool Equals(short X1, short X2)
            {
            return X1 == X2;
            }
        public override short Add(short X1, short X2)
            {
            return (short)(X1 + X2);
            }
        public override short Subtract(short X1, short X2)
            {
            return (short)(X1 - X2);
            }
        public override short Multiply(short X1, short X2)
            {
            return (short)(X1 * X2);
            }
        public override double Divide(short X1, short X2) => X1 / X2;


        public ShortSampleSet(IEnumerable<short> Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }

        public ShortSampleSet(IEnumerable Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }
        }

    [ExcludeFromCodeCoverage]
    // ReSharper disable once InconsistentNaming
    internal class UIntSampleSet : QuantitativeSampleSet<uint>
        {
        public override bool Equals(uint X1, uint X2)
            {
            return X1 == X2;
            }
        public override uint Add(uint X1, uint X2)
            {
            return X1 + X2;
            }
        public override uint Subtract(uint X1, uint X2)
            {
            return X1 - X2;
            }
        public override uint Multiply(uint X1, uint X2)
            {
            return X1 * X2;
            }
        public override double Divide(uint X1, uint X2) => X1 / X2;


        public UIntSampleSet(IEnumerable<uint> Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }

        public UIntSampleSet(IEnumerable Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }
        }

    [ExcludeFromCodeCoverage]
    // ReSharper disable once InconsistentNaming
    internal class ULongSampleSet : QuantitativeSampleSet<ulong>
        {
        public override bool Equals(ulong X1, ulong X2)
            {
            return X1 == X2;
            }
        public override ulong Add(ulong X1, ulong X2)
            {
            return X1 + X2;
            }
        public override ulong Subtract(ulong X1, ulong X2)
            {
            return X1 - X2;
            }
        public override ulong Multiply(ulong X1, ulong X2)
            {
            return X1 * X2;
            }
        public override double Divide(ulong X1, ulong X2) => X1 / X2;


        public ULongSampleSet(IEnumerable<ulong> Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }

        public ULongSampleSet(IEnumerable Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }
        }


    [ExcludeFromCodeCoverage]
    // ReSharper disable once InconsistentNaming
    internal class UShortSampleSet : QuantitativeSampleSet<ushort>
        {
        public override bool Equals(ushort X1, ushort X2)
            {
            return X1 == X2;
            }
        public override ushort Add(ushort X1, ushort X2)
            {
            return (ushort)(X1 + X2);
            }
        public override ushort Subtract(ushort X1, ushort X2)
            {
            return (ushort)(X1 - X2);
            }
        public override ushort Multiply(ushort X1, ushort X2)
            {
            return (ushort)(X1 * X2);
            }
        public override double Divide(ushort X1, ushort X2) => X1 / X2;


        public UShortSampleSet(IEnumerable<ushort> Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }

        public UShortSampleSet(IEnumerable Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }
        }
    #endregion
    }
