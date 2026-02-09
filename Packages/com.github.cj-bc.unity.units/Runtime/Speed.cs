using System;

namespace CjBc.Unity.Units
{
    /// <summary>
    /// Represents a speed value with support for multiple units of measurement.
    /// Internally stores the value in meters per second (m/s).
    /// </summary>
    public readonly struct Speed : IEquatable<Speed>, IComparable<Speed>
    {
        /// <summary>
        /// The speed value in meters per second.
        /// </summary>
        public double MetersPerSecond { get; }

        /// <summary>
        /// The speed value converted to kilometers per hour.
        /// </summary>
        public double KilometersPerHour => MetersPerSecond * 3.6;

        /// <summary>
        /// The speed value converted to miles per hour.
        /// </summary>
        public double MilesPerHour => MetersPerSecond * 2.2369362920544;

        /// <summary>
        /// The speed value converted to knots.
        /// </summary>
        public double Knots => MetersPerSecond * 1.9438444924406;

        /// <summary>
        /// A Speed value of zero.
        /// </summary>
        public static readonly Speed Zero = new Speed(0);

        private Speed(double metersPerSecond)
        {
            MetersPerSecond = metersPerSecond;
        }

        public static Speed FromMetersPerSecond(double value)
        {
            return new Speed(value);
        }

        public static Speed FromKilometersPerHour(double value)
        {
            return new Speed(value / 3.6);
        }

        public static Speed FromMilesPerHour(double value)
        {
            return new Speed(value / 2.2369362920544);
        }

        public static Speed FromKnots(double value)
        {
            return new Speed(value / 1.9438444924406);
        }

        // Arithmetic operators
        public static Speed operator +(Speed a, Speed b)
        {
            return new Speed(a.MetersPerSecond + b.MetersPerSecond);
        }

        public static Speed operator -(Speed a, Speed b)
        {
            return new Speed(a.MetersPerSecond - b.MetersPerSecond);
        }

        public static Speed operator *(Speed a, double scalar)
        {
            return new Speed(a.MetersPerSecond * scalar);
        }

        public static Speed operator *(double scalar, Speed a)
        {
            return new Speed(a.MetersPerSecond * scalar);
        }

        public static Speed operator /(Speed a, double scalar)
        {
            return new Speed(a.MetersPerSecond / scalar);
        }

        public static Speed operator -(Speed a)
        {
            return new Speed(-a.MetersPerSecond);
        }

        // Comparison operators
        public static bool operator ==(Speed a, Speed b)
        {
            return a.MetersPerSecond == b.MetersPerSecond;
        }

        public static bool operator !=(Speed a, Speed b)
        {
            return a.MetersPerSecond != b.MetersPerSecond;
        }

        public static bool operator <(Speed a, Speed b)
        {
            return a.MetersPerSecond < b.MetersPerSecond;
        }

        public static bool operator >(Speed a, Speed b)
        {
            return a.MetersPerSecond > b.MetersPerSecond;
        }

        public static bool operator <=(Speed a, Speed b)
        {
            return a.MetersPerSecond <= b.MetersPerSecond;
        }

        public static bool operator >=(Speed a, Speed b)
        {
            return a.MetersPerSecond >= b.MetersPerSecond;
        }

        // IEquatable<Speed>
        public bool Equals(Speed other)
        {
            return MetersPerSecond == other.MetersPerSecond;
        }

        public override bool Equals(object obj)
        {
            return obj is Speed other && Equals(other);
        }

        public override int GetHashCode()
        {
            return MetersPerSecond.GetHashCode();
        }

        // IComparable<Speed>
        public int CompareTo(Speed other)
        {
            return MetersPerSecond.CompareTo(other.MetersPerSecond);
        }

        public override string ToString()
        {
            return $"{MetersPerSecond} m/s";
        }
    }
}
