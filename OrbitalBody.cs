using System;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using Terminal.Gui;

namespace orbital_mechanics
{
    public class OrbitalBody
    {
        private const int XIndex = 0;
        private const int YIndex = 1;
        private const int ZIndex = 2;
        private const int XVelIndex = 3;
        private const int YVelIndex = 4;
        private const int ZVelIndex = 5;
        private const int MassIndex = 6;

        private float[] e = { 0, 0, 0, 0, 0, 0, float.Epsilon };

        public OrbitalBody()
        {

        }

        public OrbitalBody(OrbitalBody orbitalBody)
        {
            Set(orbitalBody);
        }

        public void Set(OrbitalBody orbitalBody)
        {
            SetPosition(orbitalBody.Position());
            SetVelocity(orbitalBody.Velocity());
            SetMass(orbitalBody.Mass());
        }
        public float Mass()
        {
            return e[MassIndex];
        }

        public Vector3 Position()
        {
            Vector3 pos = new(e[XIndex], e[YIndex], e[ZIndex]);
            return pos;
        }

        public Vector3 Velocity()
        {
            Vector3 vel = new(e[XVelIndex], e[YVelIndex], e[ZVelIndex]);
            return vel;
        }

        public OrbitalBody SetPosition(Vector3 position)
        {
            e[XIndex] = position[0];
            e[YIndex] = position[1];
            e[ZIndex] = position[2];
            return this;
        }

        public OrbitalBody SetVelocity(Vector3 velocity)
        {
            e[XVelIndex] = velocity[0];
            e[YVelIndex] = velocity[1];
            e[ZVelIndex] = velocity[2];
            return this;
        }

        public void SetMass(float mass)
        {
            e[MassIndex] = mass;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is not OrbitalBody)
            {
                return false;
            }
            OrbitalBody orbitalBody = (OrbitalBody)obj;
            return Position().Equals(orbitalBody.Position())
                && Velocity().Equals(orbitalBody.Velocity())
                && Mass().Equals(orbitalBody.Mass());
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Position().GetHashCode();
            hash = hash * 23 + Velocity().GetHashCode();
            hash = hash * 23 + Mass().GetHashCode();
            return hash;
        }

        public string MakeString()
        {
            StringBuilder builder = new();

            builder.Append("{Position: {" + Position()[0] + " " + Position()[1] + " " + Position()[2] + "}\n");
            builder.Append("Velocity: {" + Velocity()[0] + " " + Velocity()[1] + " " + Velocity()[2] + "}\n");
            builder.Append("Mass: " + Mass() + "}");

            return builder.ToString();
        }
    }
}