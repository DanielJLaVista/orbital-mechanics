using System.Text;

namespace orbital_mechanics {
    public class Kinematics {
        private Cartesian _position = new Cartesian();
        private Cartesian _velocity = new Cartesian();
        private Cartesian _acceleration = new Cartesian();

        public Kinematics() {

        }

        public Kinematics(Kinematics kinematics) {
            Set(kinematics);
        }

        public Kinematics(Cartesian position, Cartesian velocity, Cartesian acceleration) {
            SetPosition(position);
            SetVelocity(velocity);
            SetAcceleration(acceleration);
        }

        public Cartesian Position() {
            return _position;
        }

        public Cartesian Velocity() {
            return _velocity;
        }

        public Cartesian Acceleration() {
            return _acceleration;
        }

        public void SetPosition(Cartesian position) {
            _position = position;
        }

        public void SetVelocity(Cartesian velocity) {
            _velocity = velocity;
        }

        public void SetAcceleration(Cartesian acceleration) {
            _acceleration = acceleration;
        }

        public void Set(Kinematics kinematics) {
            SetPosition(kinematics.Position());
            SetVelocity(kinematics.Velocity());
            SetAcceleration(kinematics.Acceleration());
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (!(obj is Kinematics)) {
                return false;
            }
            Kinematics kinematics = (Kinematics)obj;
            return Position().Equals(kinematics.Position())
                && Velocity().Equals(kinematics.Velocity())
                && Acceleration().Equals(kinematics.Acceleration());
        }

        public override int GetHashCode() {
            int hash = 17;
            hash = hash * 23 + Position().GetHashCode();
            hash = hash * 23 + Velocity().GetHashCode();
            hash = hash * 23 + Acceleration().GetHashCode();
            return hash;
        }

        public string MakeString() {
            StringBuilder builder = new StringBuilder();

            builder.Append("{Position: " + Position().MakeString() + "\n");
            builder.Append("Velocity: " + Velocity().MakeString() + "\n");
            builder.Append("Acceleration: " + Acceleration().MakeString() + "}");

            return builder.ToString();
        }

        public void UpdatePosition(double timeStep) {
            double xPosition = Position().X() + (Velocity().X() * timeStep);
            double yPosition = Position().Y() + (Velocity().Y() * timeStep);
            double zPosition = Position().Z() + (Velocity().Z() * timeStep);

            Cartesian updatedPosition = new Cartesian(xPosition, yPosition, zPosition);
            SetPosition(updatedPosition);
        }

        public void UpdateVelocity(double timeStep) {
            double xVelocity = Velocity().X() + (Acceleration().X() * timeStep);
            double yVelocity = Velocity().Y() + (Acceleration().Y() * timeStep);
            double zVelocity = Velocity().Z() + (Acceleration().Z() * timeStep);

            Cartesian updatedVelocity = new Cartesian(xVelocity, yVelocity, zVelocity);
            SetVelocity(updatedVelocity);
        }
    }
}