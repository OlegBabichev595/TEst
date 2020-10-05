using System.Drawing;

namespace Lab5.Shapes
{
    public interface IDrawSmileFace:IShape
    {
        public const int FaceSizeWidth = 100;
        public const int EyeSizeWidth = 10;
        public const int SmileDegree = 45;
        public const int SmileDegreeSecond = 90;
        public PointF FirstEyePoint { get; set; }
        public PointF SecondEyePoint { get; set; }
        public PointF SmilePoint { get; set; }
        public PointF FacePoint { get; set; }


        public (PointF, PointF, PointF, PointF) ReturnPoints(int locationMouseX, int locationMouseY);

    }
}