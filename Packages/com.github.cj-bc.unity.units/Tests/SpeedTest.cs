using NUnit.Framework;
using CjBc.Unity.Units;

namespace CjBc.Unity.Units.Tests
{
    [TestFixture]
    public class SpeedTest
    {
        private const double Tolerance = 1e-6;

        // --- Factory methods and unit conversions ---

        [Test]
        public void FromMetersPerSecond_StoresValueCorrectly()
        {
            var speed = Speed.FromMetersPerSecond(10.0);
            Assert.That(speed.MetersPerSecond, Is.EqualTo(10.0).Within(Tolerance));
        }

        [Test]
        public void FromKilometersPerHour_ConvertsToMetersPerSecond()
        {
            var speed = Speed.FromKilometersPerHour(36.0);
            Assert.That(speed.MetersPerSecond, Is.EqualTo(10.0).Within(Tolerance));
        }

        [Test]
        public void FromMilesPerHour_ConvertsToMetersPerSecond()
        {
            var speed = Speed.FromMilesPerHour(1.0);
            Assert.That(speed.MetersPerSecond, Is.EqualTo(0.44704).Within(1e-4));
        }

        [Test]
        public void FromKnots_ConvertsToMetersPerSecond()
        {
            var speed = Speed.FromKnots(1.0);
            Assert.That(speed.MetersPerSecond, Is.EqualTo(0.514444).Within(1e-4));
        }

        [Test]
        public void KilometersPerHour_ReturnsCorrectValue()
        {
            var speed = Speed.FromMetersPerSecond(10.0);
            Assert.That(speed.KilometersPerHour, Is.EqualTo(36.0).Within(Tolerance));
        }

        [Test]
        public void MilesPerHour_ReturnsCorrectValue()
        {
            var speed = Speed.FromMetersPerSecond(1.0);
            Assert.That(speed.MilesPerHour, Is.EqualTo(2.236936).Within(1e-4));
        }

        [Test]
        public void Knots_ReturnsCorrectValue()
        {
            var speed = Speed.FromMetersPerSecond(1.0);
            Assert.That(speed.Knots, Is.EqualTo(1.943844).Within(1e-4));
        }

        [Test]
        public void RoundTrip_KilometersPerHour()
        {
            var original = 120.0;
            var speed = Speed.FromKilometersPerHour(original);
            Assert.That(speed.KilometersPerHour, Is.EqualTo(original).Within(Tolerance));
        }

        [Test]
        public void RoundTrip_MilesPerHour()
        {
            var original = 60.0;
            var speed = Speed.FromMilesPerHour(original);
            Assert.That(speed.MilesPerHour, Is.EqualTo(original).Within(Tolerance));
        }

        [Test]
        public void RoundTrip_Knots()
        {
            var original = 50.0;
            var speed = Speed.FromKnots(original);
            Assert.That(speed.Knots, Is.EqualTo(original).Within(Tolerance));
        }

        // --- Zero ---

        [Test]
        public void Zero_HasZeroMetersPerSecond()
        {
            Assert.That(Speed.Zero.MetersPerSecond, Is.EqualTo(0.0).Within(Tolerance));
        }

        // --- Arithmetic operators ---

        [Test]
        public void Addition_ReturnsSumOfSpeeds()
        {
            var a = Speed.FromMetersPerSecond(3.0);
            var b = Speed.FromMetersPerSecond(7.0);
            var result = a + b;
            Assert.That(result.MetersPerSecond, Is.EqualTo(10.0).Within(Tolerance));
        }

        [Test]
        public void Subtraction_ReturnsDifferenceOfSpeeds()
        {
            var a = Speed.FromMetersPerSecond(10.0);
            var b = Speed.FromMetersPerSecond(3.0);
            var result = a - b;
            Assert.That(result.MetersPerSecond, Is.EqualTo(7.0).Within(Tolerance));
        }

        [Test]
        public void MultiplyByScalar_Right()
        {
            var speed = Speed.FromMetersPerSecond(5.0);
            var result = speed * 3.0;
            Assert.That(result.MetersPerSecond, Is.EqualTo(15.0).Within(Tolerance));
        }

        [Test]
        public void MultiplyByScalar_Left()
        {
            var speed = Speed.FromMetersPerSecond(5.0);
            var result = 3.0 * speed;
            Assert.That(result.MetersPerSecond, Is.EqualTo(15.0).Within(Tolerance));
        }

        [Test]
        public void DivideByScalar_ReturnsDividedSpeed()
        {
            var speed = Speed.FromMetersPerSecond(15.0);
            var result = speed / 3.0;
            Assert.That(result.MetersPerSecond, Is.EqualTo(5.0).Within(Tolerance));
        }

        [Test]
        public void UnaryNegation_NegatesSpeed()
        {
            var speed = Speed.FromMetersPerSecond(5.0);
            var result = -speed;
            Assert.That(result.MetersPerSecond, Is.EqualTo(-5.0).Within(Tolerance));
        }

