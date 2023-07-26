using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GrasshopperForMidasCivil
{
    public class GHForMidasCivilElasticLink : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GHForMidasCivilElasticLink class.
        /// </summary>
        public GHForMidasCivilElasticLink()
          : base("GHForMidasCivilElasticLink", "MCEL",
              "Description",
              "Category", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("StartNode", "SN", "StartNode", GH_ParamAccess.item);
            pManager.AddGenericParameter("EndNode", "EN", "EndNode", GH_ParamAccess.item);
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
            Node startNode = new Node();
            Node endNode = new Node();
            DA.GetData(0, ref startNode);
            DA.GetData(1, ref endNode);

            ElasticLink elasticLink = new ElasticLink(startNode, endNode);

            DA.SetData(0, elasticLink.ToString());
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
            get { return new Guid("3277C67C-03B4-41B0-9A86-EA1E44B980A7"); }
        }
    }
}