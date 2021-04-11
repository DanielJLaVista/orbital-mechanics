using System;

namespace orbital_mechanics {
	public class Planet {
		private Cartesian _position;
		private Cartesian _velocity;
		private Cartesian _force;
		private double _mass;

		private Logger _logger;

		public Planet() {
			_mass = 0.0;
		}

		public void UpdateForce(Planet other) {
			double xDistance = other.Position().X() - this.Position().X();
			double yDistance = other.Position().Y() - this.Position().Y();
			double totalDistance = Math.Sqrt(xDistance * xDistance + yDistance * yDistance);

			double forceMagnitude = (Constants.Gravitational_Constant * this.Mass() * other.Mass()) / (totalDistance * totalDistance);
			double forceXFraction = xDistance / totalDistance;
			double forceYFraction = yDistance / totalDistance;

			_force.setX(forceMagnitude * forceXFraction);
			_force.setY(forceMagnitude * forceYFraction);
		}

		public void UpdateVelocity(double timeStep) {
			double xVelocity = _velocity.X() + (this.Force().X() / this.Mass() * timeStep);
			double yVelocity = _velocity.Y() + (this.Force().Y() / this.Mass() * timeStep);

			_velocity.setX(xVelocity);
			_velocity.setY(yVelocity);
		}

		public void UpdatePosition(double timeStep) {
			double xPosition = _position.X() + (this.Velocity().X() * timeStep);
			double yPosition = _position.Y() + (this.Velocity().Y() * timeStep);

			_velocity.setX(xPosition);
			_velocity.setY(yPosition);
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

		public void SetPosition(Cartesian position) {
			_position = position;
		}

		public void SetVelocity(Cartesian velocity) {
			_velocity = velocity;
		}

		public double Mass() {
			return _mass;
		}
		public void SetMass(double mass) {
			_mass = mass;
		}
	}
}