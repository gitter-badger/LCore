using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCore;

namespace LCore.Statistics
    {
    public abstract class QuantitativeSampleSet<T> : SampleSet
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

        protected T _Total = default(T);
        protected T _Minimum = default(T);
        protected T _Maximum = default(T);
        protected T _Range = default(T);
        protected double _MidRange = default(double);
        protected double _Mean = default(double);
        protected double _Median = default(double);
        protected double _Quartile1 = default(double);
        protected double _Quartile3 = default(double);

        protected double _InterQuartileRange = default(double);

        protected double _LowerFence = default(double);
        protected double _UpperFence = default(double);

        protected T[] _Mode = new T[] { };
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

        public abstract Boolean Equals(T X1, T X2);

        public abstract T Add(T X1, T X2);
        public abstract T Subtract(T X1, T X2);
        public abstract T Multiply(T X1, T X2);
        public abstract double Divide(T X1, T X2);

        public virtual Boolean GreaterThan(T X1, T X2)
            {
            return X1.CompareTo(X2) > 0;
            }
        public virtual Boolean GreaterThanOrEqual(T X1, T X2)
            {
            return X1.CompareTo(X2) >= 0;
            }
        public virtual Boolean LessThan(T X1, T X2)
            {
            return X1.CompareTo(X2) < 0;
            }
        public virtual Boolean LessThanOrEqual(T X1, T X2)
            {
            return X1.CompareTo(X2) <= 0;
            }


        public virtual T Total()
            {
            ParseData();
            return _Total;
            }
        public virtual T Minimum()
            {
            ParseData();
            return _Minimum;
            }
        public virtual T Maximum()
            {
            ParseData();
            return _Maximum;
            }
        public virtual T Range()
            {
            ParseData();
            return _Range;
            }
        public virtual double MidRange()
            {
            ParseData();
            return _MidRange;
            }
        public virtual double Mean()
            {
            ParseData();
            return _Mean;
            }
        public virtual double GeometricMean()
            {
            ParseData();
            return _GeometricMean;
            }
        public virtual double HarmonicMean()
            {
            ParseData();
            return _HarmonicMean;
            }

        public virtual double LowerFence()
            {
            ParseData();
            return _LowerFence;
            }
        public virtual double UpperFence()
            {
            ParseData();
            return _UpperFence;
            }

        public virtual T[] Mode()
            {
            ParseDataFrequency();
            return _Mode;
            }
        public virtual long ModeFrequency()
            {
            ParseDataFrequency();
            return _ModeFrequency;
            }
        public virtual double StandardDeviation()
            {
            ParseDataComplex();
            return _StandardDeviation;
            }
        public virtual double ApproximateStandardDeviation()
            {
            ParseData();
            return _ApproximateStandardDeviation;
            }
        public virtual double[] DataDeviations()
            {
            ParseDataComplex();
            return _DataDeviation;
            }
        public virtual double DataTotalDeviation()
            {
            ParseDataComplex();
            return _TotalDeviation;
            }
        public virtual double[] DataVariance()
            {
            ParseDataComplex();
            return _DataVariance;
            }
        public virtual double DataTotalVariance()
            {
            ParseDataComplex();
            return _TotalVariance;
            }
        public virtual Dictionary<T, long> GetFrequency()
            {
            ParseDataFrequency();
            return _Frequency;
            }
        public virtual double Quartile1()
            {
            ParseData();
            return _Quartile1;
            }
        public virtual double Quartile3()
            {
            ParseData();
            return _Quartile3;
            }
        public virtual double InterQuartileRange()
            {
            ParseData();
            return _InterQuartileRange;
            }

        public virtual T[] LowerOutliers()
            {
            ParseData();
            return _LowerOutliers;
            }
        public virtual T[] UpperOutliers()
            {
            ParseData();
            return _UpperOutliers;
            }
        public virtual T[] Outliers()
            {
            ParseData();
            return _Outliers;
            }

        public virtual double[] GetBoxPlot()
            {
            ParseData();
            return new[] { _Minimum.ConvertTo<double>(), _Quartile1, _Median, _Quartile3, _Maximum.ConvertTo<double>() };
            }

        protected Boolean Parsed = false;
        protected virtual void ParseData()
            {
            if (!Parsed)
                {
                T Total = default(T);
                T Minimum = default(T);
                T Maximum = default(T);

                List<T> LowerOutliers = new List<T>();
                List<T> UpperOutliers = new List<T>();
                List<T> Outliers = new List<T>();

                this._GeometricMean = 1;
                double GeometricRatio = (1 / SampleSize);

                this._HarmonicMean = 0;

                DataSetSorted = DataSet.Array();
                DataSetSorted.Sort();

                #region Median
                Boolean EvenSampleSize = this.SampleSize.IsEven();

                if (EvenSampleSize)
                    {
                    T Median1 = DataSetSorted[(int)Math.Ceiling((double)(this.SampleSize / 2)) - (int)1];
                    T Median2 = DataSetSorted[(int)Math.Ceiling((double)(this.SampleSize / 2))];

                    _Median = Divide(Add(Median1, Median2), Convert(2));
                    }
                else
                    {
                    _Median = DataSetSorted[(int)Math.Ceiling((double)(this.SampleSize / 2)) - (int)1].ConvertTo<double>();
                    }
                #endregion

                #region Quartiles
                int Q1Index = (int)Math.Floor((double)(this.SampleSize / 4));

                T Q1_1 = DataSetSorted[(int)Math.Ceiling((double)(this.SampleSize / 2)) - (int)1];
                T Q1_2 = DataSetSorted[(int)Math.Ceiling((double)(this.SampleSize / 2))];


                int Q3Index = (int)Math.Floor((double)(this.SampleSize * 3 / 4));

                T Q3_1 = DataSetSorted[(int)Math.Ceiling((double)(this.SampleSize / 2)) - (int)1];
                T Q3_2 = DataSetSorted[(int)Math.Ceiling((double)(this.SampleSize / 2))];

                double QuartileRatio1 = 0;
                double QuartileRatio2 = 0;

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

                _Quartile1 = (Q1_1.ConvertTo<double>() * QuartileRatio1) + (Q1_1.ConvertTo<double>() * QuartileRatio2);
                _Quartile3 = (Q3_1.ConvertTo<double>() * QuartileRatio2) + (Q3_1.ConvertTo<double>() * QuartileRatio1);

                _InterQuartileRange = _Quartile3 - _Quartile1;

                _LowerFence = _Median - (1.5 * _InterQuartileRange);
                _UpperFence = _Median + (1.5 * _InterQuartileRange);
                #endregion

                #region Basic Stats
                DataSetSorted.EachI((i, x) =>
                {
                    if (i == 0)
                        Minimum = x;

                    Maximum = x;

                    Total = Add(Total, x);

                    this._GeometricMean *= Math.Pow(x.ConvertTo<double>(), GeometricRatio);

                    this._HarmonicMean += (1 / x.ConvertTo<double>());

                    if (x.ConvertTo<double>() < _LowerFence)
                        {
                        LowerOutliers.Add(x);
                        Outliers.Add(x);
                        }
                    else if (x.ConvertTo<double>() > _UpperFence)
                        {
                        UpperOutliers.Add(x);
                        Outliers.Add(x);
                        }
                });

                this._Total = Total;
                this._Minimum = Minimum;
                this._Maximum = Maximum;
                this._Range = Subtract(Maximum, Minimum);

                this._MidRange = Divide(Add(Maximum, Minimum), Convert(2));

                this._Mean = Divide(Total, Convert(SampleSize));

                this._HarmonicMean = SampleSize / this._HarmonicMean;

                this._ApproximateStandardDeviation = _Range.ConvertTo<double>() / 4;

                this._LowerOutliers = LowerOutliers.Array();
                this._UpperOutliers = UpperOutliers.Array();
                this._Outliers = Outliers.Array();
                #endregion

                Parsed = true;

                }
            }

        protected Boolean ParsedFrequency = false;
        protected virtual void ParseDataFrequency()
            {
            ParseData();

            if (!ParsedFrequency)
                {
                List<T> MostFrequent = new List<T>();
                long MostFrequentCount = 0;

                DataSetSorted.EachI((i, x) =>
                {
                    #region Frequency
                    if (!_Frequency.ContainsKey(x))
                        {
                        _Frequency.Add(x, 1);

                        if (MostFrequentCount == 0 || MostFrequentCount == 1)
                            {
                            MostFrequentCount = 1;
                            MostFrequent.Add(x);
                            }
                        }
                    else
                        {
                        long Count = _Frequency[x] + 1;

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

                        _Frequency[x]++;
                        }
                    #endregion

                    #region RelativeFrequency
                    _Frequency.Keys.Each((x2) =>
                    {
                        _RelativeFrequency[x2] = _Frequency[x2] / SampleSize;
                    });
                    #endregion

                    #region FrequencyClasses
                    _Frequency.Keys.Each((x2) =>
                    {
                        int ClassCount = StatsExt.GetOptimumClassCount(this.SampleSize);

                        T[] Divisions = new T[ClassCount + 1];

                        for (int j = 0; j < Divisions.Length; j++)
                            {
                            double Difference = Divide(_Range, Convert(ClassCount));
                            T Value = Add(_Minimum, Convert(Difference * j));
                            Divisions[j] = Value;
                            }
                    });
                    #endregion
                });

                _Mode = MostFrequent.Array();
                _ModeFrequency = MostFrequentCount;
                }
            }

        protected Boolean ParsedComplex = false;
        protected virtual void ParseDataComplex()
            {
            ParseData();

            if (!ParsedComplex)
                {
                _DataDeviation = new double[DataSet.Length];
                _DataVariance = new double[DataSet.Length];

                _TotalDeviation = 0;
                _TotalVariance = 0;

                DataSet.EachI((i, x) =>
                {
                    double d = GetValueDeviation(x);
                    double v = GetValueVariance(x);

                    _DataDeviation[i] = d;
                    _DataVariance[i] = v;

                    _TotalDeviation += d;
                    _TotalVariance += v;
                });

                if (IsSample)
                    {
                    _SampleVariance = _TotalVariance / (SampleSize - 1);
                    }
                else
                    {
                    _SampleVariance = _TotalVariance / SampleSize;
                    }

                _StandardDeviation = Math.Sqrt(_SampleVariance);

                ParsedComplex = true;
                }
            }

        public Double GetValueDeviation(T x)
            {
            return x.ConvertTo<double>() - Mean();
            }

        public Double GetValueVariance(T x)
            {
            return Math.Pow(x.ConvertTo<double>() - Mean(), 2);
            }

        public Double GetValueZScore(T x)
            {
            return (x.ConvertTo<double>() - Mean()) / StandardDeviation();
            }

        /// <summary>
        /// Returns a positive or negative number representing the distance (in standard deviations) from the mean of the data.
        /// </summary>
        /// <param name="DataPoint">Value in relation to the sample set</param>
        /// <returns>Returns a positive or negative number representing the distance (in standard deviations) from the mean of the data.</returns>
        public double GetStandardDeviationLine(T DataPoint)
            {
            double Distance = DataPoint.ConvertTo<double>() - _Mean;

            double Result = Distance / _StandardDeviation;

            return Result;
            }

        public QuantitativeSampleSet(IEnumerable<T> Data, long PopulationSize = 0)
            {
            Data = Data ?? new T[] { };

            DataSet = Data.Array();

            this.SampleSize = DataSet.Length;
            this.PopulationSize = PopulationSize <= 0 ? DataSet.Length : PopulationSize;

            if (PopulationSize < SampleSize)
                throw new Exception("Population size can not be smaller than the Sample size.");
            }

        public QuantitativeSampleSet(IEnumerable Data, long PopulationSize = 0)
            {
            Data = Data ?? new T[] { };

            DataSet = Data.Array().Convert((x) =>
                {
                    if (x is T && x != null)
                        {
                        return (T)x;
                        }
                    else if (x is IConvertible)
                        {
                        return Convert((IConvertible)x);
                        }
                    else
                        {
                        throw new Exception("Could not convert to " + typeof(T).FullName + ": " + (x ?? "[null]").ToString());
                        }
                });

            this.SampleSize = DataSet.Length;
            this.PopulationSize = PopulationSize <= 0 ? DataSet.Length : PopulationSize;

            if (PopulationSize < SampleSize)
                throw new Exception("Population size can not be smaller than the Sample size.");
            }
        }

    #region Implementations
    public class SampleSetInt : QuantitativeSampleSet<int>
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
        public override double Divide(int X1, int X2)
            {
            return X1 / X2;
            }


        public SampleSetInt(IEnumerable<int> Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }

        public SampleSetInt(IEnumerable Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }
        }

    public class SampleSetByte : QuantitativeSampleSet<byte>
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
        public override double Divide(byte X1, byte X2)
            {
            return (double)(X1 / X2);
            }


        public SampleSetByte(IEnumerable<byte> Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }

        public SampleSetByte(IEnumerable Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }
        }

    public class DecimalSampleSet : QuantitativeSampleSet<decimal>
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

    public class DoubleSampleSet : QuantitativeSampleSet<double>
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

    public class FloatSampleSet : QuantitativeSampleSet<float>
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
            return (double)(X1 / X2);
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

    public class LongSampleSet : QuantitativeSampleSet<long>
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
        public override double Divide(long X1, long X2)
            {
            return (double)(X1 / X2);
            }


        public LongSampleSet(IEnumerable<long> Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }

        public LongSampleSet(IEnumerable Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }
        }
    public class SByteSampleSet : QuantitativeSampleSet<sbyte>
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
        public override double Divide(sbyte X1, sbyte X2)
            {
            return (double)(X1 / X2);
            }


        public SByteSampleSet(IEnumerable<sbyte> Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }

        public SByteSampleSet(IEnumerable Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }
        }

    public class ShortSampleSet : QuantitativeSampleSet<short>
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
        public override double Divide(short X1, short X2)
            {
            return (double)(X1 / X2);
            }


        public ShortSampleSet(IEnumerable<short> Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }

        public ShortSampleSet(IEnumerable Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }
        }

    public class UIntSampleSet : QuantitativeSampleSet<uint>
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
        public override double Divide(uint X1, uint X2)
            {
            return (double)(X1 / X2);
            }


        public UIntSampleSet(IEnumerable<uint> Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }

        public UIntSampleSet(IEnumerable Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }
        }

    public class ULongSampleSet : QuantitativeSampleSet<ulong>
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
        public override double Divide(ulong X1, ulong X2)
            {
            return (double)(X1 / X2);
            }


        public ULongSampleSet(IEnumerable<ulong> Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }

        public ULongSampleSet(IEnumerable Data, long PopulationSize = 0)
            : base(Data, PopulationSize)
            {
            }
        }


    public class UShortSampleSet : QuantitativeSampleSet<ushort>
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
        public override double Divide(ushort X1, ushort X2)
            {
            return (double)(X1 / X2);
            }


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
