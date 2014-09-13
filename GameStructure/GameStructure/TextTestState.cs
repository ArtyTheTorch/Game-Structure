using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameStructure
{
    class TextTestState : IGameObject
    {
        Sprite _text = new Sprite();
        Renderer _renderer = new Renderer();
        public TextTestState(TextureManager textureManager)
        {
            _text.Texture = textureManager.Get("font");
            _text.SetUVs(new Point(0.113f, 0), new Point(0.171f, 0.101f));
            _text.SetWidth(15);
            _text.SetHeight(26);
        }
        public void Render()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _renderer.DrawSprite(_text);
        }
        public void Update(double elapsedTime)
        { 
        }
    }
}
