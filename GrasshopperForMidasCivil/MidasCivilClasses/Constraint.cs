using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrasshopperForMidasCivil
{
    public class Constraint
    {
        public Constraint(Node node,string constrains)
        {
            this.Node = node;
            this.Constrains = constrains;
        }

        //Properties
        Node Node;
        string Constrains;

        public override string ToString()
        {
            string line = "*CONSTRAINT\n";
            line += Node.ID + "," + Constrains+",";
            return line;
        }
    }
}
