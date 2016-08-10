using System;
using System.Diagnostics.CodeAnalysis;
using LCore.Extensions;

namespace LCore.Statistics
    {
    [ExcludeFromCodeCoverage]
    internal static class StatsExt
        {
        public static int GetOptimumClassCount(long SampleSize)
            {
            return (int)SampleSize.Sqrt().Round();
            }
        public static int GetOptimumClassCount(int SampleSize)
            {
            return (int)SampleSize.Sqrt().Round();
            }

        /// <summary>
        /// Returns the ratio (between 0 and 1) of data that exists within StandardDeviations of the mean.
        /// As per Chebyshev's Inequality.
        /// </summary>
        /// <param name="StandardDeviations">Must be positive</param>
        /// <returns>Returns the ratio (between 0 and 1) of data that exists within StandardDeviations of the mean</returns>
        /// <exception cref="ArgumentException"><paramref name="StandardDeviations" /> was less than 0.</exception>
        public static float GetRatioWithin(double StandardDeviations)
            {
            if (StandardDeviations < 0)
                throw new ArgumentException(nameof(StandardDeviations));

            return (float)(1 - 1 / Math.Pow(StandardDeviations, y: 2));
            }

        /// <summary>
        /// Returns the ratio (between 0 and 1) of data that exists outside of StandardDeviations of the mean.
        /// Derived from Chebyshev's Inequality.
        /// </summary>
        /// <param name="StandardDeviations">Must be positive</param>
        /// <returns>Returns the ratio (between 0 and 1) of data that exists outside of StandardDeviations of the mean</returns>
        /// <exception cref="ArgumentException"><paramref name="StandardDeviations" /> was less than 0.</exception>
        public static float GetRatioWithout(double StandardDeviations)
            {
            if (StandardDeviations < 0)
                throw new ArgumentException(nameof(StandardDeviations));

            return 1 - GetRatioWithin(StandardDeviations);
            }

        /// <summary>
        /// Returns the ratio (between 0 and 1) of data that exists greater than StandardDeviations of the mean.
        /// Derived from Chebyshev's Inequality.
        /// </summary>
        /// <param name="StandardDeviations">May be positive or negative</param>
        /// <returns>Returns the ratio (between 0 and 1) of data that exists greater than StandardDeviations of the mean</returns>
        public static float GetRatioGreaterThan(double StandardDeviations)
            {
            if (StandardDeviations < 0)
                {
                return 1 - GetRatioLessThan(StandardDeviations);
                }
            if (StandardDeviations == 0)
                {
                return 0.5f;
                }
            return GetRatioWithout(StandardDeviations) / 2;
            }

        /// <summary>
        /// Returns the ratio (between 0 and 1) of data that exists less than StandardDeviations of the mean.
        /// Derived from Chebyshev's Inequality.
        /// </summary>
        /// <param name="StandardDeviations">May be positive or negative</param>
        /// <returns>Returns the ratio (between 0 and 1) of data that exists less than StandardDeviations of the mean</returns>
        public static float GetRatioLessThan(double StandardDeviations)
            {
            if (StandardDeviations < 0)
                {
                return GetRatioWithout(StandardDeviations.Abs()) / 2;
                }
            if (StandardDeviations == 0)
                {
                return 0.5f;
                }
            return 1 - GetRatioGreaterThan(StandardDeviations);
            }

        /// <summary>
        /// Returns the ratio (between 0 and 1) of data that exists between the two values of Standard Deviation.
        /// Derived from Chebyshev's Inequality.
        /// </summary>
        /// <param name="MinimumStandardDeviations">Positive or negative, must be less than MaximumStandardDeviations</param>
        /// <param name="MaximumStandardDeviations">Positive or negative, must be more than MaximumStandardDeviations</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Maximum must be greater than minimum.</exception>
        public static float GetRatioWithinRange(double MinimumStandardDeviations, double MaximumStandardDeviations)
            {
            if (MaximumStandardDeviations <= MinimumStandardDeviations)
                throw new ArgumentException("Maximum must be greater than minimum.");

            float Side = GetRatioGreaterThan(MaximumStandardDeviations);
            float Side2 = GetRatioLessThan(MinimumStandardDeviations);

            float Intersection = Side + Side2 - 1f;

            return Intersection;
            }

        /// <summary>
        /// Returns the ratio (between 0 and 1) of data that exists outside of two values of Standard Deviation.
        /// Derived from Chebyshev's Inequality.
        /// </summary>
        /// <param name="MinimumStandardDeviations">Positive or negative, must be less than MaximumStandardDeviations</param>
        /// <param name="MaximumStandardDeviations">Positive or negative, must be more than MaximumStandardDeviations</param>
        /// <returns></returns>
        public static float GetRatioWithoutRange(double MinimumStandardDeviations, double MaximumStandardDeviations)
            {
            return 1 - GetRatioWithinRange(MinimumStandardDeviations, MaximumStandardDeviations);
            }


        /// <summary>
        /// Returns the number of Standard Deviations from the mean must be included to contain the passed Ratio (between 0 and 1) of data.
        /// Derived from Chebyshev's Inequality.
        /// </summary>
        /// <param name="Ratio">Must be between 0 and 1</param>
        /// <returns>Returns the number of Standard Deviations from the mean must be included to contain the passed Ratio (between 0 and 1) of data.</returns>
        /// <exception cref="ArgumentException">Ratio was not not between 0 and 1.</exception>
        public static double GetStandardDeviationRange(float Ratio)
            {
            if (Ratio < 0 || Ratio > 1)
                throw new ArgumentException(nameof(Ratio));

            return Math.Sqrt(1 - 1 / Ratio);
            }

        /// <summary>
        /// Returns the number of Standard Deviations a line must be drawn so that the Ratio greater is equal to the passed Ratio.
        /// Derived from Chebyshev's Inequality.
        /// </summary>
        /// <param name="Ratio">Must be between 0 and 1</param>
        /// <returns>Returns the number of Standard Deviations the line must be drawn so that the Ratio greater is equal to the passed Ratio.</returns>
        /// <exception cref="ArgumentException">Ratio was not not between 0 and 1.</exception>
        public static double GetStandardDeviationLowerRatio(float Ratio)
            {
            if (Ratio < 0 || Ratio > 1)
                throw new ArgumentException("Ratio");

            return Math.Sqrt(1 - 1 / Ratio) / 2 + 0.5f;
            }

        /// <summary>
        /// Returns the number of Standard Deviations a line must be drawn so that the Ratio less then the line is equal to the passed Ratio.
        /// Derived from Chebyshev's Inequality.
        /// </summary>
        /// <param name="Ratio">Must be between 0 and 1</param>
        /// <returns>Returns the number of Standard Deviations a line must be drawn so that the Ratio less then the line is equal to the passed Ratio.</returns>
        /// <exception cref="ArgumentException">Ratio was not not between 0 and 1.</exception>
        public static double GetStandardDeviationUpperRatio(float Ratio)
            {
            if (Ratio < 0 || Ratio > 1)
                throw new ArgumentException(nameof(Ratio));

            return -GetStandardDeviationLowerRatio(1 - Ratio);
            }
        }
    }
