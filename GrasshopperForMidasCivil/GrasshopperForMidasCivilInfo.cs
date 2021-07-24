using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace GrasshopperForMidasCivil
{
    public class GrasshopperForMidasCivilInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "GrasshopperForMidasCivil";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("fde150ff-63fe-4a43-8f9e-20f9932c7d9c");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "Przemyslaw Krauze";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "krauze.przemyslaw@gmail.com";
            }
        }
    }
}
