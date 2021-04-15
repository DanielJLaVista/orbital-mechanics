using System;

namespace orbital_mechanics {
	public class Planet {

		private double _mass = 0.0;

		private Kinematics _kinematics = new Kinematics();

		public Planet() {
		}

		public Planet(Planet planet) {
			Set(planet);
		}




		public void SetKinematics(Kinematics kinematics) {
			_kinematics = kinematics;
		}

		public Kinematics Kinematics() {
			return _kinematics;
		}

		public void SetMass(double mass) {
			_mass = mass;
		}

		public double Mass() {
			return _mass;
		}

		public void Set(Planet planet) {
			SetKinematics(planet.Kinematics());
			SetMass(planet.Mass());
		}
	}
}