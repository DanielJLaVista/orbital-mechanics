using System;
using System.Text;

namespace orbital_mechanics {
    public class OrbitalBody {
        Kinematics _kinematics = new Kinematics();
        Cartesian _force = new Cartesian();
        double _mass = Double.Epsilon;

        public OrbitalBody() {

        }

        public OrbitalBody(OrbitalBody orbitalBody) {
            Set(orbitalBody);
        }

        public OrbitalBody(Kinematics kinematics, Cartesian force, double mass) {
            SetKinematics(kinematics);
            SetForce(force);
            SetMass(mass);
        }

        private double XDistanceBetweenBodies(OrbitalBody otherBody) {
            return otherBody.Kinematics().Position().X() - Kinematics().Position().X();
        }

        private double YDistanceBetweenBodies(OrbitalBody otherBody) {
            return otherBody.Kinematics().Position().Y() - Kinematics().Position().Y();
        }
        private double ZDistanceBetweenBodies(OrbitalBody otherBody) {
            return otherBody.Kinematics().Position().Z() - Kinematics().Position().Z();
        }

        private double TotalDistanceBetweenBodies(OrbitalBody otherBody) {
            double xDistance = XDistanceBetweenBodies(otherBody);
            double yDistance = YDistanceBetweenBodies(otherBody);
            double zDistance = ZDistanceBetweenBodies(otherBody);

            double totalDistance = Math.Sqrt(xDistance * xDistance + yDistance * yDistance + zDistance * zDistance);

            return (totalDistance != 0.0) ? totalDistance : Double.Epsilon;
        }

        private double ForceMagnitudeBetweenBodies(OrbitalBody otherBody) {
            double totalDistance = TotalDistanceBetweenBodies(otherBody);

            return (Constants.Gravitational_Constant * Mass() * otherBody.Mass()) / (totalDistance * totalDistance);
        }

        private double XDistanceFractionBetweenBodies(OrbitalBody otherBody) {
            double xDistance = XDistanceBetweenBodies(otherBody);
            double totalDistance = TotalDistanceBetweenBodies(otherBody);
            return xDistance / totalDistance;
        }
        private double YDistanceFractionBetweenBodies(OrbitalBody otherBody) {
            double yDistance = YDistanceBetweenBodies(otherBody);
            double totalDistance = TotalDistanceBetweenBodies(otherBody);
            return yDistance / totalDistance;
        }
        private double ZDistanceFractionBetweenBodies(OrbitalBody otherBody) {
            double zDistance = ZDistanceBetweenBodies(otherBody);
            double totalDistance = TotalDistanceBetweenBodies(otherBody);
            return zDistance / totalDistance;
        }
        public Kinematics Kinematics() {
            return _kinematics;
        }

        public Cartesian Force() {
            return _force;
        }

        public double Mass() {
            return _mass;
        }

        public void SetKinematics(Kinematics kinematics) {
            _kinematics = kinematics;
        }

        public void SetForce(Cartesian force) {
            _force = force;
        }
        public void SetMass(double mass) {
            if (mass != 0) {
                _mass = mass;
            }
#warning raise exception if so?
        }

        public void Set(OrbitalBody orbitalBody) {
            SetKinematics(orbitalBody.Kinematics());
            SetForce(orbitalBody.Force());
            SetMass(orbitalBody.Mass());
        }

#warning needs unit tests
        public void UpdateForce(OrbitalBody otherBody) {
#warning If total distance is zero do we need to do something to avoid NaN??
            double xDistanceFraction = XDistanceBetweenBodies(otherBody);
            double yDistanceFraction = YDistanceBetweenBodies(otherBody);
            double zDistanceFraction = ZDistanceBetweenBodies(otherBody);
            double forceMagnitude = ForceMagnitudeBetweenBodies(otherBody);

            Cartesian updatedForce = new Cartesian(forceMagnitude * xDistanceFraction, forceMagnitude * yDistanceFraction, forceMagnitude * zDistanceFraction);
            SetForce(updatedForce);
        }

#warning needs unit tests
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