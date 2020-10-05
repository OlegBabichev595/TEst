using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Lab5.Shapes;

namespace LAb5
{
    public partial class Form1 : Form
    {
        private readonly Graphics g;
        private List<IShape> shapes;

        public Form1()
        {
            InitializeComponent();

            pictureBox1.MouseClick += PictureBox1_MouseClick;
            g = pictureBox1.CreateGraphics();
            shapes = new List<IShape>();
            Star.Checked = true;
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            DrawStar(e);
            DrawSmileFace(e);
        }

        public void DrawStar(MouseEventArgs e)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            IDrawStar star = new Star(Color.Blue, 4);

            var pts = star.ReturnPts(e.Location.X, e.Location.Y, ClientRectangle);
            foreach (var point in pts)
            {
                if (!(point.X > pictureBox1.Width) && !(point.X < 0) && !(point.Y > pictureBox1.Height) &&
                    !(point.Y < 0)) continue;
                MessageBox.Show("Error, Click in another place");
                return;
            }

            g.DrawPolygon(Pens.Blue, pts.ToArray());
            shapes.Add(star);
        }

        public void DrawSmileFace(MouseEventArgs e)
        {
            IDrawSmileFace s = new SmileFace();
            var points = s.ReturnPoints(e.Location.X, e.Location.Y);

            if (points.Item4.X + IDrawSmileFace.FaceSizeWidth > pictureBox1.Width || points.Item4.X < 0 ||
                points.Item4.Y > pictureBox1.Height ||
                points.Item4.Y < 0)
            {
                MessageBox.Show("Error, Click in another place");
                return;
            }

            var so = new SolidBrush(Color.Black);

            g.DrawEllipse(Pens.Blue, points.Item4.X, points.Item4.Y, IDrawSmileFace.FaceSizeWidth, IDrawSmileFace.FaceSizeWidth);
            g.FillEllipse(so, points.Item1.X, points.Item1.Y, IDrawSmileFace.EyeSizeWidth, IDrawSmileFace.EyeSizeWidth);
            g.FillEllipse(so, points.Item2.X, points.Item2.Y, IDrawSmileFace.EyeSizeWidth, IDrawSmileFace.EyeSizeWidth);
            g.DrawArc(Pens.Blue, points.Item3.X, points.Item3.Y, IDrawSmileFace.FaceSizeWidth, IDrawSmileFace.FaceSizeWidth,
                IDrawSmileFace.SmileDegree, IDrawSmileFace.SmileDegreeSecond);
            shapes.Add(s);
        }


        private bool CheckCoordinatesDrawWindowForStar(IDrawStar star,int delta)
        {
            foreach (var point in star.Points)
            {
                if (!(point.X + delta > pictureBox1.Width) && !(point.X < 0) && !(point.Y > pictureBox1.Height) &&
                    !(point.Y < 0)) continue;

                return false;
            }

            return true;
        }

        private bool CheckCoordinatesDrawWindowForSmileFace(IDrawSmileFace smileFace,int delta)
        {
            return !(smileFace.FacePoint.X + IDrawSmileFace.FaceSizeWidth + delta > pictureBox1.Width) && !(smileFace.FacePoint.X < 0) && !(smileFace.FacePoint.Y+ IDrawSmileFace.FaceSizeWidth> pictureBox1.Height) && !(smileFace.FacePoint.Y < 0);
        }




        private void button1_Click(object sender, EventArgs e)
        {
            if (Star.Checked)
            {
                shapes = new List<IShape>(shapes.Select(x => x).Where(x => x is IDrawSmileFace));

                ReDrawSmileFace(shapes);
            }
            else
            {
                shapes = new List<IShape>(shapes.Select(x => x).Where(x => x is IDrawStar));

                ReDrawStar(shapes);
            }
        }

