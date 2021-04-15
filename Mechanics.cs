namespace orbital_mechanics_test.bin {
	public class Mechanics {
		Kinematics _kinematics = new Kinematics();
		Cartesian _force = new Cartesian();
		double _mass = 0.0;

		public void UpdatePosition(double timeStep) {
			double xPosition = Position().X() + (Velocity().X() * timeStep);
			double yPosition = Position().Y() + (Velocity().Y() * timeStep);
			double zPosition = Position().Z() + (Velocity().Z() * timeStep);

			Cartesian updatedPosition = new Cartesian(xPosition, yPosition, zPosition);
			SetPosition(updatedPosition);
		}

		public void UpdateVelocity(double timeStep, double mass) {
			double xVelocity = Velocity().X() + (Force().X() / mass * timeStep);
			double yVelocity = Velocity().Y() + (Force().Y() / mass * timeStep);
			double zVelocity = Velocity().Z() + (Force().Z() / mass * timeStep);

			Cartesian updatedVelocity = new Cartesian(xVelocity, yVelocity, zVelocity);
			SetVelocity(updatedVelocity);
		}

		public void UpdateForce(Planet other) {
			double xDistance = other.Kinematics().Position().X() - Kinematics().Position().X();
			double yDistance = other.Kinematics().Position().Y() - Kinematics().Position().Y();
			double zDistance = other.Kinematics().Position().Z() - Kinematics().Position().Z();
			double totalDistance = Math.Sqrt(xDistance * xDistance + yDistance * yDistance + zDistance * zDistance);

			double forceMagnitude = (Constants.Gravitational_Constant * Mass() * other.Mass()) / (totalDistance * totalDistance);
			double forceXFraction = xDistance / totalDistance;
			double forceYFraction = yDistance / totalDistance;
			double forceZFraction = zDistance / totalDistance;

			Cartesian updatedForce = new Cartesian(forceMagnitude * forceXFraction, forceMagnitude * forceYFraction, forceMagnitude * forceZFraction);
			_kinematics.SetForce(updatedForce);
		}

	}
}