using System.Collections.Generic;
using System.Drawing;

namespace Lab5.Shapes
{
    public interface IDrawStar:IShape
    {
        public const int NumberOfPoints = 5;
        public List<PointF> Points { get; set; }
        List<PointF> ReturnPts(int x,int y, Rectangle bounds);
    }
}