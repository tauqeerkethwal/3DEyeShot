using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using System;
using System.Collections.Generic;
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
            
            Mesh shortleg1 = Mesh.CreateBox(10, 10, 50);
            shortleg1.Translate(-30, 40, 0);
            Mesh shortleg2 = (Mesh)shortleg1.Clone();
            shortleg2.Translate(50, 0, 0);

            Mesh leg1 = Mesh.CreateBox(10, 10, 120);
            leg1.Translate(-30, 90, 0);
            Mesh leg2 = (Mesh)leg1.Clone();
            leg2.Translate(50, 0, 0);

            Mesh cylender = Mesh.CreateSphere(10, 10, 200);
            cylender.Translate(0, -30, 70);
            viewportLayout1.Entities.AddRange(new Entity[] { shortleg1, shortleg2, leg1, leg2, cylender }, 0, Color.Brown);
            shortleg1 = Mesh.CreateBox(10, 10, 50);
            shortleg1.Translate(-80, -80, 0);
            shortleg2 = (Mesh)shortleg1.Clone();
            shortleg2.Translate(150, 0, 0);
                
            viewportLayout1.Entities.AddRange(new Entity[] { shortleg1, shortleg2 }, 0, Color.Brown);
            shortleg1 = Mesh.CreateBox(10, 10, 50);
            shortleg1.Translate(-80, 0, 0);
            shortleg2 = (Mesh)shortleg1.Clone();
            shortleg2.Translate(150, 0, 0);


            viewportLayout1.Entities.AddRange(new Entity[] { shortleg1, shortleg2 }, 0, Color.Brown);

            Mesh seatBack = Mesh.CreateBox(70, 5, 20);
            seatBack.Translate(-35, 90, 120);
            viewportLayout1.Entities.Add(seatBack, 0, Color.Brown);

            string concreteMatName = "Concrete";
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
            m2.MaterialName = concreteMatName;

            b.Entities.Add(m2);

            viewportLayout1.Blocks.Add("floor", b);
            for (int i = 0; i < 1; i++)
            {

                BlockReference reference = new BlockReference(0, 40, 60 , "floor", 1, 1, 1, 0);

                viewportLayout1.Entities.Add(reference, 0);

            }


            ///////////////
             concreteMatName = "Tableslab";
             b = new Block();

             width = 70;
             depth = 5;
             dimA = 1000;
             dimB = 800;
             outerPoints = new Point2D[7];

            outerPoints[0] = new Point2D(0, dimB);
            outerPoints[1] = new Point2D(dimA, dimB);
            outerPoints[2] = new Point2D(dimA, 0);
            outerPoints[3] = new Point2D(width, 0);
            outerPoints[4] = new Point2D(width, depth);
            outerPoints[5] = new Point2D(0, depth);
            outerPoints[6] = (Point2D)
                outerPoints[0].Clone();

             outer = new LinearPath(Plane.XY, outerPoints);

             innerPoints = new Point2D[5];

            innerPoints[0] = new Point2D(-80, -80);
            innerPoints[1] = new Point2D(80, -80);
            innerPoints[2] = new Point2D(80, 10);
            innerPoints[3] = new Point2D(-80, 10);
            innerPoints[4] = (Point2D)innerPoints[0].Clone();

             inner = new LinearPath(Plane.XY, innerPoints);

             reg = new devDept.Eyeshot.Entities.Region(outer, inner);

             m2 = reg.ExtrudeAsMesh(10, 0.1, Mesh.natureType.Plain);

            m2.ColorMethod = colorMethodType.byEntity;
            m2.Color = Color.White;
            m2.MaterialName = concreteMatName;

            b.Entities.Add(m2);

            viewportLayout1.Blocks.Add("tfloor", b);
            for (int i = 0; i < 1; i++)
            {

                BlockReference reference = new BlockReference(0, 0, 60, "tfloor", 1, 1, 1, 0);
                
                viewportLayout1.Entities.Add(reference, 0);

            }
            ///////////////

            
            viewportLayout1.ZoomFit();
            //base.OnLoad(e);
        }
    }
  
}
