using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameStructure
{
    class TweenTestState : IGameObject
    {
        Tween _tween = new Tween(0, 800, 5);
        Sprite _faceSprite = new Sprite();
        Renderer _renderer = new Renderer();

        public TweenTestState(TextureManager textureManager)
        {
            _faceSprite.Texture = textureManager.Get("face");
            _faceSprite.SetHeight(0);
            _faceSprite.SetWidth(0);
        }

        public void Render()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _renderer.DrawSprite(_faceSprite);
            Gl.glFinish();
        }

        public void Update(double elapsedTime)
        {
            if (_tween.IsFinished() != true)
            {
                _tween.Update(elapsedTime);
                _faceSprite.SetWidth((float)_tween.Value());
                _faceSprite.SetHeight((float)_tween.Value());
            }
        }
    }
}
