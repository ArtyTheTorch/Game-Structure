using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameStructure
{
    class SpecialEffectsState : IGameObject
    {
        Font _font;
        Text _text;
        Renderer _renderer = new Renderer();
        double _totalTime = 0;

        public SpecialEffectsState(TextureManager manager)
        {
            _font = new Font(manager.Get("font"), FontParser.Parse("font.fnt"));
            _text = new Text("Hello", _font);
        }

        //This Update will make the text go through the rainbow!
        //And make it move in a circle!
        //And make each character bounce!
        public void Update(double elapsedTime)
        {
            double frequency = 7;
            //For spinning
            double _wavyNumberX = Math.Sin(_totalTime * frequency) * 15;
            double _wavyNumberY = Math.Cos(_totalTime * frequency) * 15;
            //For changing the color
            float _wavyNumberR = (float)Math.Sin(_totalTime * frequency);
            float _wavyNumberG = (float)Math.Cos(_totalTime * frequency);
            float _wavyNumberB = (float)Math.Sin(_totalTime + 0.25 * frequency);
            _wavyNumberR = 0.5f + _wavyNumberR * 0.5f; // scale to 0-1
            _wavyNumberG = 0.5f + _wavyNumberG * 0.5f; // scale to 0-1
            _wavyNumberB = 0.5f + _wavyNumberB * 0.5f; // scale to 0-1

            //To make each character Bounce!
            int xAdvance = 0;
            foreach (CharacterSprite cs in _text.CharacterSprites)
            {
                Vector position = cs.Sprite.GetPosition();
                position.Y = 0 + Math.Sin((_totalTime + xAdvance) * frequency) * 25;
                position.X = Math.Cos((Math.PI / 2 * _totalTime + xAdvance) * frequency) * 25 - Math.Sin((Math.PI / 2 * _totalTime + xAdvance) * frequency) * 25;
                cs.Sprite.SetPosition(position);
                xAdvance++;
            }

            _text.SetColor(new Color(_wavyNumberR, _wavyNumberG, _wavyNumberB, 1));

            //To make the string move in a cirlce
            //_text.SetPosition(_wavyNumberX, _wavyNumberY);

            _totalTime += elapsedTime;
        }


        public void Render()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _renderer.DrawText(_text);
        }

    }
}
