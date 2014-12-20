using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameStructure
{
    public class Circle
    {
        Vector Position { get; set; }
        double Radius { get; set; }

        public Circle()
        {
            Position = Vector.Zero;
            Radius = 1;
        }

        public Circle(Vector position, double radius)
        {
            Position = position;
            Radius = radius;
        }

        Color _color = new Color(0, 1, 0, 1);
public Color Color
{
  get { return _color; }
  set { _color = value; }
}

public bool Intersects(Point point)
{
    // Change point to a vector
    Vector vPoint = new Vector(point.X, point.Y, 0);
    Vector vFromCircleToPoint = Position - vPoint;
    double distance = vFromCircleToPoint.Length();

    if (distance > Radius)
    {
        return false;
    }
    return true;
}

        public void Draw()
        {
            Gl.glColor3f(_color.Red, _color.Green, _color.Blue);
            // Determines how round the circle will appear.
            int vertexAmount = 10;
            double twoPI = 2.0 * Math.PI;

            // A line loop connects all the vertices with lines
            // The last vertex is connected to the first vertex
            // to make a loop.
            Gl.glBegin(Gl.GL_LINE_LOOP);
            {
                for (int i = 0; i <= vertexAmount; i++)
                {
                    double xPos = Position.X + Radius * Math.Cos(i * twoPI /
             vertexAmount);
                    double yPos = Position.Y + Radius * Math.Sin(i * twoPI /
             vertexAmount);
                    Gl.glVertex2d(xPos, yPos);
                }
            }
            Gl.glEnd();
        }
    }

}
