using System;

namespace orbital_mechanics{
    public struct Cartesian{
        public double x;
        public double y;
        public double z;

        public Cartesian(double _x, double _y, double _z){
            x=_x;
            y=_y;
            z=_z;
        }
    }
    
    class Planet{
        private Cartesian _position;
        private Cartesian _velocity;
        private Cartesian _force;
        private double _mass;

        private Logger _logger;

        public Planet (){
            _position.x = 0.0;
            _position.y = 0.0;

            _velocity.x = 0.0;
            _velocity.y = 0.0;

            _force.x = 0.0;
            _force.y = 0.0;

            _mass = 0.0;
        }

        public void UpdateForce(Planet other){
            double xDistance = other.Position().x - this.Position().x;
            double yDistance = other.Position().y - this.Position().y;
            double totalDistance = Math.Sqrt(xDistance*xDistance + yDistance*yDistance);
            
            double forceMagnitude = (Constants.Gravitational_Constant * this.Mass() * other.Mass())/(totalDistance * totalDistance);
            double forceXFraction = xDistance/totalDistance;
            double forceYFraction = yDistance/totalDistance;

            _force.x = forceMagnitude*forceXFraction;
            _force.y = forceMagnitude*forceYFraction;
       }

       public void UpdateVelocity(double timeStep){
           _velocity.x += this.Force().x / this.Mass() * timeStep;
           _velocity.y += this.Force().y / this.Mass() * timeStep;
       }

       public void UpdatePosition(double timeStep){
           _position.x += this.Velocity().x * timeStep;
           _position.y += this.Velocity().y * timeStep;
       }
        public Cartesian Position(){
            return _position;
        }

        public Cartesian Velocity(){
            return _velocity;
        }

        public Cartesian Force(){
            return _force;
        }

        public void SetPosition(Cartesian position){
            _position = position;
        }

        public void SetVelocity(Cartesian velocity){
            _velocity = velocity;
        }

        public double Mass(){
            return _mass;
        }
        public void SetMass(double mass){
            _mass = mass;
        }

    }

}