using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameStructure
{
 class WaveformGraphState : IGameObject
{
  double _xPosition = -100;
  double _yPosition = -100;
  double _xLength = 200;
  double _yLength = 200;
  double _sampleSize = 100;
  double _frequency = 2;
  public delegate double WaveFunction(double value);

  public WaveformGraphState()
  {
    Gl.glLineWidth(3);
    Gl.glDisable(Gl.GL_TEXTURE_2D);
  }

  public void DrawAxis()
  {
    Gl.glColor3f(1, 1, 1);

    Gl.glBegin(Gl.GL_LINES);
    {
     // X axis
     Gl.glVertex2d(_xPosition, _yPosition);
     Gl.glVertex2d(_xPosition + _xLength, _yPosition);
     // Y axis
     Gl.glVertex2d(_xPosition, _yPosition);
     Gl.glVertex2d(_xPosition, _yPosition + _yLength);
    }
    Gl.glEnd();
  }

  public void DrawGraph(WaveFunction waveFunction, Color color)
  {
    double xIncrement = _xLength / _sampleSize;
    double previousX = _xPosition;
    double previousY = _yPosition + (0.5 * _yLength);
    Gl.glColor3f(color.Red, color.Green, color.Blue);
    Gl.glBegin(Gl.GL_LINES);
    {
     for (int i = 0; i < _sampleSize; i ++)
     {

       // Work out new X and Y positions
       double newX = previousX + xIncrement; // Increment one unit on the x
       // From 0-1 how far through plotting the graph are we?
       double percentDone = (i / _sampleSize);
       double percentRadians = percentDone * (Math.PI * _frequency);

       // Scale the wave value by the half the length
       double newY = _yPosition + waveFunction(percentRadians) *
(_yLength / 2);

       // Ignore the first value because the previous X and Y
       // haven't been worked out yet.
       if (i > 1)
       {
        Gl.glVertex2d(previousX, previousY);
        Gl.glVertex2d(newX, newY);
       }

       // Store the previous position
       previousX = newX;
       previousY = newY;
     }
    }
    Gl.glEnd();
  } // Empty Update and Render methods omitted


        #region IGameObject Members
        public void Render()
        {
            DrawAxis();
            //Basic Sine Graph
            //DrawGraph(Math.Sin, new Color(1, 0, 0, 1));

            //Basic Cosine Graph
            //DrawGraph(Math.Cos, new Color(0, 0.5f, 0.5f, 1));

            //Sine + Cosine
            //DrawGraph(delegate(double value)
            //{
            //    return (Math.Sin(value) + Math.Cos(value)) * 0.5;
            //}, new Color(0.5f, 0.5f, 1, 1));

            //Expierement
            DrawGraph(delegate(double value)
            {
                return (Math.Sin(value) + Math.Sin(value + value)) * 0.5;
            }, new Color(0.5f, 0.5f, 1, 1));


        }
        public void Update(double elapsedTime)
        {
            //Nothing in here
        }
        #endregion

    }
}
