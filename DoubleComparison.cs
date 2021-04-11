using System;
namespace orbital_mechanics {
	public static class DoubleComparison {
#warning Implement other levels of precision?
#warning Is there a better approach than a static class?
		const double _7 = 0.0000001;

		public static bool Equals7DigitPrecision(double left, double right) {
			return Math.Abs(left - right) < _7;
		}
	}
}