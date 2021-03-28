using System;

namespace orbital_mechanics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Planet planet = new Planet();
            Console.WriteLine(planet.position_to_string());
        }
    }
}
