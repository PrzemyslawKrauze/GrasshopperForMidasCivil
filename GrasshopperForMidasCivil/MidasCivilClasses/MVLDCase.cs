using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GrasshopperForMidasCivil.MidasCivilClasses
{
    public class MVLDCase
    {
        public MVLDCase(string name,bool ignorePsi,List<Surflane> surflanes)
        {
            this.Name = name;
            this.IgnorePsi = ignorePsi;
            this.Surflanes = surflanes;
        }

        //Properties
        public string Name { get; set; }
        public bool IgnorePsi { get; set; }
        public string IgnorePsiValue { get { return IgnorePsi ? "YES" : "NO"; }}
        public List<Surflane> Surflanes { get; set; }

        //PublicMethod
        public override string ToString()
        {
            string line = "*MVLDCASE(EURO)\n";
            line += "NAME="+Name+", NO, 1, , Load Model 1, ," + IgnorePsiValue + ",0\n";
            line += "1";
            foreach(Surflane surflane in Surflanes)
            {
                line += "," + surflane.Name;
            }
            return line;
        }
    }
}
