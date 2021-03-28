

namespace orbital_mechanics{
    public struct Position{
        public double x_pos;
        public double y_pos;
        public double z_pos;
    }
    public struct Velocity{
        public double x_vel;
        public double y_vel;
        public double z_vel;
    }
    public struct Acceleration{
        public double x_acl;
        public double y_acl;
        public double z_acl;
    }
    class Planet{
        private Position position;
        private Velocity velocity;
        private Acceleration acceleration;

        private Logger logger;

        public Planet (){
            logger = new Logger();

            position.x_pos = 0.0;
            position.y_pos = 0.0;
            position.z_pos = 0.0;

            velocity.x_vel = 0.0;
            velocity.y_vel = 0.0;
            velocity.z_vel = 0.0;

            acceleration.x_acl = 0.0;
            acceleration.y_acl = 0.0;
            acceleration.z_acl = 0.0;
        }
        
        public string position_to_string(){
            logger.Clear();
            logger.AddLogPair("x_pos",position.x_pos);
            logger.AddLogPair("y_pos",position.y_pos);
            logger.AddLogPair("z_pos",position.z_pos);
            
            return logger.ToString();
        }
    }

}