using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    public class Igrac
    {
        public string name { get; set; }
        public int points { get; set; }

        public Igrac(string name,int points) {
            this.name = name;
            this.points = points;
        }

        public override string ToString()
        {
            return this.name + " - " + this.points; 
        }
    }
}
