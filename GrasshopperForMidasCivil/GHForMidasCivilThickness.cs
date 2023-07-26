using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GrasshopperForMidasCivil
{
    public class GHForMidasCivilThickness : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the Thickness class.
        /// </summary>
        public GHForMidasCivilThickness() : base("MidasCivilThickness", "MCC", "Description", "MidasCivil", "MidasCivil")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("ID", "ID", "Thickness Id", GH_ParamAccess.item);
            pManager.AddNumberParameter("Value", "V", "Thickness vlaue", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("MCT Command List", "MCT", "Midas input file", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            int id = 0;
            double value = 0;

            bool runSolver = false;
            if (DA.GetData(0, ref id) && (DA.GetData(1,ref value)))
            {
                runSolver = true;
            }

            if (!runSolver) { return; }

            Thickness thickness = new Thickness(id, value);

            string output = thickness.ToString();
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
            get { return new Guid("0C94AE80-EFE8-424D-892A-56D7E6FDCA7E"); }
        }
    }
}