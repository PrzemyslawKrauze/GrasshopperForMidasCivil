using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace GrasshopperForMidasCivil
{
    public static class Solver
    {
        public static void ConvertPoints(List<Point3d> pointList, ref List<Node> nodeList)
        {
            List<Node> convertedPoints = new List<Node>();
            foreach (Point3d p in pointList)
            {
                convertedPoints.Add(new Node(p));
            }
            nodeList.AddRange(convertedPoints);
        }
        public static void ConvertCurves(List<Curve> curves, ref List<Node> nodeList, ref List<Element> elementList)
        {
            List<Node> curveNodes = new List<Node>();
            List<Element> beamList = new List<Element>();

            for (int i = 0; i < curves.Count; i++)
            {
                Curve curve = curves[i];

                Point3d startPoint = curve.PointAtStart;
                Node startNode = new Node(startPoint);
                curveNodes.Add(startNode);

                Point3d endPoint = curve.PointAtEnd;
                Node endNode = new Node(endPoint);
                curveNodes.Add(endNode);

                Beam beam = new Beam(1, 1, startNode, endNode);
                beamList.Add(beam);
            }
            nodeList.AddRange(curveNodes);
          
            elementList.AddRange(beamList);
        }

        public static void ConvertMesh(Mesh mesh, ref List<Node> nodeList, ref List<Element> elementList)
        {
            List<Node> meshNodes = new List<Node>();
            List<Element> plateList = new List<Element>();

            List<MeshFace> meshFaces = mesh.Faces.ToList();

            var mvertexList = mesh.Vertices;
            List<Point3d> vertexPoints = mvertexList.ToPoint3dArray().ToList();
            foreach (Point3d point in vertexPoints)
            {
                Node node = new Node(point);
                meshNodes.Add(node);
            }

            foreach (MeshFace f in meshFaces)
            {
                Plate plate;
                if (f.IsQuad)
                {
                    plate = new Plate(1, 1, meshNodes[f.A], meshNodes[f.B], meshNodes[f.C], meshNodes[f.D]);
                }
                else
                {
                    plate = new Plate(1, 1, meshNodes[f.A], meshNodes[f.B], meshNodes[f.C]);
                }
                plateList.Add(plate);
            }
            nodeList.AddRange(meshNodes);
            elementList.AddRange(plateList);
        }

        public static void ConvertMeshes(List<Mesh> mesh, ref List<Node> nodeList, ref List<Element> elementList)
        {
            foreach (Mesh m in mesh)
            {
                ConvertMesh(m, ref nodeList, ref elementList);
            }
        }

    }
}
