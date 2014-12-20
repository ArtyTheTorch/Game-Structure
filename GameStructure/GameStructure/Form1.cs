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
using Tao.DevIl;


namespace GameStructure
{

    public partial class Form1 : Form
    {
        Input _input = new Input();
        FastLoop _fastLoop;
        bool _fullscreen = false;

        StateSystem _system = new StateSystem();

        TextureManager _textureManager = new TextureManager();

        public Form1()
        {
            InitializeComponent();
            _openGLControl.InitializeContexts();

            //Init DevIl
            Il.ilInit();
            Ilu.iluInit();
            Ilut.ilutInit();
            Ilut.ilutRenderer(Ilut.ILUT_OPENGL);

            //Load Textures
            _textureManager.LoadTexture("face", "face.tif");
            _textureManager.LoadTexture("font", "font.tga");
            _textureManager.LoadTexture("face_alpha", "face_alpha.tif");

            //_textureManager.LoadTexture("face", "face_alpha.tif");

            // Add all the states that will be used.
            _system.AddState("splash", new SplashScreenState(_system));
            _system.AddState("title_menu", new TitleMenuState());
            _system.AddState("sprite_test", new DrawSpriteState(_textureManager));
            _system.AddState("test_sprite_class_state", new TestSpriteClassState(_textureManager));
            _system.AddState("text_test_state", new TextTestState(_textureManager));
            _system.AddState("text_renderer_state", new TextRenderState(_textureManager));
            _system.AddState("FPS_test_state", new FPSTestState(_textureManager));
            _system.AddState("waveform_graph_state", new WaveformGraphState());
            _system.AddState("special_effects_state", new SpecialEffectsState(_textureManager));
            _system.AddState("circle_intersection_state", new CircleIntersectionState(_input));
            _system.AddState("rectangle_intersection_state", new RectangleIntersectionState(_input));
            _system.AddState("tween_test_state", new TweenTestState(_textureManager));

            // Select the start state
            //Use this line when making a "Normal" Game _system.ChangeState("splash"); 
            _system.ChangeState("tween_test_state");




            if (_fullscreen)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
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

        //Used to take in position of the mouse
        private void UpdateInput()
        {
            System.Drawing.Point mousePos = Cursor.Position;
            mousePos = _openGLControl.PointToClient(mousePos);

            // Now use our point definition,
            Point adjustedMousePoint = new Point();
            adjustedMousePoint.X = (float)mousePos.X - ((float)ClientSize.Width
          / 2);
            adjustedMousePoint.Y = ((float)ClientSize.Height / 2) - (float)mousePos.Y;
            _input.MousePosition = adjustedMousePoint;
        }


        //This is the Flow for the game
        private void GameLoop(double elapsedTime)
        {
            UpdateInput();
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
