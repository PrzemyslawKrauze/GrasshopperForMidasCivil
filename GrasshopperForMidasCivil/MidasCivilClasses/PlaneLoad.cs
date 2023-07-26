using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GrasshopperForMidasCivil
{
    public class PlaneLoad
    {
        //Constructor
        public PlaneLoad(string loadCaseName, PNLoadType pnLoadType, Point3d originPoint, Point3d xAxisPoint, Point3d yAxisPoint)
        {
            this.LoadCaseName = loadCaseName;
            this.PNLoadType = pnLoadType;
            this.OriginPoint = originPoint;
            this.XAxisPoint = xAxisPoint;
            this.YAxisPoint = yAxisPoint;
        }
        public PlaneLoad(string loadCaseName, PNLoadType pnLoadType, Point3d originPoint, Point3d xAxisPoint, Point3d yAxisPoint, string loadDir)
        {
            this.LoadCaseName = loadCaseName;
            this.PNLoadType = pnLoadType;
            this.OriginPoint = originPoint;
            this.XAxisPoint = xAxisPoint;
            this.YAxisPoint = yAxisPoint;
            this.LoadDir = loadDir;
        }

        //Properties
        public string LoadCaseName { get; set; }
        public PNLoadType PNLoadType { get; set; }
        public Point3d OriginPoint { get; set; }
        public Point3d XAxisPoint { get; set; }
        public Point3d YAxisPoint { get; set; }
        public string LoadDir = "NLP";

        //PublicMethods
        public override string ToString()
        {
            string line = "*PLANELOAD\n";
            line += LoadCaseName + "," + PNLoadType.Name + ",PLATE,\n";
            line += "LPLANE, , 1,"+LoadDir+", NO,\n";
            line += OriginPoint.X + "," + OriginPoint.Y + "," + OriginPoint.Z + "," + XAxisPoint.X + "," + XAxisPoint.Y + "," + XAxisPoint.Z + "," +
                YAxisPoint.X + "," + YAxisPoint.Y + "," + YAxisPoint.Z + ",0.001, NO";
            return line;
        }
    }
}
