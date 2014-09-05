using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameStructure
{
    class TestSpriteClassState: IGameObject
    {
        Renderer _renderer = new Renderer();
        TextureManager _textureManager;
        Sprite _testSprite = new Sprite();
        Sprite _testSprite2 = new Sprite();

        public void Update(double elapsedTime)
        { }

        public TestSpriteClassState(TextureManager textureManager)
        {
            _textureManager = textureManager;
            _testSprite.Texture = _textureManager.Get("face_alpha");
            _testSprite.SetHeight(256 * 0.5f);

            _testSprite2.Texture = _textureManager.Get("face_alpha");
            _testSprite2.SetPosition(-256, -256);
            _testSprite2.SetColor(new Color(1, 0, 0, 1));

        }
        public void Render()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _renderer.DrawSprite(_testSprite);
            _renderer.DrawSprite(_testSprite2);
            Gl.glFinish();
        }
    }
}
