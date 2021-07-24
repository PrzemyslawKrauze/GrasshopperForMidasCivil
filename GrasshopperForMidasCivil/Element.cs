using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GrasshopperForMidasCivil
{
    public class Element
    {      
        public static string ListToString(List<Element> elementList)
        {
            string line = "*ELEMENT\n";
            foreach (Element el in elementList)
            {
                line += el.ToString();
                line += "\n";
            }
            return line;
        }
        public static void ResetID()
        {
            nextID = 0;
        }
        public static void SetID(int prefix)
        {
            nextID = prefix;
        }

        // *ELEMENT    ; Elements
        // iEL, TYPE, iMAT, iPRO, iN1, iN2, ANGLE, iSUB,                     ; Frame Element
        // iEL, TYPE, iMAT, iPRO, iN1, iN2, iN3, iN4, iSUB, iWID , LCAXIS    ; Planar Element

        public int ID { get; protected set; }
        public SubType Type { get { return subType; } }
        public Node iN1;//1st node ID
        public Node iN2; //2nd node ID
        public enum SubType
        {
            PLATE,
            BEAM
        }

        protected static int nextID;
        protected int iMAT; //material ID
        protected int iPRO; //section.thickness ID
        protected int iSUB; //sub type N/A for beams, 1 for thick plates
        protected int iWID = 0;
        protected SubType subType;
    }
    public class Beam:Element
    {
        public Beam(int materialID, int sectionID, Node iN1, Node iN2)
        {
            this.ID = Interlocked.Increment(ref nextID);
            this.subType = Element.SubType.BEAM;
            this.iMAT = materialID;
            this.iPRO = sectionID;
            this.iN1 = iN1;
            this.iN2 = iN2;

            iSUB = 0;
        }

        public override string ToString()
        {
            string line = this.ID + "," + this.Type + "," + this.iMAT + "," + this.iPRO + "," + this.iN1.ID + "," + this.iN2.ID + "," + this.angle + "," + this.iSUB;
            return line;
        }

        double angle = 0;
    }
    public class Plate : Element
    {
        public Plate(int materialID, int thicknessID, Node iN1, Node iN2, Node iN3, Node iN4)
        {
            this.ID = Interlocked.Increment(ref nextID);
            this.subType = Element.SubType.PLATE;
            this.iMAT = materialID;
            this.iPRO = thicknessID;
            this.iN1 = iN1;
            this.iN2 = iN2;
            this.iN3 = iN3;
            this.iN4 = iN4;

            this.iSUB = 1;
        }
        public Plate(int materialID, int thicknessID, Node iN1, Node iN2, Node iN3)
        {
            this.ID = Interlocked.Increment(ref nextID);
            this.subType = Element.SubType.PLATE;
            this.iMAT = materialID;
            this.iPRO = thicknessID;
            this.iN1 = iN1;
            this.iN2 = iN2;
            this.iN3 = iN3;

            this.iSUB = 1;
        }

        public override string ToString()
        {
            string line = this.ID + "," + this.Type + "," + this.iMAT + "," + this.iPRO + "," + this.iN1.ID + "," + this.iN2.ID + "," + this.iN3.ID + ",";
            if (this.iN4 == null)
            {
                line += "0," + this.iSUB + "," + this.iWID;
            }
            else
            {
                line += this.iN4.ID + "," + this.iSUB + "," + this.iWID;
            }
            return line;
        }

        #region PrivateFields
        Node iN3;
        Node iN4;
        #endregion
    }
}
