using System;
using System.Text;

namespace orbital_mechanics {
    public class OrbitalBody {
        Kinematics _kinematics = new Kinematics();
        Cartesian _force = new Cartesian();
        double _mass = double.Epsilon;

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

        public double DistanceFractionBetweenBodiesOnAxis(Func<double> otherBodyPositionOnAxis, Func<double> thisBodyPositionOnAxis, double totalDistance) {
            double axisDistance = otherBodyPositionOnAxis() - thisBodyPositionOnAxis();
            return axisDistance / totalDistance;
        }

#warning needs unit tests
        public double TotalDistanceBetweenBodies(OrbitalBody otherBody) {
            double xDistance = otherBody.Kinematics().Position().X() - this.Kinematics().Position().X();
            double yDistance = otherBody.Kinematics().Position().Y() - this.Kinematics().Position().Y();
            double zDistance = otherBody.Kinematics().Position().Z() - this.Kinematics().Position().Z();

            double totalDistance = Math.Sqrt(xDistance * xDistance + yDistance * yDistance + zDistance * zDistance);

            return (totalDistance != 0.0) ? totalDistance : Double.Epsilon;
        }

#warning needs unit tests
        public double ForceMagnitudeBetweenBodies(OrbitalBody otherBody) {
            double totalDistance = TotalDistanceBetweenBodies(otherBody);

            return (Constants.Gravitational_Constant * Mass() * otherBody.Mass()) / (totalDistance * totalDistance);
        }

#warning needs unit tests
        public void UpdateForce(OrbitalBody otherBody) {
            double totalDistance = TotalDistanceBetweenBodies(otherBody);
            Console.WriteLine("dist: " + totalDistance);
            double xDistanceFraction = DistanceFractionBetweenBodiesOnAxis(otherBody.Kinematics().Position().X, this.Kinematics().Position().X, totalDistance);
            Console.WriteLine("xFrac: " + xDistanceFraction);
            double yDistanceFraction = DistanceFractionBetweenBodiesOnAxis(otherBody.Kinematics().Position().Y, this.Kinematics().Position().Y, totalDistance);
            double zDistanceFraction = DistanceFractionBetweenBodiesOnAxis(otherBody.Kinematics().Position().Z, this.Kinematics().Position().Z, totalDistance);

            double forceMagnitude = ForceMagnitudeBetweenBodies(otherBody);


            Cartesian updatedForce = new Cartesian(forceMagnitude * xDistanceFraction, forceMagnitude * yDistanceFraction, forceMagnitude * zDistanceFraction);
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

        public void UpdateOrbitalBody(OrbitalBody otherBody, double timeStep) {
            Kinematics().UpdateKinematics(timeStep);
            UpdateAcceleration();
            UpdateForce(otherBody);
        }
    }
}