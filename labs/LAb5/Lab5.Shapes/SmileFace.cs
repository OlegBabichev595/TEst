using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lab5.Shapes
{
    public class SmileFace:IDrawSmileFace
    {
        

        public PointF FirstEyePoint { get; set; }
        public PointF SecondEyePoint { get; set; }
        public PointF SmilePoint { get; set; }
        public PointF FacePoint { get; set; }
        public (PointF, PointF, PointF, PointF) ReturnPoints(int locationMouseX,int locationMouseY)
        {
            FirstEyePoint = new PointF(locationMouseX - 25, locationMouseY - 25);
            SecondEyePoint = new PointF(locationMouseX + 25, locationMouseY - 25);
            SmilePoint = new PointF(locationMouseX -50, locationMouseY - 70);
            FacePoint = new PointF(locationMouseX - 50, locationMouseY - 50);
            return (FirstEyePoint, SecondEyePoint, SmilePoint, FacePoint);

        }

        

        public int Width { get; set; }
        public Color ColorLine { get; set; }
    }
}
