using System;
using System.Numerics;
using System.Reflection;

namespace orbital_mechanics
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            Random random = new();

            OrbitalBody[] bodies = new OrbitalBody[10];
            for (int i = 0; i < bodies.Length; i++)
            {
                bodies[i] = new OrbitalBody().SetPosition(new Vector3(random.Next(), random.Next(), random.Next()));
                Console.WriteLine(bodies[i].MakeString());
            }

            float dt = 1.0f;
            for (int body1Idx = 0; body1Idx < bodies.Length; body1Idx++)
            {
                Vector3 AccelerationFromGravity = new(0, 0, 0);
                for (int body2Idx = 0; body2Idx < bodies.Length; body2Idx++)
                {
                    if (body1Idx != body2Idx)
                    {
                        Vector3 DistanceBetweenBodies = new(0, 0, 0);
                        DistanceBetweenBodies[0] = bodies[body1Idx].Position()[0] - bodies[body2Idx].Position()[0];
                        DistanceBetweenBodies[1] = bodies[body1Idx].Position()[1] - bodies[body2Idx].Position()[1];
                        DistanceBetweenBodies[2] = bodies[body1Idx].Position()[2] - bodies[body2Idx].Position()[2];

                        float AbsoluteDistance = (float)Math.Sqrt(DistanceBetweenBodies[0] * DistanceBetweenBodies[0]
                        + DistanceBetweenBodies[1] * DistanceBetweenBodies[1]
                        + DistanceBetweenBodies[2] * DistanceBetweenBodies[2]);

                        float Acceleration = -1.0f * Constants.Gravitational_Constant * (bodies[body2Idx].Mass()) / (float)Math.Pow(AbsoluteDistance, 2);
                        Vector3 DistanceUnitVector = new((float)(DistanceBetweenBodies[0] / AbsoluteDistance), (float)(DistanceBetweenBodies[1] / AbsoluteDistance), (float)(DistanceBetweenBodies[2] / AbsoluteDistance));

                        AccelerationFromGravity[0] = Acceleration * DistanceUnitVector[0];
                        AccelerationFromGravity[1] = Acceleration * DistanceUnitVector[1];
                        AccelerationFromGravity[2] = Acceleration * DistanceUnitVector[2];
                    }
                }
                Vector3 vel = new(AccelerationFromGravity[0] * dt, AccelerationFromGravity[1] * dt, AccelerationFromGravity[2] * dt);
                bodies[body1Idx].SetVelocity(vel);
            }
            for (int i = 0; i < bodies.Length; i++)
            {
                Vector3 newPos = bodies[i].Position();
                newPos[0] += bodies[i].Velocity()[0] * dt;
                newPos[1] += bodies[i].Velocity()[1] * dt;
                newPos[2] += bodies[i].Velocity()[2] * dt;
                bodies[i].SetPosition(newPos);
            }
            foreach (OrbitalBody body in bodies)
            {
                Console.WriteLine(body.Position().ToString());
            }
        }
    }
}