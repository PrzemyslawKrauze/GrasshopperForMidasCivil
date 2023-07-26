using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Rhino.PlugIns;

namespace GrasshopperForMidasCivil
{
    public class GHForMidasCivilPlaneLoad : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GrasshopperForMidasCivilPlaneLoad class.
        /// </summary>
        public GHForMidasCivilPlaneLoad() : base("MidasCivilPlaneLoad", "MCPL", "Description", "MidasCivil", "MidasCivil")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("LoadCaseName", "LCN", "Name of LoadCase", GH_ParamAccess.item);
            pManager.AddGenericParameter("PNLoadType", "PNLT", "PNLoadType", GH_ParamAccess.item);
            pManager.AddPointParameter("OriginPoint", "OP", "Origin point", GH_ParamAccess.item);
            pManager.AddPointParameter("XAxisPoint", "XP", "XAxisPoint", GH_ParamAccess.item);
            pManager.AddPointParameter("YAxisPoint", "YP", "YAxisPoint", GH_ParamAccess.item);
            pManager.AddTextParameter("LoadDirection", "LD", "LoadDirection", GH_ParamAccess.item);

            pManager[5].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Output","O","Midas Civil input",GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string lcName = string.Empty;
            PNLoadType pnLoadType = new PNLoadType();
            Point3d originPoint = new Point3d();
            Point3d xAxisPoint = new Point3d();
            Point3d yAxisPoint = new Point3d();
            string loadDir = string.Empty;

            DA.GetData(0, ref lcName);
            DA.GetData(1, ref pnLoadType);
            DA.GetData(2, ref originPoint);
            DA.GetData(3, ref xAxisPoint);
            DA.GetData(4, ref yAxisPoint);
            DA.GetData(5, ref loadDir);

            PlaneLoad planeLoad;
            if (loadDir != string.Empty)
            {
                planeLoad = new PlaneLoad(lcName, pnLoadType, originPoint, xAxisPoint, yAxisPoint, loadDir);
            }
            else
            {
                 planeLoad = new PlaneLoad(lcName, pnLoadType, originPoint, xAxisPoint, yAxisPoint);
            }

            DA.SetData(0, planeLoad.ToString());
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
            get { return new Guid("EF7268B2-FE97-4E8C-ADC7-1DD307D033B5"); }
        }
    }
}