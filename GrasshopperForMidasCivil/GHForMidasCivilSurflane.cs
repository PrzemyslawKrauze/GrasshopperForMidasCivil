using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GrasshopperForMidasCivil
{
    public class GHForMidasCivilSurflane : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public GHForMidasCivilSurflane() : base("MidasCivilSurflane", "MCSL", "Description", "MidasCivil", "MidasCivil")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Name", "N", "Name of lane", GH_ParamAccess.item);
            pManager.AddNumberParameter("Width", "W", "Wdith", GH_ParamAccess.item);
            pManager.AddNumberParameter("Offset", "O", "Offset", GH_ParamAccess.item);
            pManager.AddGenericParameter("StartNode", "SN", "StartNode", GH_ParamAccess.item);
            pManager.AddGenericParameter("EndNode", "EN", "EndNode", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Output","O","Midas Civil input",GH_ParamAccess.item);
            pManager.AddGenericParameter("Surflane", "S", "Surflane", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string name = string.Empty;
            double width = 3;
            double offset = 0;
            Node startNode = new Node();
            Node endNode = new Node();
            DA.GetData(0, ref name);
            DA.GetData(1, ref width);
            DA.GetData(2, ref offset);
            DA.GetData(3, ref startNode);
            DA.GetData(4, ref endNode);

            Surflane surflane = new Surflane(name,width,offset,startNode,endNode);
            DA.SetData(0, surflane.ToString());
            DA.SetData(1, surflane);
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
            get { return new Guid("23C3754F-C22B-4909-BAAE-932A628AD5A6"); }
        }
    }
}