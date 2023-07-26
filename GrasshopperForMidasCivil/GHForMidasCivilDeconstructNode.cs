using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GrasshopperForMidasCivil
{
    public class GHForMidasCivilDeconstructNode : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GHForMidasCivilDeconstructNode class.
        /// </summary>
        public GHForMidasCivilDeconstructNode():base("MidasCivilDeconstructNode", "MCDC", "Description", "MidasCivil", "MidasCivil")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Node", "N", "Node", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("ID","ID","ID",GH_ParamAccess.item);
            pManager.AddPointParameter("Point", "P", "Point", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Node node = new Node();
            DA.GetData(0, ref node);

            DA.SetData(0, node.ID);
            DA.SetData(1, node.XYZ);
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
            get { return new Guid("116E9283-6CE3-4829-AEEE-6F7CE8883A41"); }
        }
    }
}