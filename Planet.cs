using System.Text;

namespace orbital_mechanics {
    public class Planet {

        private OrbitalBody _orbitalBody;
        public Planet() {
        }

        public Planet(Planet planet) {
            Set(planet);
        }

        public void SetOrbitalBody(OrbitalBody orbitalBody) {
            _orbitalBody = orbitalBody;
        }

        public OrbitalBody OrbitalBody() {
            return _orbitalBody;
        }

        public void Set(Planet planet) {
            SetOrbitalBody(planet.OrbitalBody());
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (!(obj is Planet)) {
                return false;
            }
            Planet planet = (Planet)obj;
            return OrbitalBody().Equals(planet.OrbitalBody());
        }

        public override int GetHashCode() {
            int hash = 17;
            hash = hash * 23 + OrbitalBody().GetHashCode();
            return hash;
        }

        public string MakeString() {
            StringBuilder builder = new StringBuilder();

            builder.Append("{OrbitalBody: " + OrbitalBody().MakeString() + "\n");

            return builder.ToString();
        }
    }
}