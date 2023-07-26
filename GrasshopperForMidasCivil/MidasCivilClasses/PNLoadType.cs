using GH_IO.Serialization;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GrasshopperForMidasCivil
{
    public class PNLoadType
    {
        //Constructor
        public PNLoadType() { }
        public PNLoadType(string name, List<Point3d> points, List<double> values)
        {
            this.Name = name;
            this.Points = points;
            this.Values = values;
            SetLoadType();
            SetDefaultValues();
            CheckValuesValidity();
        }


        //Enum
        public enum Type : ushort
        {
            NONE = 0,
            POINT = 1,
            LINE = 2,
            AREA = 3
        }

        //Properties
        public string Name { get; set; }
        public Type LoadType { get; set; }
        public List<Point3d> Points { get; set; }
        public List<double> Values { get; set; }

        //PublicMethods
        public override string ToString()
        {
            string line = "*PNLOADTYPE\n";
            line += "NAME=" + Name + "," + LoadType.ToString() + ",\n";
            line += "DATA = NO, NO";
            for(int i=0;i<Points.Count;i++)
            {
                Point3d point = Points[i];
                double value = Values[i];
                line +=","+ point.X + "," + point.Y + "," + Values[i];
            }
            return line;
        }
        //PrivateMathod
        private void SetLoadType()
        {
            if (Values.Count > Points.Count)
            {
                LoadType = Type.NONE;
            }
            else
            {
                switch (this.Points.Count)
                {
                    case 1:
                        LoadType = Type.POINT;
                        break;
                    case 2:
                        LoadType = Type.LINE;
                        break;
                    case 4:
                        LoadType = Type.AREA;
                        break;
                    default:
                        LoadType = Type.NONE;
                        break;
                }
            }
        }

        private void SetDefaultValues()
        {
            if(LoadType == Type.LINE)
            {
                if(Values.Count==1)
                {
                    Values.Add(Values[0]);
                }
            }
            else if(LoadType == Type.AREA)
            {
                if(Values.Count==1)
                {
                    Values.Add(Values[0]);
                    Values.Add(Values[0]);
                    Values.Add(Values[0]);
                }
            }
        }

        private void CheckValuesValidity()
        {
            switch (LoadType)
            {
                case Type.POINT:
                    if(Values.Count!=1)
                    {
                        LoadType = Type.NONE;
                        break;
                    }
                    break;
                case Type.LINE:
                    if (Values.Count != 2)
                    {
                        LoadType = Type.NONE;
                        break;
                    }
                    break;
                case Type.AREA:
                    if (Values.Count != 4)
                    {
                        LoadType = Type.NONE;
                        break;
                    }
                    break;
            }
        }
    }
}
