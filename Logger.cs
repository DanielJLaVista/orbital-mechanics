using System.Text;

namespace orbital_mechanics{
    
    class Logger{
        public StringBuilder debugStringBuilder;
        public Logger(){
            debugStringBuilder =new StringBuilder();
        }
        public void AddLogPair(string name, double value){
            debugStringBuilder.Append("{" + name + ":");
            debugStringBuilder.Append(value + "}\n");

        }

        public void Clear(){
            debugStringBuilder.Clear();
        }

        public string ToString(){
            return debugStringBuilder.ToString();
        }
    }
}