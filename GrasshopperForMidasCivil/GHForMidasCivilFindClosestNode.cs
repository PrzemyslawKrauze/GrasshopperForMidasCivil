using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GrasshopperForMidasCivil
{
    public class GHForMidasCivilFindClosestNode : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GrasshopperForMidasCivilFindClosestNode class.
        /// </summary>
        public GHForMidasCivilFindClosestNode():base("MidasCivilClosestNode", "MCCN", "Description", "MidasCivil", "MidasCivil")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Nodes", "N", "List of nodes", GH_ParamAccess.list);
            pManager.AddPointParameter("Point", "P", "Point to find", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Output", "O", "ClosestNode", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<Node> nodes = new List<Node>();
            Point3d point = new Point3d();
            DA.GetDataList(0, nodes);
            DA.GetData(1, ref point);

            Node closestNode = new Node();
            double smallestDistance = double.MaxValue;
            foreach(Node node in nodes)
            {
                double distance = node.XYZ.DistanceTo(point);
                if(distance < smallestDistance)
                {
                    smallestDistance = distance;
                    closestNode = node;
                }
            }

            DA.SetData(0, closestNode);
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
            get { return new Guid("560CA589-2526-4985-A7A6-CD65B62F8D79"); }
        }
    }
}