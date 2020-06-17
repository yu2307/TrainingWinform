﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();

             Pen pen = new Pen(Color.DeepPink);
             pen.Width = 5.0f;
            //pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            // Point startPoint = new Point(45, 45);
            //Point endPoint = new Point(180, 150);
            // g.DrawLine(pen, startPoint, endPoint);
            // g.DrawLine(pen, 190, 60, 65, 170);

            //Rectangle rect = new Rectangle(50, 50, 150, 100);
            Rectangle[] rects = new Rectangle[]
            {
                new Rectangle(40,40,40,100),
                new Rectangle(100,40,100,40),
                new Rectangle(100,100,100,40)

            };
            g.FillRectangles(Brushes.BlueViolet, rects);
            g.DrawRectangles(pen, rects);

            Point[] pts =
            {
                    new Point(115, 30), new Point(140, 90),
                    new Point(200, 115), new Point(140, 140),
                    new Point(115, 200), new Point(90, 140),
                    new Point(30, 115), new Point(90, 90)
            };

            g.FillClosedCurve(Brushes.Yellow, pts);
            g.DrawClosedCurve(Pens.Red, pts);

        }
    }
}