        // --- Comparison operators ---

        [Test]
        public void Equality_SameValue_ReturnsTrue()
        {
            var a = Speed.FromMetersPerSecond(5.0);
            var b = Speed.FromMetersPerSecond(5.0);
            Assert.That(a == b, Is.True);
        }

        [Test]
        public void Equality_DifferentValue_ReturnsFalse()
        {
            var a = Speed.FromMetersPerSecond(5.0);
            var b = Speed.FromMetersPerSecond(10.0);
            Assert.That(a == b, Is.False);
        }

        [Test]
        public void Inequality_DifferentValue_ReturnsTrue()
        {
            var a = Speed.FromMetersPerSecond(5.0);
            var b = Speed.FromMetersPerSecond(10.0);
            Assert.That(a != b, Is.True);
        }

        [Test]
        public void LessThan_SmallerValue_ReturnsTrue()
        {
            var a = Speed.FromMetersPerSecond(3.0);
            var b = Speed.FromMetersPerSecond(5.0);
            Assert.That(a < b, Is.True);
        }

        [Test]
        public void LessThan_LargerValue_ReturnsFalse()
        {
            var a = Speed.FromMetersPerSecond(5.0);
            var b = Speed.FromMetersPerSecond(3.0);
            Assert.That(a < b, Is.False);
        }

        [Test]
        public void GreaterThan_LargerValue_ReturnsTrue()
        {
            var a = Speed.FromMetersPerSecond(5.0);
            var b = Speed.FromMetersPerSecond(3.0);
            Assert.That(a > b, Is.True);
        }

        [Test]
        public void LessThanOrEqual_EqualValues_ReturnsTrue()
        {
            var a = Speed.FromMetersPerSecond(5.0);
            var b = Speed.FromMetersPerSecond(5.0);
            Assert.That(a <= b, Is.True);
        }

        [Test]
        public void GreaterThanOrEqual_EqualValues_ReturnsTrue()
        {
            var a = Speed.FromMetersPerSecond(5.0);
            var b = Speed.FromMetersPerSecond(5.0);
            Assert.That(a >= b, Is.True);
        }

        // --- IEquatable<Speed> ---

        [Test]
        public void Equals_SameValue_ReturnsTrue()
        {
            var a = Speed.FromMetersPerSecond(5.0);
            var b = Speed.FromMetersPerSecond(5.0);
            Assert.That(a.Equals(b), Is.True);
        }

        [Test]
        public void Equals_DifferentValue_ReturnsFalse()
        {
            var a = Speed.FromMetersPerSecond(5.0);
            var b = Speed.FromMetersPerSecond(10.0);
            Assert.That(a.Equals(b), Is.False);
        }

        [Test]
        public void Equals_Object_SameValue_ReturnsTrue()
        {
            var a = Speed.FromMetersPerSecond(5.0);
            object b = Speed.FromMetersPerSecond(5.0);
            Assert.That(a.Equals(b), Is.True);
        }

        [Test]
        public void Equals_Object_DifferentType_ReturnsFalse()
        {
            var a = Speed.FromMetersPerSecond(5.0);
            Assert.That(a.Equals("not a speed"), Is.False);
        }

        [Test]
        public void GetHashCode_SameValue_ReturnsSameHash()
        {
            var a = Speed.FromMetersPerSecond(5.0);
            var b = Speed.FromMetersPerSecond(5.0);
            Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()));
        }

        // --- IComparable<Speed> ---

        [Test]
        public void CompareTo_SmallerValue_ReturnsNegative()
        {
            var a = Speed.FromMetersPerSecond(3.0);
            var b = Speed.FromMetersPerSecond(5.0);
            Assert.That(a.CompareTo(b), Is.LessThan(0));
        }

        [Test]
        public void CompareTo_EqualValue_ReturnsZero()
        {
            var a = Speed.FromMetersPerSecond(5.0);
            var b = Speed.FromMetersPerSecond(5.0);
            Assert.That(a.CompareTo(b), Is.EqualTo(0));
        }

        [Test]
        public void CompareTo_LargerValue_ReturnsPositive()
        {
            var a = Speed.FromMetersPerSecond(5.0);
            var b = Speed.FromMetersPerSecond(3.0);
            Assert.That(a.CompareTo(b), Is.GreaterThan(0));
        }

        // --- ToString ---

        [Test]
        public void ToString_ReturnsFormattedString()
        {
            var speed = Speed.FromMetersPerSecond(10.5);
            Assert.That(speed.ToString(), Is.EqualTo("10.5 m/s"));
        }

        // --- Cross-unit arithmetic ---

        [Test]
        public void Addition_DifferentUnits_WorksCorrectly()
        {
            var a = Speed.FromKilometersPerHour(36.0); // 10 m/s
            var b = Speed.FromMetersPerSecond(5.0);
            var result = a + b;
            Assert.That(result.MetersPerSecond, Is.EqualTo(15.0).Within(Tolerance));
        }
    }
}
