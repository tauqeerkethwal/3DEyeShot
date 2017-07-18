using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChairNtable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // viewportLayout1.Unlock("");
        }


        protected override void OnLoad(EventArgs e)
        {

            CreateChair();
            CreateTable();

            Mesh cylender = Mesh.CreateSphere(10, 10, 200);
            cylender.Translate(0, -30, 70);
            viewportLayout1.Entities.AddRange(new Entity[] { cylender }, 0, Color.Brown);

            base.OnLoad(e);
        }
        private void CreateBoxNTranslate(double boxW, double boxD, double boxH, double transDx, double transDy, double transDz)
        {

            Mesh leg = Mesh.CreateBox(boxW, boxD, boxH);
            leg.Translate(transDx, transDy, transDz);
            viewportLayout1.Entities.AddRange(new Entity[] { leg }, 0, Color.Brown);
        }
        private void CreateTable()
        {
            CreateBoxNTranslate(10, 10, 50, -80, -80, 0);//front right leg table
            CreateBoxNTranslate(10, 10, 50, 70, -80, 0);//front left leg table

            CreateBoxNTranslate(10, 10, 50, -80, 0, 0); //back right leg table
            CreateBoxNTranslate(10, 10, 50, 70, 0, 0); //back left leg table






            string TableslabName = "Tableslab";
            Block b = new Block();

            double width = 70;
            double depth = 5;
            double dimA = 1000;
            double dimB = 800;
            Point2D[] outerPoints = new Point2D[7];

            outerPoints[0] = new Point2D(0, dimB);
            outerPoints[1] = new Point2D(dimA, dimB);
            outerPoints[2] = new Point2D(dimA, 0);
            outerPoints[3] = new Point2D(width, 0);
            outerPoints[4] = new Point2D(width, depth);
            outerPoints[5] = new Point2D(0, depth);
            outerPoints[6] = (Point2D)
                outerPoints[0].Clone();

            LinearPath outer = new LinearPath(Plane.XY, outerPoints);

            Point2D[] innerPoints = new Point2D[5];

            innerPoints[0] = new Point2D(-80, -80);
            innerPoints[1] = new Point2D(80, -80);
            innerPoints[2] = new Point2D(80, 10);
            innerPoints[3] = new Point2D(-80, 10);
            innerPoints[4] = (Point2D)innerPoints[0].Clone();

            LinearPath inner = new LinearPath(Plane.XY, innerPoints);

            devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region(outer, inner);

            Mesh m2 = reg.ExtrudeAsMesh(10, 0.1, Mesh.natureType.Plain);

            m2.ColorMethod = colorMethodType.byEntity;
            m2.Color = Color.White;
            m2.MaterialName = TableslabName;

            b.Entities.Add(m2);

            viewportLayout1.Blocks.Add("tfloor", b);


            BlockReference reference = new BlockReference(0, 0, 60, "tfloor", 1, 1, 1, 0);

            viewportLayout1.Entities.Add(reference, 0);

        }
        private void CreateChair()
        {


            CreateBoxNTranslate(10, 10, 50, -30, 40, 0);//front right leg chair
            CreateBoxNTranslate(10, 10, 50, 20, 40, 0); //front left leg chair

            CreateBoxNTranslate(10, 10, 120, -30, 90, 0);//back right leg chair
            CreateBoxNTranslate(10, 10, 120, 20, 90, 0); //back left leg chair

            CreateBoxNTranslate(70, 5, 20, -35, 90, 120); // chair top 



            string ChairTopSlabName = "ChairTopSlab";
            Block b = new Block();

            double width = 70;
            double depth = 5;
            double dimA = 1000;
            double dimB = 800;
            Point2D[] outerPoints = new Point2D[7];

            outerPoints[0] = new Point2D(0, dimB);
            outerPoints[1] = new Point2D(dimA, dimB);
            outerPoints[2] = new Point2D(dimA, 0);
            outerPoints[3] = new Point2D(width, 0);
            outerPoints[4] = new Point2D(width, depth);
            outerPoints[5] = new Point2D(0, depth);
            outerPoints[6] = (Point2D)
                outerPoints[0].Clone();

            LinearPath outer = new LinearPath(Plane.XY, outerPoints);

            Point2D[] innerPoints = new Point2D[5];

            innerPoints[0] = new Point2D(-30, 0);
            innerPoints[1] = new Point2D(-30, 60);
            innerPoints[2] = new Point2D(30, 60);
            innerPoints[3] = new Point2D(30, 0);
            innerPoints[4] = (Point2D)innerPoints[0].Clone();

            LinearPath inner = new LinearPath(Plane.XY, innerPoints);

            devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region(outer, inner);

            Mesh m2 = reg.ExtrudeAsMesh(10, 0.1, Mesh.natureType.Plain);

            m2.ColorMethod = colorMethodType.byEntity;
            m2.Color = Color.White;
            m2.MaterialName = ChairTopSlabName;

            b.Entities.Add(m2);

            viewportLayout1.Blocks.Add("ChairTopSlab", b);


            BlockReference reference = new BlockReference(0, 40, 60, "ChairTopSlab", 1, 1, 1, 0);

            viewportLayout1.Entities.Add(reference, 0);
        }
    }

}
