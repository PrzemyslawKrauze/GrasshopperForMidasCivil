using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrasshopperForMidasCivil
{
    public class Thickness
    {
        //Constructor
        public Thickness(int id,double value)
        {
            this.ID = id;
            this.Value = value;
        }

        //Properties
        public int ID { get; }
        public double Value { get; }

        //PublicMethod
        public override string ToString()
        {
            string line = "*THICKNESS\n";
            line += ID + ",VALUE," + ID + ",YES," + Value + ", 0,  NO, 0, 0";
            return line;
        }      
    }
}
