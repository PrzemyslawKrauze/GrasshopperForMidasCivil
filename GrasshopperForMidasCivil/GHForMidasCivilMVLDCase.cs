using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;
using GrasshopperForMidasCivil.MidasCivilClasses;
using Rhino.Geometry;

namespace GrasshopperForMidasCivil
{
    public class GHForMidasCivilMVLDCase : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public GHForMidasCivilMVLDCase() : base("MidasCivilMVLDCase", "MCMVLDC", "Description", "MidasCivil", "MidasCivil")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Name", "N", "Name of lane", GH_ParamAccess.item);
            pManager.AddBooleanParameter("IgnorePsi", "IP", "IgnorePsi", GH_ParamAccess.item);
            pManager.AddGenericParameter("Surflanes", "S", "Surflanes", GH_ParamAccess.list);
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
            string name = string.Empty;
            bool ingorePsi = false;
            List<Surflane> surflanes = new List<Surflane>();
            DA.GetData(0, ref name);
            DA.GetData(1, ref ingorePsi);
            DA.GetDataList(2, surflanes);

            MVLDCase mVLDCase = new MVLDCase(name, ingorePsi, surflanes);

            DA.SetData(0, mVLDCase.ToString());
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
            get { return new Guid("F7C09333-462A-4CAA-80C2-2CED77836935"); }
        }
    }
}