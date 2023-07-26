using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GrasshopperForMidasCivil
{
    public class ElasticLink
    {
        //Fields
        static int nextID;
        public ElasticLink(Node startNode, Node endNode)
        {
            this.ID = Interlocked.Increment(ref nextID);
            this.StartNode = startNode;
            this.EndNode = endNode;
        }

        //Properties
        public int ID { get; set; }
        public Node StartNode { get; set; }
        public Node EndNode { get; set; }

        //PublicMethod
        public override string ToString()
        {
            string line = "*ELASTICLINK\n";
            line += ID + "," + StartNode.ID + "," + EndNode.ID + ",RIGID,0, NO, 0.5, 0.5,";
            return line;
        }
    }
}
