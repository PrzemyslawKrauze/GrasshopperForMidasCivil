using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;

// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace GrasshopperForMidasCivil
{
    public class GrasshopperForMidasCivilComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public GrasshopperForMidasCivilComponent() : base("MidasCivilConverter", "MCC", "Description", "Category", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("NodePrefix", "NP", "Prefix for node numbers", GH_ParamAccess.item,0);
            pManager.AddIntegerParameter("ElementPrefix", "EP", "Prefix for node numbers", GH_ParamAccess.item,0);
            pManager.AddPointParameter("Points", "P", "Points to be converted to nodes", GH_ParamAccess.list);
            pManager.AddCurveParameter("Curves", "C", "Lines elements to be converted to beams", GH_ParamAccess.list);
            pManager.AddMeshParameter("Mesh", "M", "Mesh to be converted to plate elements", GH_ParamAccess.list);

            pManager[0].Optional = true;
            pManager[1].Optional = true;
            pManager[2].Optional = true;
            pManager[3].Optional = true;
            pManager[4].Optional = true;
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
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            bool runSolver = false;
            int nodePrefix = 0;
            int elementPrefix = 0;
            List<Point3d> points = new List<Point3d>();
            List<Curve> curves = new List<Curve>();
            List<Mesh> meshes = new List<Mesh>();
            Node.ResetID();
            Element.ResetID();
            int a = 0;

            //As all inputs are optional at least one valid geometry input is required to run solver
            bool runSolver = false;
            if (DA.GetData(0, ref nodePrefix))
            {
                Node.SetIDPrefix(nodePrefix);
            }
            if (DA.GetData(1, ref elementPrefix))
            {
                Element.SetID(elementPrefix);
            }
            if (DA.GetDataList(2, points))
            {
                runSolver = true;
            }
            if (DA.GetDataList(3,  curves))
            {
                runSolver = true;
            }
            if(DA.GetDataList(4, meshes))
            {
                runSolver = true;
            }

            if (!runSolver) { return; }

            //Convert Rhino geometry to Node and Element classes
            List<Node> nodeList = new List<Node>();
            List<Element> elementList = new List<Element>();

            Solver.ConvertPoints(points, ref nodeList);
            Solver.ConvertCurves(curves, ref nodeList, ref elementList);
            Solver.ConvertMeshes(meshes, ref nodeList, ref elementList);

            //Delete duplicated nodes
            //Group nodes by its coordinates
            var groupedNodes = (from n in nodeList
                                group n by new { n.X, n.Y, n.Z }).ToList();
            foreach (var group in groupedNodes)
            {
                if (group.Count() > 0)
                {
                    List<Node> groupAsList = group.ToList();
                    for (int i = 1; i < group.Count(); i++)
                    {
                        groupAsList[i].ID = groupAsList[0].ID;
                    }
                }
            }
            nodeList = (from g in groupedNodes
                        select g.First()).ToList();
            nodeList = (from n in nodeList
                        orderby n.ID
                        select n).ToList();

            //Write Node and Elements classes to MidasCivil Command shell
            string nodeText = Node.ListToString(nodeList);
            string elementText = Element.ListToString(elementList);
            string output = nodeText + "\n" + elementText;

            DA.SetData(0, output);

        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("32f8d170-291c-42f5-977c-4b1878b0e2f6"); }
        }
    }
}
