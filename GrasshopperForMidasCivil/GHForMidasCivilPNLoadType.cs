using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

namespace GrasshopperForMidasCivil
{
    public class GHForMidasCivilPNLoadType : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GrasshopperForMidasCivilPNLoadType class.
        /// </summary>
        public GHForMidasCivilPNLoadType(): base("MidasCivilPNLoadType", "MCPNLT", "Description", "MidasCivil", "MidasCivil")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Name", "N", "Name of PNLoadType", GH_ParamAccess.item);
            pManager.AddPointParameter("Points", "P", "List of points", GH_ParamAccess.list);
            pManager.AddNumberParameter("Values","V","List of load's values",GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("PNLoadType", "PNLT", "PNLoadType", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string name = string.Empty;
            List<Point3d> points = new List<Point3d>();
            List<double> values = new List<double>();
            DA.GetData(0, ref name);
            DA.GetDataList(1, points);
            DA.GetDataList(2,  values);

            PNLoadType pnLoadType = new PNLoadType(name, points,values);

            DA.SetData(0, pnLoadType);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("F53006F0-007A-458F-B2C0-9F4C8DC70362"); }
        }
    }
}