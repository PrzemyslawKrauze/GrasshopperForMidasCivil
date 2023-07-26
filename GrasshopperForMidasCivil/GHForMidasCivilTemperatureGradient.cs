using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GrasshopperForMidasCivil
{
    public class GHForMidasCivilTemperatureGradient : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GrasshopperForMidasCivilTemperatureGradient class.
        /// </summary>
        public GHForMidasCivilTemperatureGradient() : base("MidaCivilTemperatureGradient", "MCTG", "Description", "MidasCivil", "MidasCivil")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("LoadCaseName", "LCN", "Name of LoadCase", GH_ParamAccess.item);
            pManager.AddGenericParameter("Elements", "E", "Elements", GH_ParamAccess.list);
            pManager.AddNumberParameter("TemperatureGradient", "TG", "TemperatureGradient", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Output", "O", "Midas Civil input", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string lcName = string.Empty;
            List<Element> elements = new List<Element>();
            double tempGradient = 0;
            DA.GetData(0, ref lcName);
            DA.GetDataList(1, elements);
            DA.GetData(2, ref tempGradient);

            string output = "*USE-STLD," + lcName + "\n";
            output += "*THERGRAD\n";
            foreach (Element e in elements)
            {
                output += e.ID + ",2," + tempGradient + ",YES,0,\n";
            }

            DA.SetData(0, output);
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
            get { return new Guid("B3996DDD-AE52-4F3C-A565-5A6FBA573A26"); }
        }
    }
}