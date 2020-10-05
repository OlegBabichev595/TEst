using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lab5.Shapes
{
    public class Star : IDrawStar
    {
        public Star(Color colorLine, int width)
        {
            ColorLine = colorLine;
            Width = width;
        }

        public int Width { get; set; }
        public Color ColorLine { get; set; }

        public List<PointF> ReturnPts(int x, int y, Rectangle bounds)
        {
            var pts = new List<PointF>(IDrawStar.NumberOfPoints);

            var rx = bounds.Width / 15;
            var ry = bounds.Height / 15;
            var cx = bounds.X + x;
            var cy = bounds.Y + y;

            var theta = -Math.PI / 2;
            var dtheta = 4 * Math.PI / IDrawStar.NumberOfPoints;
            var i = 0;
            for (; i < IDrawStar.NumberOfPoints; i++)
            {
                pts.Add(new PointF(
                    (float) (cx + rx * Math.Cos(theta)),
                    (float) (cy + ry * Math.Sin(theta))));
                theta += dtheta;
            }
            Points = new List<PointF>(pts);
            return Points;
        }

        public List<PointF> Points { get; set; }
    }
}