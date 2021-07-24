using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace GrasshopperForMidasCivil
{
    public class Node
    {
        //Constructor
        public Node(Point3d point)
        {
            this.ID = Interlocked.Increment(ref nextID);
            this.xyz = point;
        }
        #region PublicMethods
        public static void ResetID()
        {
            nextID = 0;
        }
        public static void SetIDPrefix(int prefix)
        {
            nextID = prefix;
        }
        public override string ToString()
        {
            string line = this.ID + "," + this.X + "," + this.Y + "," + this.Z;
            return line;
        }
        public static string ListToString(List<Node> nodeList)
        {
            string line = "*NODE\n";
            foreach (Node node in nodeList)
            {
                line += node.ToString();
                line += "\n";
            }
            return line;
        }
        public double DistanceTo(Node node)
        {
            return this.XYZ.DistanceTo(node.XYZ);
        }
        #endregion
        #region PublicProperties
        public int ID { get;  set; }
        public Point3d XYZ { get { return xyz; } }
        public double X { get { return xyz.X; } }
        public double Y { get { return xyz.Y; } }
        public double Z { get { return xyz.Z; } }
        #endregion
        #region PrivateFields
        static int nextID;
        Point3d xyz;
        #endregion
    }
}
