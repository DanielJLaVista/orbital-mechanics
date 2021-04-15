using System.Text;
namespace orbital_mechanics {
	public class Cartesian {
		private double _x = 0.0;
		private double _y = 0.0;
		private double _z = 0.0;
		public Cartesian() {
		}
		public Cartesian(Cartesian cartesian) {
			Set(cartesian);
		}
		public Cartesian(double x, double y, double z) {
			SetX(x);
			SetY(y);
			SetZ(z);
		}
		public double X() {
			return _x;
		}
		public double Y() {
			return _y;
		}
		public double Z() {
			return _z;
		}
		public void SetX(double x) {
			_x = x;
		}
		public void SetY(double y) {
			_y = y;
		}
		public void SetZ(double z) {
			_z = z;
		}
		public void Set(Cartesian cartesian) {
			SetX(cartesian.X());
			SetY(cartesian.Y());
			SetZ(cartesian.Z());
		}

		public override bool Equals(object obj) {
			if (obj == null) {
				return false;
			}
			if (!(obj is Cartesian)) {
				return false;
			}
			return (DoubleComparison.Equals7DigitPrecision(X(), ((Cartesian)obj).X()))
				&& (DoubleComparison.Equals7DigitPrecision(Y(), ((Cartesian)obj).Y()))
				&& (DoubleComparison.Equals7DigitPrecision(Z(), ((Cartesian)obj).Z()));
		}

		public override int GetHashCode() {
#warning Unit test hash code procedure?
#warning Look into hash code builder implementation
			int hash = 17;
			hash = hash * 23 + X().GetHashCode();
			hash = hash * 23 + Y().GetHashCode();
			hash = hash * 23 + Z().GetHashCode();
			return hash;
		}

		public string MakeString() {
#warning Need a better stringify approach
#warning Unit test make string function
			StringBuilder builder = new StringBuilder();

			builder.Append("{X: " + X() + " ");
			builder.Append("Y: " + Y() + " ");
			builder.Append("Z: " + Z() + "}");

			return builder.ToString();
		}
	}
}