        public void ReDrawSmileFace(IEnumerable<IShape> shapes)
        {
            g.Clear(pictureBox1.BackColor);
            var so = new SolidBrush(Color.Black);
            foreach (IDrawSmileFace shape in shapes)
            {
                g.DrawEllipse(Pens.Blue, shape.FacePoint.X, shape.FacePoint.Y, IDrawSmileFace.FaceSizeWidth,
                    IDrawSmileFace.FaceSizeWidth);
                g.FillEllipse(so, shape.FirstEyePoint.X, shape.FirstEyePoint.Y, IDrawSmileFace.EyeSizeWidth,
                    IDrawSmileFace.EyeSizeWidth);
                g.FillEllipse(so, shape.SecondEyePoint.X, shape.SecondEyePoint.Y, IDrawSmileFace.EyeSizeWidth,
                    IDrawSmileFace.EyeSizeWidth);
                g.DrawArc(Pens.Blue, shape.SmilePoint.X, shape.SmilePoint.Y, IDrawSmileFace.FaceSizeWidth,
                    IDrawSmileFace.FaceSizeWidth, IDrawSmileFace.SmileDegree, IDrawSmileFace.SmileDegreeSecond);
            }
        }

        public void ReDrawStar(List<IShape> shapes)
        {
            g.Clear(pictureBox1.BackColor);
            foreach (IDrawStar shape in shapes) g.DrawPolygon(Pens.Blue, shape.Points.ToArray());
        }

        public void DrawLeft(int delta, IEnumerable<IShape> shapes)
        {
            if (shapes == null)
            {
                return;
            }


            foreach (var shape in shapes)
                switch (shape)
                {
                    case IDrawStar star:

                        for (var i = 0; i < star.Points.Count; i++)
                        {
                            if (CheckCoordinatesDrawWindowForStar(star, delta))
                            {
                                star.Points[i] = new PointF(star.Points[i].X - delta, star.Points[i].Y);

                            }
                        }



                        break;
                    case IDrawSmileFace smile:
                        if (CheckCoordinatesDrawWindowForSmileFace(smile,-delta))
                        {
                            smile.SecondEyePoint = new PointF(smile.SecondEyePoint.X - delta, smile.SecondEyePoint.Y);
                            smile.FirstEyePoint = new PointF(smile.FirstEyePoint.X - delta, smile.FirstEyePoint.Y);
                            smile.FacePoint = new PointF(smile.FacePoint.X - delta, smile.FacePoint.Y);
                            smile.SmilePoint = new PointF(smile.SmilePoint.X - delta, smile.SmilePoint.Y);
                        }
                        break;
                }
        }

        public void DrawRight(int delta, IEnumerable<IShape> shapes)
        {
            if (shapes == null)
            {
                return;
            }

            foreach (var shape in shapes)
                switch (shape)
                {
                    case IDrawStar star:
                        for (var i = 0; i < star.Points.Count; i++)
                            if (CheckCoordinatesDrawWindowForStar(star, delta))
                            {
                                star.Points[i] = new PointF(star.Points[i].X + delta, star.Points[i].Y);
                            }
                           
                        break;
                    case IDrawSmileFace smile:
                        if (CheckCoordinatesDrawWindowForSmileFace(smile, -delta))
                        {
                            smile.SecondEyePoint = new PointF(smile.SecondEyePoint.X + delta, smile.SecondEyePoint.Y);
                            smile.FirstEyePoint = new PointF(smile.FirstEyePoint.X + delta, smile.FirstEyePoint.Y);
                            smile.FacePoint = new PointF(smile.FacePoint.X + delta, smile.FacePoint.Y);
                            smile.SmilePoint = new PointF(smile.SmilePoint.X + delta, smile.SmilePoint.Y);
                        }

                        break;
                }
        }


