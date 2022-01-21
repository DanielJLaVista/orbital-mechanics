using System;



namespace orbital_mechanics {
    class Program {
        static void Main(string[] args) {

            GraphicsHandler graphics = new GraphicsHandler();
            Console.WriteLine("Hello World!");
            Planet planet1 = new Planet();
            Planet planet2 = new Planet();
            planet1.OrbitalBody().SetMass(5.9722e24);
            planet2.OrbitalBody().Kinematics().SetPosition(new Cartesian(6780000.0, 0.0, 0.0));
            planet2.OrbitalBody().Kinematics().SetVelocity(new Cartesian(0.0, 7672.0, 0.0));


            // while (true) {
            // for (int i = 0; i < 10; i++) {


            while (graphics.Window().Exists) {
                graphics.Window().PumpEvents();
                graphics.Draw();

                planet1.OrbitalBody().UpdateOrbitalBody(planet2.OrbitalBody(), 1.0);
                planet2.OrbitalBody().UpdateOrbitalBody(planet1.OrbitalBody(), 1.0);

                Console.WriteLine(planet1.OrbitalBody().Force().MakeString());
                // Console.WriteLine(planet2.OrbitalBody().Kinematics().Position().MakeString());
            }
            graphics.DisposeResources();
            // }
        }


    }
}