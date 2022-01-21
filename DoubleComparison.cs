using System;
namespace orbital_mechanics {
    public static class DoubleComparison {
#warning Implement other levels of precision?
#warning Is there a better approach than a static class?
        const double _7 = 0.0000001;

        private static bool checkNaN(double left, double right) {
            return Double.IsNaN(left) && Double.IsNaN(right);
        }

        private static bool checkPositiveInfinity(double left, double right) {
            return Double.IsPositiveInfinity(left) && Double.IsPositiveInfinity(right);
        }

        private static bool checkNegativeInfinity(double left, double right) {
            return Double.IsNegativeInfinity(left) && Double.IsNegativeInfinity(right);
        }
        public static bool RobustDoubleEquals(double left, double right) {
            return checkNaN(left, right) || checkPositiveInfinity(left, right) || checkNegativeInfinity(left, right) || Equals7DigitPrecision(left, right);
        }

        public static bool Equals7DigitPrecision(double left, double right) {
            return Math.Abs(left - right) < _7;
        }
    }
}