using System;

namespace orbital_mechanics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Planet planet1 = new Planet();
            
            planet1.SetPosition(new Cartesian(0.0,0.0,0.0));
            planet1.SetMass(5.9722e24);
            Planet planet2 = new Planet();
            planet2.SetPosition(new Cartesian(6780000.0,0.0,0.0));
            planet2.SetVelocity(new Cartesian(0.0,7672.0,0.0));
            planet2.SetMass(1.0);
            while (true){
            //for(int i = 0; i < 1000; i++){
                planet1.UpdateForce(planet2);
                planet2.UpdateForce(planet1);
                planet1.UpdateVelocity(1.0);
                planet1.UpdatePosition(1.0);
                planet2.UpdateVelocity(1.0);
                planet2.UpdatePosition(1.0);
            }
        }
    }
}
