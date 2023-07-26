using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using GrasshopperForMidasCivil.MidasCivilClasses;

namespace GrasshopperForMidasCivil
{
    public class GHForMidasCivilGroup : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public GHForMidasCivilGroup()
          : base("GHForMidasCivilGroup", "MCG","Description", "MidasCivil", "MidasCivil")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("GroupName", "N", "Group name", GH_ParamAccess.item);
            pManager.AddGenericParameter("Nodes", "N", "Nodes", GH_ParamAccess.list);
            pManager.AddGenericParameter("Elements", "E", "Elements", GH_ParamAccess.list);
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
            DA.GetData(0, ref name);
            List<Node> nodes = new List<Node>();
            List<Element> elements = new List<Element>();
            DA.GetDataList(1, nodes);
            DA.GetDataList(2, elements);

            Group group = new Group(name, nodes, elements);

            DA.SetData(0, group.ToString());
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
            get { return new Guid("4FA5DBDC-5A17-4526-949F-6B1A2FA215AA"); }
        }
    }
}