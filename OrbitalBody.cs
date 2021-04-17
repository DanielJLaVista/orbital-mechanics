using System;
using System.Text;

namespace orbital_mechanics {
    public class OrbitalBody {
        Kinematics _kinematics = new Kinematics();
        Cartesian _force = new Cartesian();
        double _mass = 0.0;

        Kinematics Kinematics() {
            return _kinematics;
        }

        Cartesian Force() {
            return _force;
        }

        double Mass() {
            return _mass;
        }

        void SetKinematics(Kinematics kinematics) {
            _kinematics = kinematics;
        }

        void SetForce(Cartesian force) {
            _force = force;
        }
        void SetForce(double mass) {
            _mass = mass;
        }
        public void UpdateForce(OrbitalBody other) {
            double xDistance = other.Kinematics().Position().X() - Kinematics().Position().X();
            double yDistance = other.Kinematics().Position().Y() - Kinematics().Position().Y();
            double zDistance = other.Kinematics().Position().Z() - Kinematics().Position().Z();
            double totalDistance = Math.Sqrt(xDistance * xDistance + yDistance * yDistance + zDistance * zDistance);

            double forceMagnitude = (Constants.Gravitational_Constant * Mass() * other.Mass()) / (totalDistance * totalDistance);
            double forceXFraction = xDistance / totalDistance;
            double forceYFraction = yDistance / totalDistance;
            double forceZFraction = zDistance / totalDistance;

            Cartesian updatedForce = new Cartesian(forceMagnitude * forceXFraction, forceMagnitude * forceYFraction, forceMagnitude * forceZFraction);
            SetForce(updatedForce);
        }

        public void UpdateAcceleration() {
            double xAcceleration = Force().X() / Mass();
            double yAcceleration = Force().Y() / Mass();
            double zAcceleration = Force().Z() / Mass();
            Cartesian updatedAcceleration = new Cartesian(xAcceleration, yAcceleration, zAcceleration);

            _kinematics.SetAcceleration(updatedAcceleration);
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (!(obj is OrbitalBody)) {
                return false;
            }
            OrbitalBody orbitalBody = (OrbitalBody)obj;
            return Kinematics().Equals(orbitalBody.Kinematics())
                && Force().Equals(orbitalBody.Force())
                && Mass().Equals(orbitalBody.Mass());
        }

        public override int GetHashCode() {
            int hash = 17;
            hash = hash * 23 + Kinematics().GetHashCode();
            hash = hash * 23 + Force().GetHashCode();
            hash = hash * 23 + Mass().GetHashCode();
            return hash;
        }

        public string MakeString() {
            StringBuilder builder = new StringBuilder();

            builder.Append("{Kinematics: " + Kinematics().MakeString() + "\n");
            builder.Append("Force: " + Force().MakeString() + "\n");
            builder.Append("Mass: " + Mass() + "}");

            return builder.ToString();
        }
    }
}