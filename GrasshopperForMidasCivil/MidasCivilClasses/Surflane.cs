using Rhino.DocObjects.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrasshopperForMidasCivil
{
    public class Surflane
    {
        //Constructor
        public Surflane(string name, double width, double offset, Node startNode, Node endNode)
        {
            this.Name = name;
            this.Width = width;
            this.Offset = offset;
            this.StartNode = startNode;
            this.EndNode = endNode;
        }

        //Properties
        public string Name { get; set; }
        public double Width { get; set; }
        public double Offset { get; set; }
        public Node StartNode { get; set; }
        public Node EndNode { get; set; }

        //PublicMethod
        public override string ToString()
        {
            string line = "*SURFLANE\n";
            line += "NAME=" + this.Name + "," + this.Width + ",0,0,BOTH,2,NO," + this.Width+"\n";
            line += StartNode.ID + "," + this.Offset + ",0,NO,0,0.5,   ";
            line += EndNode.ID + "," + this.Offset + ",0,NO,0,0.5";
            return line;
        }
    }
}
