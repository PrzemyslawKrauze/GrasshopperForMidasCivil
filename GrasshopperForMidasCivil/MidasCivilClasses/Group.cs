using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrasshopperForMidasCivil.MidasCivilClasses
{
    internal class Group
    {
        //Constructor
        public Group(string name, List<Node> nodeList, List<Element> elementList)
        {
            this.Name = name;
            Nodes = nodeList;
            Elements = elementList;
        }
        //Properties
        public string Name { get; set; }
        public List<Node> Nodes { get; set; }
        public List<Element> Elements { get; set; }

        //PublicMethod
        public override string ToString()
        {
            string line = "*GROUP\n";
            line += this.Name +",";
            foreach(Node node in Nodes)
            {
                line += node.ID + " ";
            }
            line += ",";
            foreach(Element element in Elements)
            {
                line += element.ID + " ";
            }
            line += ",0,";

            return line;
        }
    }
}
