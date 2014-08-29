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

        StateSystem _system = new StateSystem();

        public Form1()
        {
            // Add all the states that will be used.
            _system.AddState("splash", new SplashScreenState(_system));
            _system.AddState("title_menu", new TitleMenuState());

            // Select the start state
            _system.ChangeState("splash");


            InitializeComponent();
            _openGLControl.InitializeContexts();
            if (_fullscreen)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else {
                ClientSize = new Size(1280, 720);
            }
            Setup2DGraphics(ClientSize.Width, ClientSize.Height);
            _fastLoop = new FastLoop(GameLoop);
        }

        //Reshapes the drawing within the window (form) whenever the window is resized
        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            Gl.glViewport(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            Setup2DGraphics(ClientSize.Width, ClientSize.Height);
        }

        //This is the Flow for the game
        void GameLoop(double elapsedTime)
        {
            _system.Update(elapsedTime);
            _system.Render();
            _openGLControl.Refresh();
        }

        //For HUD and stuff (Orthographic Matrix)
        private void Setup2DGraphics(double width, double height)
        {
            double halfWidth = width / 2;
            double halfHeight = height / 2;
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(-halfWidth, halfWidth, -halfHeight, halfHeight, -100, 100);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
        
    }
}
