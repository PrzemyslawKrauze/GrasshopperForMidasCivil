using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GrasshopperForMidasCivil
{
    public class GHForMidasCivilConstraint : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GHForMidasCivilConstraint class.
        /// </summary>
        public GHForMidasCivilConstraint()
          : base("GHForMidasCivilConstraint", "MCC",
              "Description",
              "Category", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Node", "N", "Node", GH_ParamAccess.item);
            pManager.AddTextParameter("Constrains", "C", "Constrains", GH_ParamAccess.item);
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
            Node node = new Node();
            string constrains = string.Empty;
            DA.GetData(0, ref node);
            DA.GetData(1, ref constrains);

            Constraint constraint = new Constraint(node, constrains);
            DA.SetData(0, constraint.ToString());
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
            get { return new Guid("97EAA041-5358-4C61-B38A-224B7D725DCE"); }
        }
    }
}