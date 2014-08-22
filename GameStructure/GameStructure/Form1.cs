using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;

namespace GameStructure
{
    public partial class Form1 : Form
    {
        FastLoop _fastLoop;
        bool _fullscreen = false;

        public Form1()
        {
            _fastLoop = new FastLoop(GameLoop);
            InitializeComponent();
            _openGLControl.InitializeContexts();
            if (_fullscreen)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
        }

        //This is where the magic happens
        void GameLoop(double elapsedTime)
        {
            //Make Background color
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            //Rotate the shape?
            Gl.glRotated(10 * elapsedTime, 0.0, 1,0.0);
            //Triangle with colors
            Gl.glBegin(Gl.GL_TRIANGLES);
            {
                Gl.glColor4d(1.0, 0.0, 0.0, 0.5);
                Gl.glVertex3d(-0.5, 0, 0);//Point
                Gl.glColor3d(0.0, 1.0, 0.0);
                Gl.glVertex3d(0.5, 0, 0);//Point
                Gl.glColor3d(0.0, 0.0, 1.0);
                Gl.glVertex3d(0, 0.5, 0);//Point

                //Gl.glColor3d(1.0, 0.0, 1.0);
                //Gl.glVertex3d(0,-.5, 0.0);//Point I added

                //Gl.glColor3d(1.0,1.0,0.0);
                //Gl.glVertex3d(0, 0, .5);//Point I added

                //Gl.glColor3d(0.0, 1.0, 1.0);
                //Gl.glVertex3d(0, 0, -.5);//Point I added
            }
            Gl.glEnd();
            Gl.glFinish();
            _openGLControl.Refresh();
        }
    }
}
