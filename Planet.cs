using System;

namespace orbital_mechanics {
	public class Planet {
		private Cartesian _position = new Cartesian();
		private Cartesian _velocity = new Cartesian();
		private Cartesian _force = new Cartesian();
		private double _mass = 0.0;

		private Logger _logger;

		public Planet() {

		}

		public void UpdatePosition(double timeStep) {
			double xPosition = Position().X() + (Velocity().X() * timeStep);
			double yPosition = Position().Y() + (Velocity().Y() * timeStep);
			double zPosition = Position().Z() + (Velocity().Z() * timeStep);

			Cartesian updatedPosition = new Cartesian(xPosition, yPosition, zPosition);
			SetPosition(updatedPosition);
		}

		public void UpdateVelocity(double timeStep) {
			double xVelocity = Velocity().X() + (Force().X() / Mass() * timeStep);
			double yVelocity = Velocity().Y() + (Force().Y() / Mass() * timeStep);
			double zVelocity = Velocity().Z() + (Force().Y() / Mass() * timeStep);

			Cartesian updatedVelocity = new Cartesian(xVelocity, yVelocity, zVelocity);
			SetVelocity(updatedVelocity);
		}

		public void UpdateForce(Planet other) {
			double xDistance = other.Position().X() - Position().X();
			double yDistance = other.Position().Y() - Position().Y();
			double zDistance = other.Position().Z() - Position().Z();
			double totalDistance = Math.Sqrt(xDistance * xDistance + yDistance * yDistance + zDistance * zDistance);

			double forceMagnitude = (Constants.Gravitational_Constant * Mass() * other.Mass()) / (totalDistance * totalDistance);
			double forceXFraction = xDistance / totalDistance;
			double forceYFraction = yDistance / totalDistance;
			double forceZFraction = zDistance / totalDistance;

			Cartesian updatedForce = new Cartesian(forceMagnitude * forceXFraction, forceMagnitude * forceYFraction, forceMagnitude * forceZFraction);
			SetForce(updatedForce);
		}

		public Cartesian Position() {
			return _position;
		}

		public Cartesian Velocity() {
			return _velocity;
		}

		public Cartesian Force() {
			return _force;
		}

		public double Mass() {
			return _mass;
		}

		public void SetPosition(Cartesian position) {
			_position = position;
		}

		public void SetVelocity(Cartesian velocity) {
			_velocity = velocity;
		}

		public void SetForce(Cartesian force) {
			_force = force;
		}

		public void SetMass(double mass) {
			_mass = mass;
		}
	}
}