        public void DrawBottom(int delta, IEnumerable<IShape> shapes)
        {
            if (shapes == null)
            {
                return;
            }

            foreach (var shape in shapes)
                switch (shape)
                {
                    case IDrawStar star:
                        for (var i = 0; i < star.Points.Count; i++)
                            if (CheckCoordinatesDrawWindowForStar(star, delta))
                            {
                                star.Points[i] = new PointF(star.Points[i].X, star.Points[i].Y + delta);
                            }
                       
                        break;
                    case IDrawSmileFace smile:
                        if (CheckCoordinatesDrawWindowForSmileFace(smile, delta))
                        {
                            smile.SecondEyePoint = new PointF(smile.SecondEyePoint.X, smile.SecondEyePoint.Y + delta);
                            smile.FirstEyePoint = new PointF(smile.FirstEyePoint.X, smile.FirstEyePoint.Y + delta);
                            smile.FacePoint = new PointF(smile.FacePoint.X, smile.FacePoint.Y + delta);
                            smile.SmilePoint = new PointF(smile.SmilePoint.X, smile.SmilePoint.Y + delta);
                        }

                        break;
                }
        }

        public void DrawTop(int delta, IEnumerable<IShape> shapes)
        {
            if (shapes == null)
            {
                return;
            }

            foreach (var shape in shapes)
                switch (shape)
                {
                    case IDrawStar star:
                        for (var i = 0; i < star.Points.Count; i++)
                            if (CheckCoordinatesDrawWindowForStar(star, -delta))
                            {
                                star.Points[i] = new PointF(star.Points[i].X, star.Points[i].Y - delta);
                            }

                       
                        break;
                    case IDrawSmileFace smile:
                        if (CheckCoordinatesDrawWindowForSmileFace(smile, -delta))
                        {
                            smile.SecondEyePoint = new PointF(smile.SecondEyePoint.X, smile.SecondEyePoint.Y - delta);
                            smile.FirstEyePoint = new PointF(smile.FirstEyePoint.X, smile.FirstEyePoint.Y - delta);
                            smile.FacePoint = new PointF(smile.FacePoint.X, smile.FacePoint.Y - delta);
                            smile.SmilePoint = new PointF(smile.SmilePoint.X, smile.SmilePoint.Y - delta);
                        }
                       
                        break;
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DrawLeft(5, shapes);
            ReDraw(shapes);
        }


        private void ReDraw(IEnumerable<IShape> shapes)
        {
            g.Clear(pictureBox1.BackColor);
            var so = new SolidBrush(Color.Black);
            foreach (var shape in shapes)
                switch (shape)
                {
                    case IDrawStar star:
                        g.DrawPolygon(Pens.Blue, star.Points.ToArray());
                        break;
                    case IDrawSmileFace smile:
                        g.DrawEllipse(Pens.Blue, smile.FacePoint.X, smile.FacePoint.Y, IDrawSmileFace.FaceSizeWidth,
                            IDrawSmileFace.FaceSizeWidth);
                        g.FillEllipse(so, smile.FirstEyePoint.X, smile.FirstEyePoint.Y, IDrawSmileFace.EyeSizeWidth,
                            IDrawSmileFace.EyeSizeWidth);
                        g.FillEllipse(so, smile.SecondEyePoint.X, smile.SecondEyePoint.Y, IDrawSmileFace.EyeSizeWidth,
                            IDrawSmileFace.EyeSizeWidth);
                        g.DrawArc(Pens.Blue, smile.SmilePoint.X, smile.SmilePoint.Y, IDrawSmileFace.FaceSizeWidth,
                            IDrawSmileFace.FaceSizeWidth, IDrawSmileFace.SmileDegree, IDrawSmileFace.SmileDegreeSecond);
                        break;
                }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            button7.Text = char.ConvertFromUtf32(0x2193);
            button8.Text = char.ConvertFromUtf32(0x2191);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DrawRight(5, shapes);
            ReDraw(shapes);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DrawBottom(5, shapes);
            ReDraw(shapes);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DrawTop(5, shapes);
            ReDraw(shapes);
        }
    }
}