namespace orbital_mechanics {
	public class Cartesian {
		private double _x = 0.0;
		private double _y = 0.0;
		private double _z = 0.0;
		public Cartesian() {

		}
		public Cartesian(Cartesian cartesian) {
			set(cartesian);
		}
		public Cartesian(double x, double y, double z) {
			setX(x);
			setY(y);
			setZ(z);
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
		public void setX(double x) {
			_x = x;
		}
		public void setY(double y) {
			_y = y;
		}
		public void setZ(double z) {
			_z = z;
		}
		public void set(Cartesian cartesian) {
			setX(cartesian.X());
			setY(cartesian.Y());
			setZ(cartesian.Z());
		}
	}
}